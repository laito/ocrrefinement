namespace OCRRefinement
{
   partial class OCRForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
          this.openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
          this.openLanguageFileDialog = new System.Windows.Forms.OpenFileDialog();
          this.splitContainer2 = new System.Windows.Forms.SplitContainer();
          this.corrected = new System.Windows.Forms.PictureBox();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.loadLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.loadImageButton = new System.Windows.Forms.Button();
          this.fileNameTextBox = new System.Windows.Forms.TextBox();
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.splitContainer3 = new System.Windows.Forms.SplitContainer();
          this.original = new System.Windows.Forms.PictureBox();
          this.correctedImage = new System.Windows.Forms.PictureBox();
          this.enhancedImage = new System.Windows.Forms.PictureBox();
          this.label1 = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
          this.splitContainer2.Panel1.SuspendLayout();
          this.splitContainer2.Panel2.SuspendLayout();
          this.splitContainer2.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.corrected)).BeginInit();
          this.menuStrip1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
          this.splitContainer3.Panel1.SuspendLayout();
          this.splitContainer3.Panel2.SuspendLayout();
          this.splitContainer3.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.original)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.correctedImage)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.enhancedImage)).BeginInit();
          this.SuspendLayout();
          // 
          // openImageFileDialog
          // 
          this.openImageFileDialog.FileName = "openFileDialog1";
          // 
          // openLanguageFileDialog
          // 
          this.openLanguageFileDialog.DefaultExt = "traineddata";
          this.openLanguageFileDialog.Filter = "\"tesseract language file|*.traineddata|All files|*.*\"";
          // 
          // splitContainer2
          // 
          this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer2.Location = new System.Drawing.Point(0, 0);
          this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
          this.splitContainer2.Name = "splitContainer2";
          // 
          // splitContainer2.Panel1
          // 
          this.splitContainer2.Panel1.Controls.Add(this.original);
          this.splitContainer2.Panel1.Controls.Add(this.corrected);
          this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
          // 
          // splitContainer2.Panel2
          // 
          this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
          this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
          this.splitContainer2.Size = new System.Drawing.Size(1539, 647);
          this.splitContainer2.SplitterDistance = 509;
          this.splitContainer2.SplitterWidth = 5;
          this.splitContainer2.TabIndex = 0;
          // 
          // corrected
          // 
          this.corrected.Location = new System.Drawing.Point(638, 94);
          this.corrected.Name = "corrected";
          this.corrected.Size = new System.Drawing.Size(614, 619);
          this.corrected.TabIndex = 5;
          this.corrected.TabStop = false;
          // 
          // menuStrip1
          // 
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
          this.menuStrip1.Size = new System.Drawing.Size(1539, 28);
          this.menuStrip1.TabIndex = 3;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLanguageToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
          this.fileToolStripMenuItem.Text = "File";
          // 
          // loadLanguageToolStripMenuItem
          // 
          this.loadLanguageToolStripMenuItem.Name = "loadLanguageToolStripMenuItem";
          this.loadLanguageToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
          this.loadLanguageToolStripMenuItem.Text = "Load Language";
          this.loadLanguageToolStripMenuItem.Click += new System.EventHandler(this.loadLanguageToolStripMenuItem_Click);
          // 
          // loadImageButton
          // 
          this.loadImageButton.Location = new System.Drawing.Point(813, 30);
          this.loadImageButton.Margin = new System.Windows.Forms.Padding(4);
          this.loadImageButton.Name = "loadImageButton";
          this.loadImageButton.Size = new System.Drawing.Size(100, 28);
          this.loadImageButton.TabIndex = 2;
          this.loadImageButton.Text = "Load Image";
          this.loadImageButton.UseVisualStyleBackColor = true;
          this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
          // 
          // fileNameTextBox
          // 
          this.fileNameTextBox.Location = new System.Drawing.Point(89, 33);
          this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
          this.fileNameTextBox.Name = "fileNameTextBox";
          this.fileNameTextBox.ReadOnly = true;
          this.fileNameTextBox.Size = new System.Drawing.Size(691, 22);
          this.fileNameTextBox.TabIndex = 1;
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
          this.splitContainer1.Name = "splitContainer1";
          this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.label3);
          this.splitContainer1.Panel1.Controls.Add(this.label2);
          this.splitContainer1.Panel1.Controls.Add(this.label1);
          this.splitContainer1.Panel1.Controls.Add(this.fileNameTextBox);
          this.splitContainer1.Panel1.Controls.Add(this.loadImageButton);
          this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
          this.splitContainer1.Size = new System.Drawing.Size(1539, 750);
          this.splitContainer1.SplitterDistance = 98;
          this.splitContainer1.SplitterWidth = 5;
          this.splitContainer1.TabIndex = 3;
          // 
          // splitContainer3
          // 
          this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer3.Location = new System.Drawing.Point(0, 0);
          this.splitContainer3.Name = "splitContainer3";
          // 
          // splitContainer3.Panel1
          // 
          this.splitContainer3.Panel1.Controls.Add(this.correctedImage);
          // 
          // splitContainer3.Panel2
          // 
          this.splitContainer3.Panel2.Controls.Add(this.enhancedImage);
          this.splitContainer3.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel2_Paint);
          this.splitContainer3.Size = new System.Drawing.Size(1025, 647);
          this.splitContainer3.SplitterDistance = 515;
          this.splitContainer3.TabIndex = 0;
          // 
          // original
          // 
          this.original.Location = new System.Drawing.Point(0, 0);
          this.original.Name = "original";
          this.original.Size = new System.Drawing.Size(497, 644);
          this.original.TabIndex = 6;
          this.original.TabStop = false;
          // 
          // correctedImage
          // 
          this.correctedImage.Location = new System.Drawing.Point(3, 0);
          this.correctedImage.Name = "correctedImage";
          this.correctedImage.Size = new System.Drawing.Size(497, 644);
          this.correctedImage.TabIndex = 7;
          this.correctedImage.TabStop = false;
          // 
          // enhancedImage
          // 
          this.enhancedImage.Location = new System.Drawing.Point(2, 0);
          this.enhancedImage.Name = "enhancedImage";
          this.enhancedImage.Size = new System.Drawing.Size(497, 644);
          this.enhancedImage.TabIndex = 8;
          this.enhancedImage.TabStop = false;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(213, 72);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(99, 17);
          this.label1.TabIndex = 4;
          this.label1.Text = "Original Image";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(715, 72);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(112, 17);
          this.label2.TabIndex = 5;
          this.label2.Text = "Corrected Image";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(1267, 72);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(114, 17);
          this.label3.TabIndex = 6;
          this.label3.Text = "Enhanced Image";
          // 
          // OCRForm
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(1539, 750);
          this.Controls.Add(this.splitContainer1);
          this.MainMenuStrip = this.menuStrip1;
          this.Margin = new System.Windows.Forms.Padding(4);
          this.Name = "OCRForm";
          this.Text = "Form1";
          this.splitContainer2.Panel1.ResumeLayout(false);
          this.splitContainer2.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
          this.splitContainer2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.corrected)).EndInit();
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel1.PerformLayout();
          this.splitContainer1.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
          this.splitContainer1.ResumeLayout(false);
          this.splitContainer3.Panel1.ResumeLayout(false);
          this.splitContainer3.Panel2.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
          this.splitContainer3.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.original)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.correctedImage)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.enhancedImage)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.OpenFileDialog openImageFileDialog;
      private System.Windows.Forms.OpenFileDialog openLanguageFileDialog;
      private System.Windows.Forms.SplitContainer splitContainer2;
      private System.Windows.Forms.PictureBox corrected;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadLanguageToolStripMenuItem;
      private System.Windows.Forms.Button loadImageButton;
      private System.Windows.Forms.TextBox fileNameTextBox;
      private System.Windows.Forms.SplitContainer splitContainer1;
      private System.Windows.Forms.SplitContainer splitContainer3;
      private System.Windows.Forms.PictureBox original;
      private System.Windows.Forms.PictureBox correctedImage;
      private System.Windows.Forms.PictureBox enhancedImage;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}

