using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveX : GcodeCommand
    {
        private readonly double x;

        public G1MoveX(double x)
        {
            this.x = x;
        }

        // Bewegt sich nur in X Richtung mit gleichbleibendem Y und Z
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetPosition(0, x, "x");
            yamaha.Move(0);
            yamaha.WaitForOk(yamaha.SendCount);
            yamaha.SendCount = 0;
        }

        public static G1MoveX Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 2 || !split[0].StartsWith("G1") || !split[1].StartsWith("X"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("X", "");
            double x = double.Parse(split[1], new CultureInfo("en-us"));
            return new G1MoveX(x);
        }
    }
}