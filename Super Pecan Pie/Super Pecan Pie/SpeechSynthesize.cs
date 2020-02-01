using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace Super_Pecan_Pie
{
    class SpeechSynthesize
    {
        public SpeechSynthesizer synthesizerB = new SpeechSynthesizer();
        public SpeechSynthesize()
        {
            synthesizerB.SetOutputToDefaultAudioDevice();
            synthesizerB.Speak("I do be working doh");
        }
    }
}
