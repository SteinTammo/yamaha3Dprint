using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    // Überführt die Zeit und Prozentinformationen des Slicers. Aktuell auskommentiert, da der Fortschritt der Commands als Balken signalisert wird. Die Information der Zeit spiegelt auch nicht die wahre zeit wieder die der Drucker benötigt.
    public class M73 : GcodeCommand
    {
        private readonly int percentage;
        private readonly int time;

        public M73(int percentage, int time)
        {
            this.percentage = percentage;
            this.time = time;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            //yamaha.SetProgress(percentage);
            //yamaha.UpdateProgressTime(time);
        }

        public static M73 Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (!split[0].StartsWith("M73") || !split[1].StartsWith("P") || !split[2].StartsWith("R"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }

            split[1] = split[1].Replace("P", "");
            split[2] = split[2].Replace("R", "");
            int percentage = int.Parse(split[1], new CultureInfo("en-us"));
            int time = int.Parse(split[2], new CultureInfo("en-us"));
            return new M73(percentage, time);
        }
    }
}