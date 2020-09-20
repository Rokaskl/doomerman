using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        Thread gfxThread;
        ThreadStart gfxThreadRef;

        static public int IDcounter = 0;

        bool pressedA, pressedW, pressedS, pressedD, pressedSpace;

        TcpClient client;

        public Form1(TcpClient client)
        {
            InitializeComponent();

            this.client = client;
            ClientManager.Instance.SetPlayerID(1);


            screenGfx = drawingArea.CreateGraphics();           
            drawQueue = new DrawQueue(screenGfx, drawingArea);

            gfxThreadRef = new ThreadStart(drawQueue.Draw);
            gfxThread = new Thread(gfxThreadRef);
            gfxThread.IsBackground = true;

            if (!gfxThread.IsAlive)
                gfxThread.Start();

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
            if (ClientManager.Instance.GetPlayerID() >= 0)
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
            if (ClientManager.Instance.GetPlayerID() >= 0)
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

        private void btDraw_Click(object sender, EventArgs e)
        {
            if (!gfxThread.IsAlive)    
                gfxThread.Start();
                  
        }

        private void btLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";

            if (f.ShowDialog() == DialogResult.OK)
            {
                //currentImage = Image.FromFile(f.FileName);
            }
        }

        private void btAddSprite_Click(object sender, EventArgs e)
        {
            lock (drawQueue._spriteLock)
            {
                
            }
        }

        private void drawingArea_Click(object sender, EventArgs e)
        {

        }

        private void btStopDraw_Click(object sender, EventArgs e)
        {
            drawQueue.draw = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }

        public async void SendSignal(int actionNum)
        {
            byte[] buffer;
            buffer = (new List<int> { 0, ClientManager.Instance.GetPlayerID(), actionNum }).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            

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
    }
}
