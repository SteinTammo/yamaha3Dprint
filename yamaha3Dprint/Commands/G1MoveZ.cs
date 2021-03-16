using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveZ : GcodeCommand
    {
        private readonly double z;

        public G1MoveZ(double z)
        {
            this.z = z;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetPosition(0,z,"z");
            yamaha.Move(0);
        }

        public static G1MoveZ Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 2 || !split[0].StartsWith("G1") || !split[1].StartsWith("Z"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("Z", "");
            double z = double.Parse(split[1], new CultureInfo("en-us"));          

            return new G1MoveZ(z);
        }
    }
}