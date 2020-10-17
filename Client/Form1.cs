using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Form1()
        {
            InitializeComponent();           

            screenGfx = drawingArea.CreateGraphics();           
            drawQueue = new DrawQueue(screenGfx, drawingArea);

            gfxThreadRef = new ThreadStart(drawQueue.Draw);
            gfxThread = new Thread(gfxThreadRef);
            gfxThread.IsBackground = true;
           
            KeyPreview = true;

            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            KeyPress += Form1_KeyPress;
            
            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (pressedA)
            {
                this.SendSignal(2);
            }
               
            if (pressedD)
            {
                this.SendSignal(3);
            }
                
            if (pressedW)
            {
                this.SendSignal(0);
            }
                
            if (pressedS)
            {
                this.SendSignal(1);
            }

            if (pressedSpace)
            {
                this.SendSignal(4);
                pressedSpace = false;
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

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            if(Regex.IsMatch(text, @"[0-9]+(?:\.[0-9]+){3}:[0-9]+")); //Check IP:PORT pattern
            {
                string[] array = text.Split(':');
                string ip = array[0];
                Int32 port = Int32.Parse(array[1]);
                panelMenu.Hide();
                panel1.Visible = false;
                drawingArea.Focus();
                ConnectClient(port,ip);
                SendSignal(0);

                drawingArea.Image = Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/Background.png");

                Task.Run(() =>
                {
                    while (true)
                    {
                        if (ClientManager.Instance.IDIsSet())
                        {
                            SetConnectedPlayerIcon(ClientManager.Instance.GetPlayerID());
                            break;
                        }
                        Thread.Sleep(10);
                    }
                });




                if (!gfxThread.IsAlive)
                    gfxThread.Start();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(ClientManager.Instance.ProjectPath + "\\Resources\\music.wav");
            soundPlayer.PlayLooping();
            isPlaying = true;
        }

        public async void SendSignal(int actionNum)
        {
            byte[] buffer;

            int idToSend = ClientManager.Instance.IDIsSet() ? ClientManager.Instance.GetPlayerID() : 0;

            buffer = (new List<int> { 0, idToSend, actionNum }).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            

            while (true)
            {
                await Task.Delay(10);
                try
                {
                    if (client.GetStream().CanWrite)
                    {
                        Console.WriteLine(actionNum.ToString());
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

        public void ConnectClient(Int32 port, string ip)
        {
           

            client = new TcpClient(ip, port);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Listener serverListener = new Listener(client);

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
}
