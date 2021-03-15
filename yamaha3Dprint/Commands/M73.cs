using System;

namespace yamaha3Dprint.Commands
{
    public class M73 : GcodeCommand
    {
        private readonly int percentage;

        public M73(int v)
        {
            this.percentage = v;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            throw new NotImplementedException();
        }

        public static M73 Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if(!split[0].StartsWith("M73"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            int v = 10;
            return new M73(v);
        }
    }
}