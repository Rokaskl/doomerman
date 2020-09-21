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
            panelMenu.Hide();
            ConnectClient();
            SendSignal(0);

            drawingArea.Image = Image.FromFile(ClientManager.Instance.ProjectPath + "/Resources/Background.png");

            if (!gfxThread.IsAlive)
                gfxThread.Start();

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
            }
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

        public void ConnectClient()
        {
            Int32 port = 13000;
            string ip = "127.0.0.1";
            client = new TcpClient(ip, port);

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Listener serverListener = new Listener(client);

            }).Start();
        }

        
    }
}
