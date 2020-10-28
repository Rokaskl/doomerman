using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPP
{
    public partial class Form1 : Form
    {
        Graphics screenGfx; // Graphics element in which to draw
        DrawQueue drawQueue;// Renders image elements

        SoundPlayer soundPlayer;
        bool isPlaying = false;

        Thread gfxThread;
        ThreadStart gfxThreadRef;

        static public int IDcounter = 0;

        bool pressedA, pressedW, pressedS, pressedD, pressedSpace;

        TcpClient client;

        Stopwatch lastInputWatch = new Stopwatch();   

        private Lobby lobby;

        private bool handshakeSuccessful;
        public bool HandshakeSuccessful { get => handshakeSuccessful;
            set
            {
                handshakeSuccessful = value;
                SendSignal(0, CommandTypeEnum.General);
            }
        }

        public Form1()
        {

            InitializeComponent();

            GraphicsDatabase.LoadImages();

            screenGfx = drawingArea.CreateGraphics();           
            drawQueue = new DrawQueue(screenGfx, drawingArea);

            //gfxThreadRef = new ThreadStart(drawQueue.Draw);
            //gfxThread = new Thread(gfxThreadRef);
            //gfxThread.IsBackground = true;
           
            KeyPreview = true;

            lastInputWatch.Start();

            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            KeyPress += Form1_KeyPress;


        }
       
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (lastInputWatch.Elapsed.TotalMilliseconds >= 200) 
            {
                if (pressedA)
                {
                    this.SendSignal(2, CommandTypeEnum.Arena);
                }

                if (pressedD)
                {
                    this.SendSignal(3, CommandTypeEnum.Arena);
                }

                if (pressedW)
                {
                    this.SendSignal(0, CommandTypeEnum.Arena);
                }

                if (pressedS)
                {
                    this.SendSignal(1, CommandTypeEnum.Arena);
                }

                if (pressedSpace)
                {
                    this.SendSignal(4, CommandTypeEnum.Arena);
                    pressedSpace = false;
                }


                lastInputWatch.Restart();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (ClientManager.Instance.IDIsSet())
            {
                switch (e.KeyCode)
                {

                    case Keys.A:
                        pressedA = false;
                        break;

                    case Keys.W:
                        pressedW = false;
                        break;

                    case Keys.S:
                        pressedS = false;
                        break;

                    case Keys.D:
                        pressedD = false;
                        break;

                }            
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ClientManager.Instance.IDIsSet())
            {
                switch (e.KeyCode)
                {

                    case Keys.A:
                        pressedA = true;
                        break;

                    case Keys.W:
                        pressedW = true;
                        break;

                    case Keys.S:
                        pressedS = true;
                        break;

                    case Keys.D:
                        pressedD = true;
                        break;

                    case Keys.Space:
                        pressedSpace = true;
                        break;

                }
            }
        }

        private void btPlay_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
           

        }
       

     

    
        private void btQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btToggleSound_Click(object sender, EventArgs e)
        {
            if (File.Exists(soundPlayer.SoundLocation))
            {
                if (isPlaying)
                {
                    soundPlayer.Stop();
                    isPlaying = false;
                }
                else
                {
                    soundPlayer.Play();
                    isPlaying = true;
                }
                drawingArea.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            text = "127.0.0.1:13000";
            if (Regex.IsMatch(text, @"[0-9]+(?:\.[0-9]+){3}:[0-9]+"))  //Check IP:PORT pattern
            {
                string[] array = text.Split(':');
                string ip = array[0];
                Int32 port = Int32.Parse(array[1]);
                ConnectClient(ip, port);
                SendSignal(0, CommandTypeEnum.General);

            }
        }
        public void ShowGame()
        {
            // Hide all Lobby panels
            for (int i = 1; i < 5;i ++) 
            {
                showPlayerLobby(i, false, false, "");
            }
          
            panel6.Visible = false; // Hide Ready button panel
            drawingArea.Focus();


            Task.Run(() =>
            {
            while (true)
            {
                if (ClientManager.Instance.IDIsSet())
                {
                    if (PB_connectedUser.InvokeRequired)
                    {
                        PB_connectedUser.Invoke(new MethodInvoker(delegate { SetConnectedPlayerIcon(ClientManager.Instance.GetPlayerID());}));
                    }
                     else    
                     {
                        SetConnectedPlayerIcon(ClientManager.Instance.GetPlayerID());
                     }            
                        break;
                    }
                    Thread.Sleep(10);
                }
            });
            /*if (!gfxThread.IsAlive)
            {
                gfxThread.Start();
            }*/
        }
        private void CreateLobby()
        {
            this.lobby = new Lobby(this);

            panelMenu.Hide();
            panel1.Visible = false;
            drawingArea.Focus();
            drawingArea.Image = Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/MenuBackground.png");

            

            panel6.Visible = true;//Ready button panel
        }

        public void UpdateLobby(LobbyData lobbyData)
        {
            if(this.lobby == null)
            {
                this.CreateLobby();
            }
            this.lobby.UpdateLobby(lobbyData);
        }

        public void showPlayerLobby(int id,bool show, bool ready,string  name)
        {

            Panel playerPanel = player1Panel; // First player(id =1 ) panel 
            PictureBox playerReadyBox = player1ReadyBox; // First player(id =1 ) ready image box
            Label playerName = player1Name; // First player(id =1 ) name label 
            PictureBox playerIconBox = player1Icon; // First player(id =1 ) icon box
            Image playerIcon = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\p1_icon.png");

            switch (id)
            {
                case 1:
                    playerPanel = player1Panel;
                    playerReadyBox = player1ReadyBox;
                    playerName = player1Name;
                    playerIconBox = player1Icon;

                    playerIcon = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\p1_icon.png");
                    playerIconBox.Image = playerIcon;
                    playerIconBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    break;
                case 2:
                    playerPanel = player2Panel;
                    playerReadyBox = player2ReadyBox;
                    playerName = player2Name;
                    playerIconBox = player2Icon;

                    playerIcon = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\p2_icon.png");
                    playerIconBox.Image = playerIcon;
                    playerIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 3:
                    playerPanel = player3Panel;
                    playerReadyBox = player3ReadyBox;
                    playerName = player3Name;
                    playerIconBox = player3Icon;

                    playerIcon = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\p3_icon.png");
                    playerIconBox.Image = playerIcon;
                    playerIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
                case 4:
                    playerPanel = player4Panel;
                    playerReadyBox = player4ReadyBox;
                    playerName = player4Name;
                    playerIconBox = player4Icon;

                    playerIcon = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\p4_icon.png");
                    playerIconBox.Image = playerIcon;
                    playerIconBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
            playerPanel.Visible = show;
            playerName.Text = name;
           
            if (!ready)
            {
                Image notReadyImage = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\not_ready.png");
                playerReadyBox.Image = notReadyImage;
                playerReadyBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Image readyImage = new Bitmap(ClientManager.Instance.ProjectPath + "\\Resources\\ready.png");
                playerReadyBox.Image = readyImage;
                playerReadyBox.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.lobby.ToggleReady();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(ClientManager.Instance.ProjectPath + "\\Resources\\music.wav");
            //soundPlayer.PlayLooping();
            //soundPlayer.Stop();
            isPlaying = false;
        }

        public async void SendSignal(int actionNum, CommandTypeEnum commandType)
        {
            byte[] buffer;

            int idToSend = ClientManager.Instance.IDIsSet() ? ClientManager.Instance.GetPlayerID() : 0;

            buffer = (new List<int> { (int)commandType, idToSend, actionNum }).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            

            while (true)
            {
                await Task.Delay(10);
                try
                {
                    if (client.GetStream().CanWrite)
                    {
                        client.GetStream().Write(buffer, 0, buffer.Length);
                        break;
                    }
                }
                catch (Exception exception)
                {
                    break;
                }
            }
        }

        public void ConnectClient(string ip, Int32 port)
        {
         
            client = new TcpClient(ip, port);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Listener serverListener = new Listener(client, this);

            }).Start();
        }

        public void SetConnectedPlayerIcon(int ID)
        {
            Graphics graphics = PB_connectedUser.CreateGraphics();
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            switch (ID)
            {
                
                case 0:
                    graphics.DrawImage(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\p1_icon.png")), 0, 0, 30, 30);
                    break;

                case 1:
                    graphics.DrawImage(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\p2_icon.png")), 0, 0, 30, 30);
                    break;

                case 2:
                    graphics.DrawImage(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\p3_icon.png")), 0, 0, 30, 30);
                    break;

                case 3:
                    graphics.DrawImage(Image.FromFile(Path.Combine(ClientManager.Instance.ProjectPath, "Resources\\p4_icon.png")), 0, 0, 30, 30);
                    break;
                   
            }
        }

        
    }

    public enum CommandTypeEnum
    {
        General,
        Arena
    }
}
