using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using BoundData;

namespace FinalProject_105323068
{
    public partial class Form1 : Form
    {


        public int Speed = 10;
        public Point LU, RL;
        bool Tim2Type, Tim3Type, Tim4Type, Tim5Type;
        public int time2, time3, time4, time5;
        public int Trigger2, Trigger3, Trigger4, Trigger5;
        PictureBox[] Left = new PictureBox[3];
        PictureBox[] Right = new PictureBox[3];
        PictureBox[] Up = new PictureBox[3];
        PictureBox[] Down = new PictureBox[3];
        int PointCount = 0, time = 128;
        bool LH1 = false, RH1 = false, UH1 = false, DH1 = false;
        bool LH2 = false, RH2 = false, UH2 = false, DH2 = false;
        enum Direction { Up, Left, Right, Down };
        public Form1()
        {
            InitializeComponent();
        }
        private Graphics g;
        private DrawBoundData CurrentBoundData;

        private void Form1_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"D:\Desktop\FinalProject_105323068 按按鍵\music\百鬼夜行.mp3";
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            axWindowsMediaPlayer1.Visible = false;

            g = panel1.CreateGraphics();
            CurrentBoundData = new DrawBoundData(g);
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            //敲擊方塊
            pictureBox1.Location = new Point(260, 682); //上
            pictureBox21.Location = new Point(260, 612);
            pictureBox25.Location = new Point(260, 612);

            pictureBox2.Location = new Point(390, 682); //下
            pictureBox22.Location = new Point(390, 612);
            pictureBox26.Location = new Point(390, 612);

            pictureBox3.Location = new Point(530, 682); //右
            pictureBox23.Location = new Point(530, 612);
            pictureBox27.Location = new Point(530, 612);

            pictureBox4.Location = new Point(120, 682); //左
            pictureBox24.Location = new Point(120, 612);
            pictureBox28.Location = new Point(120, 612);

            //敲擊方塊
            //移動方塊
            pictureBox5.Location = new Point(260, 25);
            pictureBox10.Location = new Point(260, 25);
            pictureBox14.Location = new Point(260, 25);

            pictureBox6.Location = new Point(390, 25);
            pictureBox11.Location = new Point(390, 25);
            pictureBox15.Location = new Point(390, 25);

            pictureBox7.Location = new Point(530, 25);
            pictureBox12.Location = new Point(530, 25);
            pictureBox16.Location = new Point(530, 25);

            pictureBox8.Location = new Point(120, 25);
            pictureBox9.Location = new Point(120, 25);
            pictureBox13.Location = new Point(120, 25);

            //Hit 方塊 location
            pictureBox21.Location = new Point(120, 682 - pictureBox21.Height);
            pictureBox22.Location = new Point(260, 682 - pictureBox22.Height);
            pictureBox23.Location = new Point(390, 682 - pictureBox23.Height);
            pictureBox24.Location = new Point(530, 682 - pictureBox24.Height);
            //Miss 方塊 location
            pictureBox25.Location = new Point(120, 682 - pictureBox21.Height);
            pictureBox26.Location = new Point(260, 682 - pictureBox22.Height);
            pictureBox27.Location = new Point(390, 682 - pictureBox23.Height);
            pictureBox28.Location = new Point(530, 682 - pictureBox24.Height);
            //
            Left[0] = pictureBox8;
            Left[1] = pictureBox9;
            Left[2] = pictureBox13;

            Right[0] = pictureBox7;
            Right[1] = pictureBox12;
            Right[2] = pictureBox16;

            Up[0] = pictureBox5;
            Up[1] = pictureBox10;
            Up[2] = pictureBox14;

