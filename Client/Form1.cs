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
        Graphics screenGfx;
        DrawQueue drawQueue;

        Image currentImage;
        Thread gfxThread;
        ThreadStart gfxThreadRef;

        static public int IDcounter = 0;

        bool pressedA, pressedW, pressedS, pressedD;

        TcpClient client;
        int Id;

        public Form1()
        {
            InitializeComponent();

            client = new TcpClient("localhost", 13000);
            Id = 1;

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
            Entity entity;

            int xDiff = 0;
            int yDiff = 0;

            if (pressedA)
            {
                xDiff -= 10;
                this.SendSignal(3);
            }
               
            if (pressedD)
            {
                xDiff += 10;
                this.SendSignal(2);
            }
                
            if (pressedW)
            {
                yDiff -= 10;
                this.SendSignal(0);
            }
                
            if (pressedS)
            {
                yDiff += 10;
                this.SendSignal(1);
            }
                

            // Let's get critical NOT SAFE FOR MULTITHREADING
            if (drawQueue.ContainsKey(0))
            {
                entity = drawQueue.GetEntity(0);
                entity.sprite.pointPosition = new Point(entity.sprite.pointPosition.X + xDiff, entity.sprite.pointPosition.Y + yDiff);
            }
 
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (drawQueue.count != 0)
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
            if (drawQueue.count != 0)
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
                currentImage = Image.FromFile(f.FileName);
            }
        }

        private void btAddSprite_Click(object sender, EventArgs e)
        {
            lock (drawQueue._spriteLock)
            {
                Entity entity;
                Sprite sprite = new Sprite(currentImage, int.Parse(textBoxLayer.Text), new Point(int.Parse(textBoxX.Text), int.Parse(textBoxY.Text)));
                entity = new Entity(sprite, sprite.pointPosition);
                drawQueue.AddEntity(entity);
            }
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
            buffer = (new List<int> { 0, this.Id, actionNum }).SelectMany(x => BitConverter.GetBytes(x)).ToArray();
            

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
