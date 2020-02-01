using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace Super_Pecan_Pie
{
    class SpeechRecognize
    {
        public SpeechRecognitionEngine recognizeB = new SpeechRecognitionEngine();
        public SpeechRecognize()
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "test", "hello" });
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recognizeB.LoadGrammarAsync(grammar);
            recognizeB.SetInputToDefaultAudioDevice();
            recognizeB.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}


