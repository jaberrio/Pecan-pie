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

            serialPort1.Open();
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


                }
                catch
                {

                }
            }
            g.FillEllipse(Brushes.White, Width / 6, Height / 2, 200 + x, 200 + y);
            g.DrawString(System.DateTime.Now.ToString(), new Font(FontFamily.GenericSerif, 10), Brushes.White, 100, 100);
        }
    }
}
