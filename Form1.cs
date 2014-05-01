using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ImageMagick;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Features2D;
using Emgu.Util;
using Emgu.CV.OCR;



namespace OCRRefinement
{
    public partial class Form1 : Form
    {
        OpenFileDialog openImageFileDialog = new OpenFileDialog();
        String rotate="none";		// rotate 90 clockwise (cw) or counterclockwise (ccw)
        String layout="portrait";   // rotate 90 to match layout; portrait or landscape
        String cropoff="";			// crop amounts; comma separate list of 1, 2 or 4 integers
        float numcrops=0;			// number of crops flag
        String gray="no";			// convert to grayscale flag
        String enhance="stretch";	// none, stretch, normalize
        float filtersize = 15;		// local area filter size
        float offset = 5;			// local area offset to remove "noise"; too small-get noise, too large-lose text
        String threshold="";        // smoothing threshold
        float sharpamt = 0;			// sharpen sigma
        float saturation = 200;		// color saturation percent; 100 is no change
        float adaptblur = 0;			// adaptive blur
        String unrotate="no";		// unrotate flag
        String trim = "no";			// trim flag
        float padamt = 0;			// pad amount
        String bgcolor="white";		// color for output whiteboard background
        float bluramt = 0.2F;			// blur sigma for use with smoothing threshold
        private Tesseract _ocr;

        public Form1()
        {
            InitializeComponent();
            _ocr = new Tesseract("", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bgr drawColor = new Bgr(Color.Blue);
                try
                {
                    Image<Bgr, Byte> image = new Image<Bgr, byte>(openImageFileDialog.FileName);
                    original.Image = image.ToBitmap();
                    original.SizeMode = PictureBoxSizeMode.Zoom;
                    using (Image<Gray, byte> gray = image.Convert<Gray, Byte>())
                    {
                        _ocr.Recognize(gray);
                        Tesseract.Charactor[] charactors = _ocr.GetCharactors();
                        foreach (Tesseract.Charactor c in charactors)
                        {
                            image.Draw(c.Region, drawColor, 1);
                        }

                        processed.Image = image.ToBitmap();
                        processed.SizeMode = PictureBoxSizeMode.Zoom;
                        //String text = String.Concat( Array.ConvertAll(charactors, delegate(Tesseract.Charactor t) { return t.Text; }) );
                        String text = _ocr.GetText();
                        ocrTextBox.Text = text;
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }

        }
    }
}
