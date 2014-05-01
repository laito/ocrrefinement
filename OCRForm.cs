//----------------------------------------------------------------------------
//  Copyright (C) 2004-2012 by EMGU. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Features2D;
using Emgu.Util;


namespace OCRRefinement
{
   public partial class OCRForm : Form
   {
      OpenFileDialog OpenImages = new OpenFileDialog();
      public OCRForm()
      {
         InitializeComponent();
      }

      public Image<Bgr, float> alignment(Image<Bgr, float> fImage, Image<Bgr, float> lImage, Boolean qrCode)
      {
          HomographyMatrix homography = null;
          SURFDetector surfCPU = new SURFDetector(500, false);
          VectorOfKeyPoint modelKeyPoints;
          VectorOfKeyPoint observedKeyPoints;
          Matrix<int> indices;

          Matrix<byte> mask;

          int k = 2;
          double uniquenessThreshold = 0.8;


          Image<Gray, Byte> fImageG = fImage.Convert<Gray, Byte>();
          Image<Gray, Byte> lImageG = lImage.Convert<Gray, Byte>();

          //extract features from the object image
          modelKeyPoints = new VectorOfKeyPoint();
          Matrix<float> modelDescriptors = surfCPU.DetectAndCompute(fImageG, null, modelKeyPoints);


          // extract features from the observed image
          observedKeyPoints = new VectorOfKeyPoint();
          Matrix<float> observedDescriptors = surfCPU.DetectAndCompute(lImageG, null, observedKeyPoints);
          BruteForceMatcher<float> matcher = new BruteForceMatcher<float>(DistanceType.L2);
          matcher.Add(modelDescriptors);

          indices = new Matrix<int>(observedDescriptors.Rows, k);
          
          using (Matrix<float> dist = new Matrix<float>(observedDescriptors.Rows, k))
          {
              
              matcher.KnnMatch(observedDescriptors, indices, dist, k, null);
              mask = new Matrix<byte>(dist.Rows, 1);
              mask.SetValue(255);
              
              Features2DToolbox.VoteForUniqueness(dist, uniquenessThreshold, mask);
          }

          
          int nonZeroCount = CvInvoke.cvCountNonZero(mask);
          
          if (nonZeroCount >= 4)
          {
              nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, indices, mask, 1.5, 20);
              if (nonZeroCount >= 4)
                  
                  homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, indices, mask, 2);
          }



