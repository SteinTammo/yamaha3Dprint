using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MovePositiv : GcodeCommand
    {
        public readonly double x;
        public readonly double y;
        public readonly double? e;

        public G1MovePositiv(double x, double y, double? e)
        {
            this.x = x;
            this.y = y;
            this.e = e;
        }

        public static G1MovePositiv Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 3 && split.Length != 4 || !split[0].StartsWith("G1") || !split[1].StartsWith("X") || !split[2].StartsWith("Y"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("X", "");
            split[2] = split[2].Replace("Y", "");
            double x = double.Parse(split[1], new CultureInfo("en-us"));
            double y = double.Parse(split[2], new CultureInfo("en-us"));
            double? e = null;
            if (split.Length==4)
            {
                split[3] = split[3].Replace("E", "");
                e = double.Parse(split[3], new CultureInfo("en-us"));
            }

            return new G1MovePositiv(x,y,e);
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            
            var position = yamaha.SetPosition(0, x, y);
            yamaha.Move(0);
        }
    }
}