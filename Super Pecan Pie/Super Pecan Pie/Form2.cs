using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Pecan_Pie
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            try
            {
                serialPort1.Open();
            }
            catch { Console.Write("Input device not connected"); } 
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void Form2_RegionChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x=0;
            int y=0;
            string a = "";
            g.Clear(Color.Black);
             
            if (serialPort1.IsOpen)
            {
                try
                {
                    a = serialPort1.ReadLine();
                    x = int.Parse(a.Split(' ')[0]);
                    y = int.Parse(a.Split(' ')[1]);
                } catch { }
            }
            g.FillEllipse(Brushes.White,(Width / 12),Height - (Height / 4), 100, 100);
            g.DrawString(System.DateTime.Now.ToString(), new Font(FontFamily.GenericSerif, 15), Brushes.White, 50, 50);
        }
    }
}
