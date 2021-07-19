using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveY : GcodeCommand
    {
        private readonly double y;

        public G1MoveY(double y)
        {
            this.y = y;
        }
        
        // Bewegt sich nur in Y Richtung mit gleichbleibendem X und Z
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetPosition(0, y, "y");
            yamaha.Move(0);
            yamaha.WaitForOk(yamaha.SendCount);
            yamaha.SendCount = 0;
        }

        public static G1MoveY Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 2 || !split[0].StartsWith("G1") || !split[1].StartsWith("Y"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("Y", "");
            double y = double.Parse(split[1], new CultureInfo("en-us"));
            return new G1MoveY(y);
        }
    }
}