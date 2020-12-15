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
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.player1Panel = new System.Windows.Forms.Panel();
            this.player1Name = new System.Windows.Forms.Label();
            this.player1Icon = new System.Windows.Forms.PictureBox();
            this.player1ReadyBox = new System.Windows.Forms.PictureBox();
            this.player2Panel = new System.Windows.Forms.Panel();
            this.player2Name = new System.Windows.Forms.Label();
            this.player2Icon = new System.Windows.Forms.PictureBox();
            this.player2ReadyBox = new System.Windows.Forms.PictureBox();
            this.player3Panel = new System.Windows.Forms.Panel();
            this.player3Name = new System.Windows.Forms.Label();
            this.player3Icon = new System.Windows.Forms.PictureBox();
            this.player3ReadyBox = new System.Windows.Forms.PictureBox();
            this.player4Panel = new System.Windows.Forms.Panel();
            this.player4Name = new System.Windows.Forms.Label();
            this.player4Icon = new System.Windows.Forms.PictureBox();
            this.player4ReadyBox = new System.Windows.Forms.PictureBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_connectedUser)).BeginInit();
            this.panel1.SuspendLayout();
            this.player1Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1ReadyBox)).BeginInit();
            this.player2Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2ReadyBox)).BeginInit();
            this.player3Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player3Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3ReadyBox)).BeginInit();
            this.player4Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player4Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4ReadyBox)).BeginInit();
            this.panel6.SuspendLayout();
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
            this.drawingArea.Location = new System.Drawing.Point(10, 3);
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
            // PB_connectedUser
            // 
            this.PB_connectedUser.BackColor = System.Drawing.Color.Transparent;
            this.PB_connectedUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PB_connectedUser.Location = new System.Drawing.Point(12, 3);
            this.PB_connectedUser.Name = "PB_connectedUser";
            this.PB_connectedUser.Size = new System.Drawing.Size(30, 30);
            this.PB_connectedUser.TabIndex = 3;
            this.PB_connectedUser.TabStop = false;
            this.PB_connectedUser.Visible = false;
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
            this.panel1.Location = new System.Drawing.Point(116, 220);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 276);
            this.panel1.TabIndex = 4;
            this.panel1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(94, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "NAME";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(19, 123);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(232, 31);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
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
            this.button2.Location = new System.Drawing.Point(54, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.button1.Location = new System.Drawing.Point(54, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Join";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(84, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP:PORT";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(19, 54);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(232, 31);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "127.0.0.1:13000";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 40);
            this.button3.TabIndex = 6;
            this.button3.Text = "Ready";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // player1Panel
            // 
            this.player1Panel.Controls.Add(this.player1Name);
            this.player1Panel.Controls.Add(this.player1Icon);
            this.player1Panel.Controls.Add(this.player1ReadyBox);
            this.player1Panel.Location = new System.Drawing.Point(56, 47);
            this.player1Panel.Margin = new System.Windows.Forms.Padding(2);
            this.player1Panel.Name = "player1Panel";
            this.player1Panel.Size = new System.Drawing.Size(375, 81);
            this.player1Panel.TabIndex = 5;
            this.player1Panel.Visible = false;
            // 
            // player1Name
            // 
            this.player1Name.AutoSize = true;
            this.player1Name.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1Name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player1Name.Location = new System.Drawing.Point(76, 31);
            this.player1Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player1Name.Name = "player1Name";
            this.player1Name.Size = new System.Drawing.Size(103, 23);
            this.player1Name.TabIndex = 10;
            this.player1Name.Text = "DoomerBoi";
            // 
            // player1Icon
            // 
            this.player1Icon.BackColor = System.Drawing.Color.Transparent;
            this.player1Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player1Icon.InitialImage = global::OPP.Properties.Resources.not_ready;
            this.player1Icon.Location = new System.Drawing.Point(22, 24);
            this.player1Icon.Margin = new System.Windows.Forms.Padding(0);
            this.player1Icon.Name = "player1Icon";
            this.player1Icon.Size = new System.Drawing.Size(30, 32);
            this.player1Icon.TabIndex = 9;
            this.player1Icon.TabStop = false;
            // 
            // player1ReadyBox
            // 
            this.player1ReadyBox.BackColor = System.Drawing.Color.Transparent;
            this.player1ReadyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player1ReadyBox.InitialImage = global::OPP.Properties.Resources.not_ready;
            this.player1ReadyBox.Location = new System.Drawing.Point(300, 20);
            this.player1ReadyBox.Margin = new System.Windows.Forms.Padding(0);
            this.player1ReadyBox.Name = "player1ReadyBox";
            this.player1ReadyBox.Size = new System.Drawing.Size(38, 41);
            this.player1ReadyBox.TabIndex = 8;
            this.player1ReadyBox.TabStop = false;
            // 
            // player2Panel
            // 
            this.player2Panel.Controls.Add(this.player2Name);
            this.player2Panel.Controls.Add(this.player2Icon);
            this.player2Panel.Controls.Add(this.player2ReadyBox);
            this.player2Panel.Location = new System.Drawing.Point(56, 134);
            this.player2Panel.Margin = new System.Windows.Forms.Padding(2);
            this.player2Panel.Name = "player2Panel";
            this.player2Panel.Size = new System.Drawing.Size(375, 81);
            this.player2Panel.TabIndex = 6;
            this.player2Panel.Visible = false;
            // 
            // player2Name
            // 
            this.player2Name.AutoSize = true;
            this.player2Name.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2Name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player2Name.Location = new System.Drawing.Point(76, 30);
            this.player2Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player2Name.Name = "player2Name";
            this.player2Name.Size = new System.Drawing.Size(103, 23);
            this.player2Name.TabIndex = 11;
            this.player2Name.Text = "DoomerBoi";
            // 
            // player2Icon
            // 
            this.player2Icon.BackColor = System.Drawing.Color.Transparent;
            this.player2Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player2Icon.InitialImage = global::OPP.Properties.Resources.not_ready;
            this.player2Icon.Location = new System.Drawing.Point(22, 24);
            this.player2Icon.Margin = new System.Windows.Forms.Padding(0);
            this.player2Icon.Name = "player2Icon";
            this.player2Icon.Size = new System.Drawing.Size(30, 32);
            this.player2Icon.TabIndex = 10;
            this.player2Icon.TabStop = false;
            // 
            // player2ReadyBox
            // 
            this.player2ReadyBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player2ReadyBox.BackColor = System.Drawing.Color.Transparent;
            this.player2ReadyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.player2ReadyBox.Location = new System.Drawing.Point(300, 20);
            this.player2ReadyBox.Name = "player2ReadyBox";
            this.player2ReadyBox.Size = new System.Drawing.Size(38, 41);
            this.player2ReadyBox.TabIndex = 9;
            this.player2ReadyBox.TabStop = false;
            // 
            // player3Panel
            // 
            this.player3Panel.Controls.Add(this.player3Name);
            this.player3Panel.Controls.Add(this.player3Icon);
            this.player3Panel.Controls.Add(this.player3ReadyBox);
            this.player3Panel.Location = new System.Drawing.Point(56, 220);
            this.player3Panel.Margin = new System.Windows.Forms.Padding(2);
            this.player3Panel.Name = "player3Panel";
            this.player3Panel.Size = new System.Drawing.Size(375, 81);
            this.player3Panel.TabIndex = 6;
            this.player3Panel.Visible = false;
            // 
            // player3Name
            // 
            this.player3Name.AutoSize = true;
            this.player3Name.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player3Name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player3Name.Location = new System.Drawing.Point(76, 27);
            this.player3Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player3Name.Name = "player3Name";
            this.player3Name.Size = new System.Drawing.Size(103, 23);
            this.player3Name.TabIndex = 12;
            this.player3Name.Text = "DoomerBoi";
            // 
            // player3Icon
            // 
            this.player3Icon.BackColor = System.Drawing.Color.Transparent;
            this.player3Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player3Icon.InitialImage = global::OPP.Properties.Resources.not_ready;
            this.player3Icon.Location = new System.Drawing.Point(22, 24);
            this.player3Icon.Margin = new System.Windows.Forms.Padding(0);
            this.player3Icon.Name = "player3Icon";
            this.player3Icon.Size = new System.Drawing.Size(30, 32);
            this.player3Icon.TabIndex = 11;
            this.player3Icon.TabStop = false;
            // 
            // player3ReadyBox
            // 
            this.player3ReadyBox.BackColor = System.Drawing.Color.Transparent;
            this.player3ReadyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.player3ReadyBox.Location = new System.Drawing.Point(300, 20);
            this.player3ReadyBox.Name = "player3ReadyBox";
            this.player3ReadyBox.Size = new System.Drawing.Size(38, 41);
            this.player3ReadyBox.TabIndex = 10;
            this.player3ReadyBox.TabStop = false;
            // 
            // player4Panel
            // 
            this.player4Panel.Controls.Add(this.player4Name);
            this.player4Panel.Controls.Add(this.player4Icon);
            this.player4Panel.Controls.Add(this.player4ReadyBox);
            this.player4Panel.Location = new System.Drawing.Point(56, 311);
            this.player4Panel.Margin = new System.Windows.Forms.Padding(2);
            this.player4Panel.Name = "player4Panel";
            this.player4Panel.Size = new System.Drawing.Size(375, 81);
            this.player4Panel.TabIndex = 6;
            this.player4Panel.Visible = false;
            // 
            // player4Name
            // 
            this.player4Name.AutoSize = true;
            this.player4Name.Font = new System.Drawing.Font("Ink Free", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player4Name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player4Name.Location = new System.Drawing.Point(76, 28);
            this.player4Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.player4Name.Name = "player4Name";
            this.player4Name.Size = new System.Drawing.Size(103, 23);
            this.player4Name.TabIndex = 13;
            this.player4Name.Text = "DoomerBoi";
            // 
            // player4Icon
            // 
            this.player4Icon.BackColor = System.Drawing.Color.Transparent;
            this.player4Icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player4Icon.InitialImage = global::OPP.Properties.Resources.not_ready;
            this.player4Icon.Location = new System.Drawing.Point(22, 24);
            this.player4Icon.Margin = new System.Windows.Forms.Padding(0);
            this.player4Icon.Name = "player4Icon";
            this.player4Icon.Size = new System.Drawing.Size(30, 32);
            this.player4Icon.TabIndex = 12;
            this.player4Icon.TabStop = false;
            // 
            // player4ReadyBox
            // 
            this.player4ReadyBox.BackColor = System.Drawing.Color.Transparent;
            this.player4ReadyBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.player4ReadyBox.Location = new System.Drawing.Point(300, 20);
            this.player4ReadyBox.Name = "player4ReadyBox";
            this.player4ReadyBox.Size = new System.Drawing.Size(38, 41);
            this.player4ReadyBox.TabIndex = 11;
            this.player4ReadyBox.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.Controls.Add(this.button3);
            this.panel6.Location = new System.Drawing.Point(205, 410);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(86, 40);
            this.panel6.TabIndex = 7;
            this.panel6.Visible = false;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(53, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(34, 13);
            this.errorLabel.TabIndex = 8;
            this.errorLabel.Text = "Error";
            this.errorLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.BackgroundImage = global::OPP.Properties.Resources.main_menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(505, 503);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.player4Panel);
            this.Controls.Add(this.player3Panel);
            this.Controls.Add(this.player2Panel);
            this.Controls.Add(this.player1Panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PB_connectedUser);
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
            ((System.ComponentModel.ISupportInitialize)(this.PB_connectedUser)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.player1Panel.ResumeLayout(false);
            this.player1Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player1Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1ReadyBox)).EndInit();
            this.player2Panel.ResumeLayout(false);
            this.player2Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player2Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2ReadyBox)).EndInit();
            this.player3Panel.ResumeLayout(false);
            this.player3Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player3Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player3ReadyBox)).EndInit();
            this.player4Panel.ResumeLayout(false);
            this.player4Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player4Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player4ReadyBox)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel player1Panel;
        private System.Windows.Forms.Panel player2Panel;
        private System.Windows.Forms.Panel player3Panel;
        private System.Windows.Forms.Panel player4Panel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox player1ReadyBox;
        private System.Windows.Forms.PictureBox player2ReadyBox;
        private System.Windows.Forms.PictureBox player3ReadyBox;
        private System.Windows.Forms.PictureBox player4ReadyBox;
        private System.Windows.Forms.Label player1Name;
        private System.Windows.Forms.PictureBox player1Icon;
        private System.Windows.Forms.Label player2Name;
        private System.Windows.Forms.PictureBox player2Icon;
        private System.Windows.Forms.Label player3Name;
        private System.Windows.Forms.PictureBox player3Icon;
        private System.Windows.Forms.Label player4Name;
        private System.Windows.Forms.PictureBox player4Icon;
        private System.Windows.Forms.Label errorLabel;
    }
}

