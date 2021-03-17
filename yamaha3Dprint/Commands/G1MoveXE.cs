using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveXE : GcodeCommand
    {
        private readonly double x;
        private readonly double e;

        public G1MoveXE(double x, double e)
        {
            this.x = x;
            this.e = e;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetPosition(0, x, "x");
            arduino.Move(e);
            yamaha.Move(0);
        }
        //G1 X60.0 E9.0 F1000.0
        public static G1MoveXE Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 3 || !split[0].StartsWith("G1") || !split[1].StartsWith("X") || !split[2].StartsWith("E"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("X", "");
            split[2] = split[2].Replace("E", "");
            double x = double.Parse(split[1], new CultureInfo("en-us"));
            double e = double.Parse(split[2], new CultureInfo("en-us"));                        
            return new G1MoveXE(x, e);
        }
    }
}