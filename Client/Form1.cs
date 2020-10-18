using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private PictureBox pb;

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

            pb = new PictureBox();
            panel1.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;


        }
        private void Blur()
        {
            Bitmap bmp = Screenshot.TakeSnapshot(panel1);
            BitmapFilter.GaussianBlur(bmp, 4);

            pb.Image = bmp;
            pb.BringToFront();
        }

        private void UnBlur()
        {
            pb.Image = null;
            pb.SendToBack();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
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
        public class BitmapFilter
        {
            private static bool Conv3x3(Bitmap b, ConvMatrix m)
            {
                // Avoid divide by zero errors
                if (0 == m.Factor) return false;

                Bitmap bSrc = (Bitmap)b.Clone();

                // GDI+ still lies to us - the return format is BGR, NOT RGB.
                BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int stride = bmData.Stride;
                int stride2 = stride * 2;
                System.IntPtr Scan0 = bmData.Scan0;
                System.IntPtr SrcScan0 = bmSrc.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)Scan0;
                    byte* pSrc = (byte*)(void*)SrcScan0;

                    int nOffset = stride + 6 - b.Width * 3;
                    int nWidth = b.Width - 2;
                    int nHeight = b.Height - 2;

                    int nPixel;

                    for (int y = 0; y < nHeight; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            nPixel = ((((pSrc[2] * m.TopLeft) + (pSrc[5] * m.TopMid) + (pSrc[8] * m.TopRight) +
                                (pSrc[2 + stride] * m.MidLeft) + (pSrc[5 + stride] * m.Pixel) + (pSrc[8 + stride] * m.MidRight) +
                                (pSrc[2 + stride2] * m.BottomLeft) + (pSrc[5 + stride2] * m.BottomMid) + (pSrc[8 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;

                            p[5 + stride] = (byte)nPixel;

                            nPixel = ((((pSrc[1] * m.TopLeft) + (pSrc[4] * m.TopMid) + (pSrc[7] * m.TopRight) +
                                (pSrc[1 + stride] * m.MidLeft) + (pSrc[4 + stride] * m.Pixel) + (pSrc[7 + stride] * m.MidRight) +
                                (pSrc[1 + stride2] * m.BottomLeft) + (pSrc[4 + stride2] * m.BottomMid) + (pSrc[7 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;

                            p[4 + stride] = (byte)nPixel;

                            nPixel = ((((pSrc[0] * m.TopLeft) + (pSrc[3] * m.TopMid) + (pSrc[6] * m.TopRight) +
                                (pSrc[0 + stride] * m.MidLeft) + (pSrc[3 + stride] * m.Pixel) + (pSrc[6 + stride] * m.MidRight) +
                                (pSrc[0 + stride2] * m.BottomLeft) + (pSrc[3 + stride2] * m.BottomMid) + (pSrc[6 + stride2] * m.BottomRight)) / m.Factor) + m.Offset);

                            if (nPixel < 0) nPixel = 0;
                            if (nPixel > 255) nPixel = 255;

                            p[3 + stride] = (byte)nPixel;

                            p += 3;
                            pSrc += 3;
                        }

                        p += nOffset;
                        pSrc += nOffset;
                    }
                }

                b.UnlockBits(bmData);
                bSrc.UnlockBits(bmSrc);

                return true;
            }

            public static bool GaussianBlur(Bitmap b, int nWeight /* default to 4*/)
            {
                ConvMatrix m = new ConvMatrix();
                m.SetAll(1);
                m.Pixel = nWeight;
                m.TopMid = m.MidLeft = m.MidRight = m.BottomMid = 2;
                m.Factor = nWeight + 12;

                return BitmapFilter.Conv3x3(b, m);
            }

            public class ConvMatrix
            {
                public int TopLeft = 0, TopMid = 0, TopRight = 0;
                public int MidLeft = 0, Pixel = 1, MidRight = 0;
                public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
                public int Factor = 1;
                public int Offset = 0;
                public void SetAll(int nVal)
                {
                    TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = nVal;
                }
            }
        }

        class Screenshot
        {
            public static Bitmap TakeSnapshot(Control ctl)
            {
                Bitmap bmp = new Bitmap(ctl.Size.Width, ctl.Size.Height);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp);
                g.CopyFromScreen(ctl.PointToScreen(ctl.ClientRectangle.Location), new Point(0, 0), ctl.ClientRectangle.Size);
                return bmp;
            }
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
            if (Regex.IsMatch(text, @"[0-9]+(?:\.[0-9]+){3}:[0-9]+"))  //Check IP:PORT pattern
            {
                string[] array = text.Split(':');
                string ip = array[0];
                Int32 port = Int32.Parse(array[1]);
                panelMenu.Hide();
                panel1.Visible = false;
                drawingArea.Focus();
                ConnectClient(ip, port);
                SendSignal(0, CommandTypeEnum.General);

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

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(ClientManager.Instance.ProjectPath + "\\Resources\\music.wav");
            soundPlayer.PlayLooping();
            isPlaying = true;
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

        public void ConnectClient(string ip, Int32 port)
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

    public enum CommandTypeEnum
    {
        General,
        Arena
    }
}
