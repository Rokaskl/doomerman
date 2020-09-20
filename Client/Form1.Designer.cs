namespace OPP
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
            this.drawingArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingArea.Image = global::OPP.Properties.Resources.Background;
            this.drawingArea.Location = new System.Drawing.Point(190, 12);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(480, 480);
            this.drawingArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            this.drawingArea.Click += new System.EventHandler(this.drawingArea_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(682, 509);
            this.Controls.Add(this.drawingArea);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
    }
}

