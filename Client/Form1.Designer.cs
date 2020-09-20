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
            this.btDraw = new System.Windows.Forms.Button();
            this.btLoadImage = new System.Windows.Forms.Button();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelImageTest = new System.Windows.Forms.Panel();
            this.btStopDraw = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLayer = new System.Windows.Forms.TextBox();
            this.btAddSprite = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.panelImageTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingArea
            // 
            this.drawingArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingArea.Image = global::OPP.Properties.Resources.Background;
            this.drawingArea.Location = new System.Drawing.Point(257, 13);
            this.drawingArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(639, 590);
            this.drawingArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            this.drawingArea.Click += new System.EventHandler(this.drawingArea_Click);
            // 
            // btDraw
            // 
            this.btDraw.Location = new System.Drawing.Point(4, 158);
            this.btDraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btDraw.Name = "btDraw";
            this.btDraw.Size = new System.Drawing.Size(100, 28);
            this.btDraw.TabIndex = 1;
            this.btDraw.TabStop = false;
            this.btDraw.Text = "Draw";
            this.btDraw.UseVisualStyleBackColor = true;
            this.btDraw.Click += new System.EventHandler(this.btDraw_Click);
            // 
            // btLoadImage
            // 
            this.btLoadImage.Location = new System.Drawing.Point(11, 4);
            this.btLoadImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btLoadImage.Name = "btLoadImage";
            this.btLoadImage.Size = new System.Drawing.Size(145, 28);
            this.btLoadImage.TabIndex = 2;
            this.btLoadImage.TabStop = false;
            this.btLoadImage.Text = "Load image...";
            this.btLoadImage.UseVisualStyleBackColor = true;
            this.btLoadImage.Click += new System.EventHandler(this.btLoadImage_Click);
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(56, 39);
            this.textBoxX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(75, 22);
            this.textBoxX.TabIndex = 3;
            this.textBoxX.TabStop = false;
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(56, 71);
            this.textBoxY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(75, 22);
            this.textBoxY.TabIndex = 4;
            this.textBoxY.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y:";
            // 
            // panelImageTest
            // 
            this.panelImageTest.Controls.Add(this.btStopDraw);
            this.panelImageTest.Controls.Add(this.label3);
            this.panelImageTest.Controls.Add(this.textBoxLayer);
            this.panelImageTest.Controls.Add(this.btAddSprite);
            this.panelImageTest.Controls.Add(this.btLoadImage);
            this.panelImageTest.Controls.Add(this.label2);
            this.panelImageTest.Controls.Add(this.btDraw);
            this.panelImageTest.Controls.Add(this.label1);
            this.panelImageTest.Controls.Add(this.textBoxX);
            this.panelImageTest.Controls.Add(this.textBoxY);
            this.panelImageTest.Location = new System.Drawing.Point(16, 15);
            this.panelImageTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelImageTest.Name = "panelImageTest";
            this.panelImageTest.Size = new System.Drawing.Size(204, 190);
            this.panelImageTest.TabIndex = 7;
            // 
            // btStopDraw
            // 
            this.btStopDraw.Location = new System.Drawing.Point(112, 158);
            this.btStopDraw.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btStopDraw.Name = "btStopDraw";
            this.btStopDraw.Size = new System.Drawing.Size(88, 28);
            this.btStopDraw.TabIndex = 10;
            this.btStopDraw.TabStop = false;
            this.btStopDraw.Text = "Stop";
            this.btStopDraw.UseVisualStyleBackColor = true;
            this.btStopDraw.Click += new System.EventHandler(this.btStopDraw_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Layer";
            // 
            // textBoxLayer
            // 
            this.textBoxLayer.Location = new System.Drawing.Point(56, 105);
            this.textBoxLayer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLayer.Name = "textBoxLayer";
            this.textBoxLayer.Size = new System.Drawing.Size(75, 22);
            this.textBoxLayer.TabIndex = 8;
            this.textBoxLayer.TabStop = false;
            // 
            // btAddSprite
            // 
            this.btAddSprite.Location = new System.Drawing.Point(165, 5);
            this.btAddSprite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btAddSprite.Name = "btAddSprite";
            this.btAddSprite.Size = new System.Drawing.Size(37, 27);
            this.btAddSprite.TabIndex = 7;
            this.btAddSprite.TabStop = false;
            this.btAddSprite.Text = "+";
            this.btAddSprite.UseVisualStyleBackColor = true;
            this.btAddSprite.Click += new System.EventHandler(this.btAddSprite_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(909, 626);
            this.Controls.Add(this.panelImageTest);
            this.Controls.Add(this.drawingArea);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.panelImageTest.ResumeLayout(false);
            this.panelImageTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button btDraw;
        private System.Windows.Forms.Button btLoadImage;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelImageTest;
        private System.Windows.Forms.Button btAddSprite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLayer;
        private System.Windows.Forms.Button btStopDraw;
    }
}