            Down[0] = pictureBox6;
            Down[1] = pictureBox11;
            Down[2] = pictureBox15;
            //
            //移動方塊
            g.Clear(BackColor);
            panel1_Paint(sender, null);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    LeftHit();
                    break;
                case Keys.Right:
                    RightHit();
                    break;
                case Keys.Up:
                    UpHit();
                    break;
                case Keys.Down:
                    DownHit();
                    break;
                case Keys.R:
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                    pictureBox4.Visible = true;
                    textBox1.Enabled = true;
                    textBox1.Visible = true;
                    button1.Enabled = true;
                    pictureBox21.Visible = false;
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = false;
                    pictureBox25.Visible = false;
                    pictureBox26.Visible = false;
                    pictureBox27.Visible = false;
                    pictureBox28.Visible = false;
                    timer1.Stop();
                    timer6.Stop();
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                    time = 128;
                    break;
                case Keys.S:
                    PointCount = 0;
                    LU = new Point();
                    RL = new Point();
                    LU = CurrentBoundData.LU;
                    RL = CurrentBoundData.RL;
                    Tim2Type = false;
                    Tim3Type = false;
                    Tim4Type = false;
                    Tim5Type = false;
                    time2 = 0; time3 = 0; time4 = 0; time5 = 0;
                    Trigger2 = 0; Trigger3 = 0; Trigger4 = 0; Trigger5 = 0;
                    timer1.Start();
                    timer6.Start();
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    time = 128;
                    break;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            CurrentBoundData.DrawBound();
            label2.Text = "分數" + PointCount;
            label3.Text = "時間" + time + "秒";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //讀取輸入的速度，判斷並取代
            int ConSpeed;
            bool result = Int32.TryParse(textBox1.Text.ToString(), out ConSpeed);
            if (result)
            {
                Speed = ConSpeed;
            }
            textBox1.Enabled = false;
            textBox1.Visible = false;
            button1.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //最大控制權 四種方向
            if (time == 0)
            {
                timer1.Stop();
                timer6.Stop();
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                if (PointCount > 0)
                {
                    MessageBox.Show("Good job", "Point", MessageBoxButtons.OK);
                }
                else if (PointCount < 0)
                {
                    MessageBox.Show("不會玩遊戲!?", "Point", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("雷喔", "Point", MessageBoxButtons.OK);
            }
            Random rnd = new Random();
            int rndnum = rnd.Next(100, 800); //每0.5~1秒之間送出
            timer1.Interval = rndnum;
            rndnum = rndnum % 4;
            if (rndnum == 0 && Tim2Type == false && time != 0)
            {
                if (pictureBox8.Visible == false)
                {
                    pictureBox8.Visible = true;
                }
                else if (pictureBox9.Visible == false)
                {
                    pictureBox9.Visible = true;
                }
                else if (pictureBox13.Visible == false)
                {
                    pictureBox13.Visible = true;
                }
                timer2.Start();
            }
            else if (rndnum == 1 && Tim3Type == false && time != 0)
            {
                if (pictureBox5.Visible == false)
                {
                    pictureBox5.Visible = true;
                }
                else if (pictureBox10.Visible == false)
                {
                    pictureBox10.Visible = true;
                }
                else if (pictureBox14.Visible == false)
                {
                    pictureBox14.Visible = true;
                }
                timer3.Start();
            }
            else if (rndnum == 2 && Tim4Type == false && time != 0)
            {
                if (pictureBox6.Visible == false)
                {
                    pictureBox6.Visible = true;
                }
                else if (pictureBox11.Visible == false)
                {
                    pictureBox11.Visible = true;
                }
                else if (pictureBox15.Visible == false)
                {
                    pictureBox15.Visible = true;
                }
                timer4.Start();
            }
            else if (rndnum == 3 && Tim5Type == false && time != 0)
            {
                if (pictureBox7.Visible == false)
                {
                    pictureBox7.Visible = true;
                }
                else if (pictureBox12.Visible == false)
                {
                    pictureBox12.Visible = true;
                }
                else if (pictureBox16.Visible == false)
                {
                    pictureBox16.Visible = true;
                }
                timer5.Start();
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        { //Left
            if (pictureBox8.Visible == true
             && pictureBox9.Visible == true
             && pictureBox13.Visible == true)
            {
                pictureBox8.Top += Speed;
                pictureBox9.Top += Speed;
                pictureBox13.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        Tim2Type = false;
                        PointCount--;
                    }
                }
            }
            else if (pictureBox8.Visible == true
                 && pictureBox9.Visible == true)
            {
                pictureBox8.Top += Speed;
                pictureBox9.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox9.Visible == true
                 && pictureBox13.Visible == true)
            {
                pictureBox9.Top += Speed;
                pictureBox13.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox8.Visible == true
                 && pictureBox13.Visible == true)
            {
                pictureBox8.Top += Speed;
                pictureBox13.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox8.Visible == true)
            {
                pictureBox8.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox9.Visible == true)
            {
                pictureBox9.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox13.Visible == true)
            {
                pictureBox13.Top += Speed;
                for (int i = 0; i < Left.Count(); i++)
                {
                    if (Left[i].Location.Y > RL.Y)
                    {
                        LH2 = true;
                        pictureBox25.Visible = true;
                        timer7.Start();
                        Left[i].Visible = false;
                        Left[i].Location = new Point(120, 25);
                        PointCount--;
                    }
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        { //Up
            if (pictureBox5.Visible == true
             && pictureBox10.Visible == true
             && pictureBox14.Visible == true)
            {
                pictureBox5.Top += Speed;
                pictureBox10.Top += Speed;
                pictureBox14.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        Tim3Type = false;
                        PointCount--;
                    }
                }
            }
            else if (pictureBox5.Visible == true
                 && pictureBox10.Visible == true)
            {
                pictureBox5.Top += Speed;
                pictureBox10.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox10.Visible == true
                 && pictureBox14.Visible == true)
            {
                pictureBox10.Top += Speed;
                pictureBox14.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox5.Visible == true
                 && pictureBox14.Visible == true)
            {
                pictureBox5.Top += Speed;
                pictureBox14.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox5.Visible == true)
            {
                pictureBox5.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox10.Visible == true)
            {
                pictureBox10.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox14.Visible == true)
            {
                pictureBox14.Top += Speed;
                for (int i = 0; i < Up.Count(); i++)
                {
                    if (Up[i].Location.Y > RL.Y)
                    {
                        UH2 = true;
                        pictureBox26.Visible = true;
                        timer7.Start();
                        Up[i].Visible = false;
                        Up[i].Location = new Point(260, 25);
                        PointCount--;
                    }
                }
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            // Down
            if (pictureBox6.Visible == true
             && pictureBox11.Visible == true
             && pictureBox15.Visible == true)
            {
                pictureBox6.Top += Speed;
                pictureBox11.Top += Speed;
                pictureBox15.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                        Tim4Type = false;
                    }
                }
            }
            else if (pictureBox6.Visible == true
                 && pictureBox11.Visible == true)
            {
                pictureBox6.Top += Speed;
                pictureBox11.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox11.Visible == true
                 && pictureBox15.Visible == true)
            {
                pictureBox11.Top += Speed;
                pictureBox15.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox6.Visible == true
                 && pictureBox15.Visible == true)
            {
                pictureBox6.Top += Speed;
                pictureBox15.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox6.Visible == true)
            {
                pictureBox6.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox11.Visible == true)
            {
                pictureBox11.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox15.Visible == true)
            {
                pictureBox15.Top += Speed;
                for (int i = 0; i < Down.Count(); i++)
                {
                    if (Down[i].Location.Y > RL.Y)
                    {
                        DH2 = true;
                        pictureBox27.Visible = true;
                        timer7.Start();
                        Down[i].Visible = false;
                        Down[i].Location = new Point(390, 25);
                        PointCount--;
                    }
                }
            }
        }
        private void timer5_Tick(object sender, EventArgs e)
        { // Right
            if (pictureBox7.Visible == true
             && pictureBox12.Visible == true
             && pictureBox16.Visible == true)
            {
                pictureBox7.Top += Speed;
                pictureBox12.Top += Speed;
                pictureBox16.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        Tim5Type = false;
                        PointCount--;
                    }
                }
            }
            else if (pictureBox7.Visible == true
                 && pictureBox12.Visible == true)
            {
                pictureBox7.Top += Speed;
                pictureBox12.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox12.Visible == true
                 && pictureBox16.Visible == true)
            {
                pictureBox12.Top += Speed;
                pictureBox16.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox7.Visible == true
                 && pictureBox16.Visible == true)
            {
                pictureBox7.Top += Speed;
                pictureBox16.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox7.Visible == true)
            {
                pictureBox7.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox12.Visible == true)
            {
                pictureBox12.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
            else if (pictureBox16.Visible == true)
            {
                pictureBox16.Top += Speed;
                for (int i = 0; i < Right.Count(); i++)
                {
                    if (Right[i].Location.Y > RL.Y)
                    {
                        RH2 = true;
                        pictureBox28.Visible = true;
                        timer7.Start();
                        Right[i].Visible = false;
                        Right[i].Location = new Point(530, 25);
                        PointCount--;
                    }
                }
            }
        }
        private void timer6_Tick(object sender, EventArgs e)
        {
            //倒數計時
            int CountDown = 1;
            time = time - CountDown;
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            //控制Hit 與 Miss顯示
            timer7.Interval = 100;
            if (LH1 == true)
            {
                pictureBox21.Visible = false;
                LH1 = false;
            }
            else if (UH1 == true)
            {
                pictureBox22.Visible = false;
                UH1 = false;
            }
            else if (DH1 == true)
            {
                pictureBox23.Visible = false;
                DH1 = false;
            }
            else if (RH1 == true)
            {
                pictureBox24.Visible = false;
                RH1 = false;
            }
            else if (LH2 == true)
            {
                pictureBox25.Visible = false;
                LH2 = false;
            }
            else if (UH2 == true)
            {
                pictureBox26.Visible = false;
                UH2 = false;
            }
            else if (DH2 == true)
            {
                pictureBox27.Visible = false;
                DH2 = false;
            }
            else if (RH2 == true)
            {
                pictureBox28.Visible = false;
                RH2 = false;
            }
        }
        public int BlockSpeed
        {
            get { return Speed; }
            set
            {
                Speed = value;
                if (value > 30)
                {
                    Speed = 30;
                }
                else if (value < 5)
                {
                    Speed = 5;
                }
            }
        }
        public void LeftHit()
        {
            for (int i = 0; i < Left.Count(); i++)
            {
                if (Left[i].Location.Y + Left[i].Height > pictureBox4.Location.Y || (Left[i].Location.Y < pictureBox4.Location.Y + pictureBox4.Height
                                                                                  && Left[i].Location.Y > pictureBox4.Location.Y))
                {
                    //                     WMPLib.WindowsMediaPlayer wplayerLeft = new WMPLib.WindowsMediaPlayer();
                    //                     wplayerLeft.URL = @"D:\Desktop\FinalProject_105323068 按按鍵\music/低音1.mp3";
                    //                     wplayerLeft.controls.play();
                    LH1 = true;
                    pictureBox21.Visible = true;
                    timer7.Start();
                    Tim2Type = false;
                    Left[i].Visible = false;
                    Left[i].Location = new Point(120, 25);
                    PointCount++;
                }
            }
        }
        public void UpHit()
        {
            for (int i = 0; i < Up.Count(); i++)
            {
                if (Up[i].Location.Y + Up[i].Height > pictureBox1.Location.Y || (Up[i].Location.Y < pictureBox1.Location.Y + pictureBox1.Height
                                                                              && Up[i].Location.Y > pictureBox1.Location.Y))
                {
                    //                     WMPLib.WindowsMediaPlayer wplayerUp = new WMPLib.WindowsMediaPlayer();
                    //                     wplayerUp.URL = @"D:\Desktop\FinalProject_105323068 按按鍵\music\低音1.mp3";
                    //                     wplayerUp.controls.play();
                    UH1 = true;
                    pictureBox22.Visible = true;
                    timer7.Start();
                    Tim3Type = false;
                    Up[i].Visible = false;
                    Up[i].Location = new Point(260, 25);
                    PointCount++;
                }
            }
        }
        public void DownHit()
        {
            for (int i = 0; i < Down.Count(); i++)
            {
                if (Down[i].Location.Y + Down[i].Height > pictureBox2.Location.Y || (Down[i].Location.Y < pictureBox2.Location.Y + pictureBox2.Height
                                                                                  && Down[i].Location.Y > pictureBox2.Location.Y))
                {
                    //                     WMPLib.WindowsMediaPlayer wplayerDown = new WMPLib.WindowsMediaPlayer();
                    //                     wplayerDown.URL = @"D:\Desktop\FinalProject_105323068 按按鍵\music\低音1.mp3";
                    //                     wplayerDown.controls.play();
                    DH1 = true;
                    pictureBox23.Visible = true;
                    timer7.Start();
                    Tim4Type = false;
                    Down[i].Visible = false;
                    Down[i].Location = new Point(390, 25);
                    PointCount++;
                }
            }
        }
        public void RightHit()
        {
            for (int i = 0; i < Right.Count(); i++)
            {
                if (Right[i].Location.Y + Right[i].Height > pictureBox3.Location.Y || (Right[i].Location.Y < pictureBox3.Location.Y + pictureBox3.Height
                                                                                    && Right[i].Location.Y > pictureBox3.Location.Y))
                {
                    //                     WMPLib.WindowsMediaPlayer wplayerRight = new WMPLib.WindowsMediaPlayer();
                    //                     wplayerRight.URL = @"D:\Desktop\FinalProject_105323068 按按鍵\music\低音1.mp3";
                    //                     wplayerRight.controls.play();
                    RH1 = true;
                    pictureBox24.Visible = true;
                    timer7.Start();
                    Tim5Type = false;
                    Right[i].Visible = false;
                    Right[i].Location = new Point(530, 25);
                    PointCount++;
                }
            }
        }
    }
}