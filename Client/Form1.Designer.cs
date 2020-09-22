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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btToggleSound = new System.Windows.Forms.Button();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btQuit = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btToggleSound
            // 
            this.btToggleSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btToggleSound.BackColor = System.Drawing.Color.MintCream;
            this.btToggleSound.BackgroundImage = global::OPP.Properties.Resources.audio_speaker;
            this.btToggleSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btToggleSound.Cursor = System.Windows.Forms.Cursors.Default;
            this.btToggleSound.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btToggleSound.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btToggleSound.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btToggleSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btToggleSound.Location = new System.Drawing.Point(469, 466);
            this.btToggleSound.Name = "btToggleSound";
            this.btToggleSound.Size = new System.Drawing.Size(30, 30);
            this.btToggleSound.TabIndex = 1;
            this.btToggleSound.UseVisualStyleBackColor = false;
            this.btToggleSound.Click += new System.EventHandler(this.btToggleSound_Click);
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.drawingArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingArea.Location = new System.Drawing.Point(12, 10);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(480, 480);
            this.drawingArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.drawingArea.TabIndex = 0;
            this.drawingArea.TabStop = false;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Transparent;
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenu.Controls.Add(this.btQuit);
            this.panelMenu.Controls.Add(this.btPlay);
            this.panelMenu.Location = new System.Drawing.Point(172, 275);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(167, 107);
            this.panelMenu.TabIndex = 2;
            // 
            // btQuit
            // 
            this.btQuit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btQuit.BackColor = System.Drawing.Color.Azure;
            this.btQuit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btQuit.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btQuit.Location = new System.Drawing.Point(11, 55);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(147, 43);
            this.btQuit.TabIndex = 1;
            this.btQuit.Text = "Quit";
            this.btQuit.UseVisualStyleBackColor = false;
            this.btQuit.Click += new System.EventHandler(this.btQuit_Click);
            // 
            // btPlay
            // 
            this.btPlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btPlay.BackColor = System.Drawing.Color.Azure;
            this.btPlay.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.btPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlay.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btPlay.Location = new System.Drawing.Point(11, 6);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(147, 43);
            this.btPlay.TabIndex = 0;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = false;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.BackgroundImage = global::OPP.Properties.Resources.main_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(505, 503);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btToggleSound);
            this.Controls.Add(this.drawingArea);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOOMER MAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button btToggleSound;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btQuit;
        private System.Windows.Forms.Button btPlay;
    }
}

