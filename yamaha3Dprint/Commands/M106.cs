using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class M106 : GcodeCommand
    {
        public double fanspeed { get; set; }
        public M106(double speed)
        {
            this.fanspeed = speed;
        }
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            //Bei anschluss mit Part cooliung fan
        }
        public static M106 Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (!split[0].StartsWith("M106") || !split[1].StartsWith("S"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }

            split[1] = split[1].Replace("S", "");
            double Speed = double.Parse(split[1], new CultureInfo("en-us"));
            return new M106(Speed);
        }
    }
}