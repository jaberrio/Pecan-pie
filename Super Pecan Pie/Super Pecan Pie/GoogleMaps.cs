﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Device.Location;

namespace Super_Pecan_Pie
{
    public class functions1
    {
            public string ReadFile(string filename)
        {
            string API_key = File.ReadAllText("API_key.txt");
            return API_key;
        }

        public RootObject API_Call(string APIREQUEST)// Sends API request and Deserializes it into the classes
        {
            var client = new WebClient();
            var content = client.DownloadString(APIREQUEST);
            RootObject directions = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(content);
            return directions;
        }
        public string API_request(GeoCoordinate coord, string destination)// Takes current location (in lng and lat) and then a destination and returns a string API Reuqes
        {
            string APIREQUEST;
            string API_key = ReadFile("API_key.txt");
            APIREQUEST = "https://maps.googleapis.com/maps/api/directions/json?origin=" + coord.Latitude + "," + coord.Longitude + "&destination=" + destination + "&key=" + API_key;
            return APIREQUEST;
        }
        public DistanceManeuver[] DirectionFetch(RootObject directions) // returns array of  direction and maneuver of next step
        {
            int i = 0;
            var DistanceManeuver = new DistanceManeuver[1000];
            foreach(var route in directions.routes)
                foreach(var legs in route.legs)
                    foreach(var steps in legs.steps)
                    {
                        var DistanceManeuvertemp = new DistanceManeuver
                        {
                            maneuver = steps.maneuver ,
                            distance = steps.distance.text
                        };
                        DistanceManeuver[i++] = DistanceManeuvertemp;
                    }
            return DistanceManeuver;
        }
        public StartLocation2[] CoordFetch(RootObject directions) //  Returns array that holds coords of start Location of next step.
        {
            int i = 0;
            var Location = new StartLocation2[10000];
            foreach(var route in directions.routes)
                foreach(var legs in route.legs)
                    foreach(var steps in legs.steps)
                        Location[i++] = steps.start_location;
            return Location;
        }

        public List<StartLocation2> CordFetchExtra(RootObject direction, float distenceStep,StartLocation2 currtLoc)
        {
            List<StartLocation2> rtn = new List<StartLocation2>();
            List<StartLocation2> use = CoordFetch(direction).ToList();
            
            var e = use.GetEnumerator();
            var pre = e.Current;
            while (e.MoveNext())
            {
                var Deltalat = e.Current.lat - pre.lat;
                var Deltalon = e.Current.lng - pre.lng;
                var Distance = Math.Sqrt(Math.Pow(Deltalat, 2) + Math.Pow(Deltalon, 2)); //hyp
                var Step     = Distance / distenceStep;

                var tempNumLat = Deltalat / Step;
                var tempNumLng = Deltalon / Step;

                //var slope = Deltalon / Deltalat;
                //var temp = e.Current;
                for (int i = 0; i < Step; i++)
                {
                    Deltalat += tempNumLat;
                    Deltalon += tempNumLng;
                    StartLocation2 temp = new StartLocation2();
                    temp.lat = Deltalat;
                    temp.lng = Deltalon;
                    //float z = (float)(Step * Math.Atan(Deltalon / Deltalat));
                    //temp.lat = e.Current.lat + z;
                    //temp.lng = temp.lat * slope;

                    rtn.Add(temp);
                }

                pre = e.Current;
            }
            
            return rtn;
        }

        public static GeoCoordinate GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
            System.Threading.Thread.Sleep(1000);
            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromSeconds(1d));

            GeoCoordinate coord = watcher.Position.Location;


            if (coord.IsUnknown != true)
            {

                return coord;
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
                return GetLocationProperty();

            }
        }


        void test()// This needs to be implemented into GUI
        {
            //string textBoxContents = textBox1.Text;
            var functions = new functions1();
            var directions = new RootObject();
            var steps1 = new DistanceManeuver[1000];
            var startlocation = new StartLocation2[10000];
            //directions = functions.API_Call(textBoxContents);
            steps1 = functions.DirectionFetch(directions);
            startlocation = functions.CoordFetch(directions);

            //Stepped4ActDataB
            


            int i = 0;
            while(startlocation[i] != null)//Prints starting lats and longs per step
            {

                Console.WriteLine(startlocation[i].lat + " " + startlocation[i].lng);
                i++;

            }
            int k = 0;
            while(steps1[k] != null) // prints distance and maneuver of next step
            {
                Console.WriteLine(steps1[k].distance + " " + steps1[k].maneuver);
                k++;
            }

        }

        public class DistanceManeuver
        {
            public string maneuver;
            public string distance;
        }

        public class GeocodedWaypoint
        {
            public string geocoder_status { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Bounds
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class StartLocation
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Distance2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class Duration2
        {
            public string text { get; set; }
            public int value { get; set; }
        }

        public class EndLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Polyline
        {
            public string points { get; set; }
        }

        public class StartLocation2
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Step
        {
            public Distance2 distance { get; set; }
            public Duration2 duration { get; set; }
            public EndLocation2 end_location { get; set; }
            public string html_instructions { get; set; }
            public Polyline polyline { get; set; }
            public StartLocation2 start_location { get; set; }
            public string travel_mode { get; set; }
            public string maneuver { get; set; }
        }

        public class Leg
        {
            public Distance distance { get; set; }
            public Duration duration { get; set; }
            public string end_address { get; set; }
            public EndLocation end_location { get; set; }
            public string start_address { get; set; }
            public StartLocation start_location { get; set; }
            public List<Step> steps { get; set; }
            public List<object> traffic_speed_entry { get; set; }
            public List<object> via_waypoint { get; set; }
        }

        public class OverviewPolyline
        {
            public string points { get; set; }
        }

        public class Route
        {
            public Bounds bounds { get; set; }
            public string copyrights { get; set; }
            public List<Leg> legs { get; set; }
            public OverviewPolyline overview_polyline { get; set; }
            public string summary { get; set; }
            public List<object> warnings { get; set; }
            public List<object> waypoint_order { get; set; }
        }

        public class RootObject
        {
            public List<GeocodedWaypoint> geocoded_waypoints { get; set; }
            public List<Route> routes { get; set; }
            public string status { get; set; }
        }
    }
}