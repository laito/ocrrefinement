namespace OCRRefinement
{
    partial class Form1
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
            this.original = new System.Windows.Forms.PictureBox();
            this.processed = new System.Windows.Forms.PictureBox();
            this.loadimg = new System.Windows.Forms.Button();
            this.ocrTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processed)).BeginInit();
            this.SuspendLayout();
            // 
            // original
            // 
            this.original.Location = new System.Drawing.Point(15, 54);
            this.original.Name = "original";
            this.original.Size = new System.Drawing.Size(317, 430);
            this.original.TabIndex = 0;
            this.original.TabStop = false;
            // 
            // processed
            // 
            this.processed.Location = new System.Drawing.Point(361, 54);
            this.processed.Name = "processed";
            this.processed.Size = new System.Drawing.Size(317, 430);
            this.processed.TabIndex = 1;
            this.processed.TabStop = false;
            // 
            // loadimg
            // 
            this.loadimg.Location = new System.Drawing.Point(291, 12);
            this.loadimg.Name = "loadimg";
            this.loadimg.Size = new System.Drawing.Size(114, 32);
            this.loadimg.TabIndex = 2;
            this.loadimg.Text = "Load Image";
            this.loadimg.UseVisualStyleBackColor = true;
            // 
            // ocrTextBox
            // 
            this.ocrTextBox.Location = new System.Drawing.Point(15, 500);
            this.ocrTextBox.Name = "ocrTextBox";
            this.ocrTextBox.Size = new System.Drawing.Size(663, 329);
            this.ocrTextBox.TabIndex = 3;
            this.ocrTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 841);
            this.Controls.Add(this.ocrTextBox);
            this.Controls.Add(this.loadimg);
            this.Controls.Add(this.processed);
            this.Controls.Add(this.original);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox original;
        private System.Windows.Forms.PictureBox processed;
        private System.Windows.Forms.Button loadimg;
        private System.Windows.Forms.RichTextBox ocrTextBox;
    }
}