          if (!qrCode && homography.Sum > 0)
          {
              throw new Exception();
          }
          //Console.WriteLine("homo: " + indices.Size + " ," + homography.Size+ " "+homography.Sum);
          Image<Bgr, Byte> result = Features2DToolbox.DrawMatches(fImageG, modelKeyPoints, lImageG, observedKeyPoints,
           indices, new Bgr(255, 255, 255), new Bgr(255, 255, 255), mask, Features2DToolbox.KeypointDrawType.DEFAULT);
          if (homography != null)
          {
              Console.Write("homoegraphy is not null");
              //draw a rectangle along the projected model
              Rectangle rect = fImageG.ROI;
              PointF[] pts = new PointF[] { 
               new PointF(rect.Left, rect.Bottom),
               new PointF(rect.Right, rect.Bottom),
               new PointF(rect.Right, rect.Top),
               new PointF(rect.Left, rect.Top)};
              homography.ProjectPoints(pts);

              result.DrawPolyline(Array.ConvertAll<PointF, Point>(pts, Point.Round), true, new Bgr(Color.Red), 5);
              result.Save("resultqr.jpg");
              //mage<Bgr, byte> mosaic = new Image<Bgr, byte>(fImageG.Width + fImageG.Width, fImageG.Height);
              //Image<Bgr, byte> warp_image = mosaic.Clone();
              Image<Bgr, float> result2 = new Image<Bgr, float>(fImage.Size);
              //Image<Gray, Byte> result3 = new Image<Gray, Byte>(fImage.Size);
              CvInvoke.cvWarpPerspective(fImage.Ptr, result2, homography.Ptr, (int)INTER.CV_INTER_CUBIC + (int)WARP.CV_WARP_FILL_OUTLIERS, new MCvScalar(0));
              //CvInvoke.cvWarpPerspective(fImage.Ptr, result2, homography.Ptr, (int)INTER.CV_INTER_CUBIC + (int)WARP.CV_WARP_INVERSE_MAP, new MCvScalar(0));
              return result2;
          }
          else
          {
              Console.WriteLine("homography is null");
          }
          return null;
      }

      private void InitializeOpenFileDialog()
      {
          this.OpenImages.Filter =
              "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
              "All files (*.*)|*.*";
          this.OpenImages.Multiselect = true;
          this.OpenImages.Title = "My Image Browser";
      }



      public int getOtsuThreshold(Bitmap bmp)
      {
          byte t = 0;
          float[] vet = new float[256];
          int[] hist = new int[256];
          vet.Initialize();

          float p1, p2, p12;
          int k;

          BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
          ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          unsafe
          {
              byte* p = (byte*)(void*)bmData.Scan0.ToPointer();

              getHistogram(p, bmp.Width, bmp.Height, bmData.Stride, hist);


              for (k = 1; k != 255; k++)
              {
                  p1 = Px(0, k, hist);
                  p2 = Px(k + 1, 255, hist);
                  p12 = p1 * p2;
                  if (p12 == 0)
                      p12 = 1;
                  float diff = (Mx(0, k, hist) * p2) - (Mx(k + 1, 255, hist) * p1);
                  vet[k] = (float)diff * diff / p12;

              }
          }
          bmp.UnlockBits(bmData);

          t = (byte)findMax(vet, 256);

          return t;
      }

      
     

      private void loadImageButton_Click(object sender, EventArgs e)
      {


         Image<Bgr, float> reference = new Image<Bgr, float>("ref.png");
         Image<Bgr, float> qreference = new Image<Bgr, float>("qref5.jpg");
         List<Image<Bgr, float>> imageList = new List<Image<Bgr, float>>();
         InitializeOpenFileDialog();
         DialogResult openedfiles = this.OpenImages.ShowDialog();
         
          int fileCount = 0;

          if (openedfiles == System.Windows.Forms.DialogResult.OK)
          {
              fileCount = OpenImages.FileNames.Length;
              if (fileCount >= 1)
              {

                  foreach (String file in OpenImages.FileNames)
                  {
                      Bgr drawColor = new Bgr(Color.Blue);
                      try
                      {
                          Image<Bgr, float> image = new Image<Bgr, float>(file);
                          Image<Bgr, float> qrcode = alignment(image, qreference,true);
                          qrcode.Save(System.IO.Path.GetDirectoryName(file)+"\\"+System.IO.Path.GetFileName(file) + "_QRCode.jpg");
                          
                          Image<Bgr, float> output = alignment(image, reference,false);
                          

                          Console.WriteLine(file);
                          fileNameTextBox.Text = file;
                          original.Image = image.ToBitmap();
                          original.SizeMode = PictureBoxSizeMode.Zoom;
                          /*
                          for (int i = 0; i < output.Height; i++)
                          {
                              for (int j = 0; j < output.Width; j++)
                              {
                                  if ((output.Data[i, j, 0] > 40 && output.Data[i, j, 1] > 40 && output.Data[i, j, 2] > 40) || output.Data[i, j, 1] > 60)
                                  {
                                    //  output.Data[i, j, 0] = 255;
                                      //output.Data[i, j, 1] = 255;
                                    //  output.Data[i, j, 2] = 255;
                                  }
                              }
                          }
                          */
                          Image<Hsv, Byte> hsvimg = output.Convert<Hsv, Byte>();
                          Image<Gray, Byte>[] channels = hsvimg.Split();
                          Image<Gray, Byte> imghue = channels[0];
                          Image<Gray, Byte> imgsat = channels[1];
                          Image<Gray, Byte> imgval = channels[2];
                        //  Image<Gray, byte> huefilter = imghue.InRange(new Gray(Color.Green.GetHue() - 30), new Gray(Color.Green.GetHue() + 30));
                      //    Image<Gray, byte> satfilter = imghue.InRange(new Gray(Color.Green.GetSaturation() - 30), new Gray(Color.Green.GetSaturation() + 30));
                      //    Image<Gray, byte> valfilter = imgval.InRange(new Gray(Color.Green.GetBrightness() - 30), new Gray(Color.Green.GetBrightness() + 30));
                         // huefilter.Save("D:\\Data\\Images\\hue.jpg");


                          Image<Gray, byte> huefilter = imghue.InRange(new Gray(80), new Gray(100));
                          //imghue.Save("D:\\Data\\Images\\hueimage.jpg");
                          //huefilter.Save("D:\\Data\\Images\\hue.jpg");
                          //use the value channel to filter out all but brighter colors
                          Image<Gray, byte> valfilter = imgval.InRange(new Gray(0), new Gray(100));
                          Image<Gray, Byte> hsvimgoutput = huefilter.And(valfilter);
                          Image<Bgr, float> dest_image = new Image<Bgr, float>(output.Size);
                          
                          
                         // Image<Hsv, Byte> hsvimgoutput = new Image<Hsv, Byte>(output.Size);
                         // CvInvoke.cvMerge(huefilter, satfilter, valfilter, IntPtr.Zero, hsvimgoutput);
                          //hsvimgoutput.Save("D:\\Data\\Images\\filter.jpg");
                          correctedImage.Image = output.ToBitmap();
                          correctedImage.SizeMode = PictureBoxSizeMode.Zoom;
                          output.Save(System.IO.Path.GetDirectoryName(file) + "\\" + System.IO.Path.GetFileName(file) + "_aligned.jpg");
                          double ContourThresh = 0.003; //stores alpha for thread access
                          int Threshold_smooth = 60; //stores threshold for thread access

                          int Threshold = 125; // getOtsuThreshold(output.ToBitmap());
                          Console.WriteLine(Threshold);
                          
                          Image<Gray, byte> output_gray = output.Convert<Gray, byte>();
                          //output_gray._EqualizeHist();
                          Image<Bgr, float> output_gray2 = output_gray.Convert<Bgr, float>();
                          Image<Bgr, float> enhanced = new Image<Bgr, float>(output.Size);
                          Image<Bgr, float> enhanced_smooth = new Image<Bgr, float>(output.Size);
                          Image<Bgr, float> temp = new Image<Bgr, float>(output.Size);
                          enhanced = output_gray2.ThresholdBinary(new Bgr(Threshold_smooth, Threshold_smooth, Threshold_smooth), new Bgr(255, 255, 255)); //if value > 60 set to 255, 0 otherwise 
                          enhanced_smooth = output_gray2.ThresholdBinary(new Bgr(Threshold, Threshold, Threshold), new Bgr(255, 255, 255)); //if value > 60 set to 255, 0 otherwise 
                          //enhanced_smooth.Save("D:\\Data\\Images\\esmooth.jpg");

                          // Repair broken letters
                          int n = 3;
                          IntPtr cross = Emgu.CV.CvInvoke.cvCreateStructuringElementEx(n, n, n / 2, n / 2, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_ELLIPSE, System.IntPtr.Zero);
                          //CvInvoke.cvMorphologyEx(enhanced, enhanced, temp, cross, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_CLOSE, 1);
                          temp = enhanced.Clone();
                         // Emgu.CV.CvInvoke.cvErode(enhanced, temp, cross, 2);
                          
                          //

                          Image<Gray, float> mask = new Image<Gray, float>("mask.jpg");

                          for (int i = 0; i < temp.Height; i++)
                          {
                              for (int j = 0; j < temp.Width; j++)
                              {
                                  if (mask.Data[i, j, 0] == 0)
                                  {
                                      temp.Data[i, j, 0] = enhanced_smooth.Data[i,j,0];
                                      temp.Data[i, j, 1] = enhanced_smooth.Data[i, j, 1];
                                      temp.Data[i, j, 2] = enhanced_smooth.Data[i, j, 2];
                                  }
                              }
                          }
                          temp.Save(System.IO.Path.GetDirectoryName(file) + "\\" + System.IO.Path.GetFileName(file) + "_enhanced.jpg");
                          enhancedImage.Image = temp.ToBitmap();
                          enhancedImage.SizeMode = PictureBoxSizeMode.Zoom;
                          
                      }
                      catch (Exception exception)
                      {
                         // MessageBox.Show(exception.Message);
                          MessageBox.Show("Photo Rejected");
                      }
                  }
              }
          }
      }

      private void loadLanguageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         
      }

      private void imageBox1_Click(object sender, EventArgs e)
      {

      }

      private void ocrTextBox_TextChanged(object sender, EventArgs e)
      {

      }

      private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
      {
                }

      private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
      {

      }

      private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
      {

      }

      private float Px(int init, int end, int[] hist)
      {
          int sum = 0;
          int i;
          for (i = init; i <= end; i++)
              sum += hist[i];

          return (float)sum;
      }

      // function is used to compute the mean values in the equation (mu)
      private float Mx(int init, int end, int[] hist)
      {
          int sum = 0;
          int i;
          for (i = init; i <= end; i++)
              sum += i * hist[i];

          return (float)sum;
      }

      // finds the maximum element in a vector
      private int findMax(float[] vec, int n)
      {
          float maxVec = 0;
          int idx = 0;
          int i;

          for (i = 1; i < n - 1; i++)
          {
              if (vec[i] > maxVec)
              {
                  maxVec = vec[i];
                  idx = i;
              }
          }
          return idx;
      }

      // simply computes the image histogram
      unsafe private void getHistogram(byte* p, int w, int h, int ws, int[] hist)
      {
          hist.Initialize();
          for (int i = 0; i < h; i++)
          {
              for (int j = 0; j < w * 3; j += 3)
              {
                  int index = i * ws + j;
                  hist[p[index]]++;
              }
          }
      }

     

      // simple routine to convert to gray scale
      public void Convert2GrayScaleFast(Bitmap bmp)
      {
          BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                  ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
          unsafe
          {
              byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
              int stopAddress = (int)p + bmData.Stride * bmData.Height;
              while ((int)p != stopAddress)
              {
                  p[0] = (byte)(.299 * p[2] + .587 * p[1] + .114 * p[0]);
                  p[1] = p[0];
                  p[2] = p[0];
                  p += 3;
              }
          }
          bmp.UnlockBits(bmData);
      }

      // simple routine for thresholdin
      public void threshold(Bitmap bmp, int thresh)
      {
          BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
          ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
          unsafe
          {
              byte* p = (byte*)(void*)bmData.Scan0.ToPointer();
              int h = bmp.Height;
              int w = bmp.Width;
              int ws = bmData.Stride;

              for (int i = 0; i < h; i++)
              {
                  byte* row = &p[i * ws];
                  for (int j = 0; j < w * 3; j += 3)
                  {
                      row[j] = (byte)((row[j] > (byte)thresh) ? 255 : 0);
                      row[j + 1] = (byte)((row[j + 1] > (byte)thresh) ? 255 : 0);
                      row[j + 2] = (byte)((row[j + 2] > (byte)thresh) ? 255 : 0);
                  }
              }
          }
          bmp.UnlockBits(bmData);
      }
   }
}
