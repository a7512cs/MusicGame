using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace BoundData
{
        class DrawBoundData
        {
        public int BWidth = 0;
        public Point LU, RL;
        private Graphics g;
        public DrawBoundData(Graphics gIn)
        {
            g = gIn; 
        }
        public void DrawBound()
        {
            LU.X = 100;
            LU.Y = 20;
            RL.X = 650;
            RL.Y = 780;
            BWidth = 10;
            int LineWidth = (RL.X - LU.X) / 4;
            Pen pen = new Pen(Color.Red, BWidth);
            g.DrawLine(pen, LU.X, LU.Y, RL.X, LU.Y);
            g.DrawLine(pen, LU.X + (BWidth / 2), LU.Y, LU.X + (BWidth / 2), RL.Y);
            g.DrawLine(pen, RL.X - (BWidth / 2), LU.Y, RL.X - (BWidth / 2), RL.Y);
            g.DrawLine(pen, LU.X + LineWidth, LU.Y, LU.X + LineWidth, RL.Y);
            g.DrawLine(pen, LU.X + (2 * LineWidth), LU.Y, LU.X + (2 * LineWidth), RL.Y);
            g.DrawLine(pen, LU.X + (3 * LineWidth), LU.Y, LU.X + (3 * LineWidth), RL.Y);
        }
    }
}
