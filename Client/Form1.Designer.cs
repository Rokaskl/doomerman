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
            this.PB_connectedUser = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_connectedUser)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.btToggleSound.Location = new System.Drawing.Point(625, 574);
            this.btToggleSound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btToggleSound.Name = "btToggleSound";
            this.btToggleSound.Size = new System.Drawing.Size(40, 37);
            this.btToggleSound.TabIndex = 1;
            this.btToggleSound.UseVisualStyleBackColor = false;
            this.btToggleSound.Click += new System.EventHandler(this.btToggleSound_Click);
            // 
            // drawingArea
            // 
            this.drawingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.drawingArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingArea.Location = new System.Drawing.Point(13, 4);
            this.drawingArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(640, 591);
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
            this.panelMenu.Location = new System.Drawing.Point(229, 338);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(223, 132);
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
            this.btQuit.Location = new System.Drawing.Point(15, 68);
            this.btQuit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btQuit.Name = "btQuit";
            this.btQuit.Size = new System.Drawing.Size(196, 53);
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
            this.btPlay.Location = new System.Drawing.Point(15, 7);
            this.btPlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(196, 53);
            this.btPlay.TabIndex = 0;
            this.btPlay.Text = "Play";
            this.btPlay.UseVisualStyleBackColor = false;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // PB_connectedUser
            // 
            this.PB_connectedUser.BackColor = System.Drawing.Color.Transparent;
            this.PB_connectedUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PB_connectedUser.Location = new System.Drawing.Point(16, 4);
            this.PB_connectedUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PB_connectedUser.Name = "PB_connectedUser";
            this.PB_connectedUser.Size = new System.Drawing.Size(40, 37);
            this.PB_connectedUser.TabIndex = 3;
            this.PB_connectedUser.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.richTextBox2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(157, 271);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 340);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(25, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(308, 37);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:PORT";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.Azure;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(72, 207);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Join";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Azure;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(72, 270);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(215, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(25, 151);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(308, 37);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(125, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "NAME";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.BackgroundImage = global::OPP.Properties.Resources.main_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(673, 619);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PB_connectedUser);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.btToggleSound);
            this.Controls.Add(this.drawingArea);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOOMER MAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PB_connectedUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox drawingArea;
        private System.Windows.Forms.Button btToggleSound;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btQuit;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.PictureBox PB_connectedUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}

