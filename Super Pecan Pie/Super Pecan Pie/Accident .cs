 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Super_Pecan_Pie
{
    public class Accident
    {
        public float Lat, Lon;

        public Accident(float Lat, float Lon)
        {
            this.Lat = Lat;
            this.Lon = Lon;

            //0.01 degrees degrees = 1km
        }

        override public string ToString()
        {
            return Lat.ToString() + " , " + Lon.ToString();
        }   
        

    }
}
