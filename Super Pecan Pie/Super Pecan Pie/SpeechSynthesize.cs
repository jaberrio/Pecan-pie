using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.AudioFormat;

namespace Super_Pecan_Pie
{
    class SpeechSynthesize
    {
        public SpeechSynthesizer synthesizerB = new SpeechSynthesizer();
        //public List<DistanceManeuver> distanceMan;
        public SpeechSynthesize()
        {
            synthesizerB.SetOutputToDefaultAudioDevice();
            synthesizerB.SelectVoice("Microsoft Zira Desktop");
        }

        public void readDistanceMan(String input, int key)
        {
            input = input.Replace('+', ' ');
            String temp = "";
            switch (key)
            {
                case 1: 
                    synthesizerB.Speak("Starting journey to " + input);
                    break;
                case 2:
                    synthesizerB.Speak("Total duration is " + input);
                    break;
                case 3:
                    synthesizerB.Speak("There are " + input + " dangerous zones on your journey.");
                    break;
                case 4:
                    synthesizerB.Speak(input);
                    break;
            }
            
            /*for(int i = 0; i < distanceMan.Count; i++)
            {
                Console.WriteLine(distanceMan[i].distance);
                Console.WriteLine(distanceMan[i].maneuver);
                Console.WriteLine("/n");
            }      */
            //synthesizerB.Speak()
        }
    }
}
