using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Pecan_Pie
{
    public static class CircleButton
    {
        public static int x, y;
        public static int state = 3;
        public static bool trig;
        static DateTime now = DateTime.Now;
        static DateTime pre = DateTime.Now;

        static Font f = new Font(FontFamily.GenericSerif, 18, FontStyle.Bold);

        
        static CircleButton()
        {
        }


        public static void draw(Graphics g, Control c, int joyX, int joyY)
        {
            if (joyX != 0 || joyY != 0)
            {
                if (DateTime.Now.Subtract(pre).TotalMilliseconds > 300)
                {
                    pre = DateTime.Now.AddSeconds(2);
                    //Left 
                    if (joyX > 256)
                    {
                        Console.WriteLine("JOYX > 256");
                        state = 0;
                    }
                    //Right
                    if (joyX < -256)
                    {
                        Console.WriteLine("JOYX < -256");
                        state = 2;
                    }

                    //Up
                    if (joyY > 256)
                    {
                        Console.WriteLine("JOYY > 256");
                        state = 1;
                    }
                    //Down
                    if (joyY < -256)
                    {
                        Console.WriteLine("JOYY < =256");
                        //CAPTURE AND RETURN
                        state = 3;
                    }
                }
            }
            else pre = DateTime.Now;


            g.FillEllipse(Brushes.White, x, y, 150, 150);
            g.FillEllipse(Brushes.Red, (x + 100 / 2) - ((joyX / 512) * 20), (y + 100 / 2) - ((joyY / 512) * 20), 50, 50);

            string[] left = { "Julian",   "Arby's",      "Oaks Mall",           "Friends"};
            string[] up =   { "Peyton",   "Chuy's",      "Universal Studios",   "Food" };
            string[] right = { "Tristan",  "Hurrican BTW", "Gatorz Bowling",    "Fun" };

            g.DrawString(left[state], f, Brushes.Red, x - 50, y + 60);
            g.DrawString(up[state], f, Brushes.Red, x+45, y );
            g.DrawString(right[state], f, Brushes.Red, x + 120, y + 60);

            
            switch (state)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
