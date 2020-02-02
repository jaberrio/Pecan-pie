using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Super_Pecan_Pie
{
    class ActDataB
    {
        StreamReader sr = new StreamReader("Acti.csv");
        List<Accident> act = new List<Accident>();

        public ActDataB()
        {
            while (!sr.EndOfStream)
            {
                var split = sr.ReadLine().Split(',');
                float lat, lon;
                float.TryParse(split[0], out lat);
                float.TryParse(split[1], out lon);
                act.Add(new Accident(lat, lon));
            }
        }

        public List<Accident> getList()
        {
            return act;
        }

        //0.01 degrees degrees = 1km

        public List<Accident> getAccidentsNearBy(float lat, float lon,float PlusMinus)
        {
            List<Accident> rtn = new List<Accident>();
            List<Accident> temp = new List<Accident>();

            int lowerB, upperB;
            //Explicit set lowerbound to zero
            lowerB = 0;
            upperB = 0;
            for (int i = 0; i < act.Count(); i++)
            {
                if (act[i].Lat <= (lat - PlusMinus))
                {
                    lowerB = i;
                    //break;
                }
            }
            for (int i = act.Count()-1; i >= 0; i--)
            {
                if(act[i].Lat >= (lat + PlusMinus))
                {
                    upperB = i;
                    //break;
                }
            }
            for (int i = lowerB; i <= upperB; i++)
            {
                Accident coordz = new Accident(act[i].Lat, act[i].Lon);
                if (temp.Count() == 0)
                {
                    temp.Add(coordz);
                }
                else
                {
                    for(int j = 0; j <= temp.Count(); j++)
                    {
                        if(j == temp.Count())
                        {
                            temp.Add(coordz);
                            break;
                        }
                        else if(temp[j].Lon > coordz.Lon)
                        {
                            temp.Insert(j, coordz);
                            break;
                        }
                    }
                }
            }
            lowerB = 0;
            upperB = 0;
            for (int i = 0; i < temp.Count(); i ++)
            {
                if(temp[i].Lon <= (lon - PlusMinus))
                {
                    lowerB = i;
                    //break;
                }
            }
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                if (temp[i].Lon >= (lon + PlusMinus))
                {
                    upperB = i;
                    //break;
                }
            }
            for (int i = lowerB; i <= upperB; i++)
            {
                rtn.Add(temp[i]);
            }
            return rtn;
        }

        
        public void findCrashesForAllPoints()
        {
            StreamWriter fr = new StreamWriter("CrashNums.csv");

            var temp = 0;
            foreach (var item in act)
            {
                temp = getAccidentsNearBy(item.Lat, item.Lon, 0.01455541f).Count + 1;
                fr.WriteLine(temp);
                fr.AutoFlush = true;
            }

                
            
                
            
            //Console.WriteLine(act.Count);
            //List<Accident> temp = new List<Accident>();

        }
    }
}
