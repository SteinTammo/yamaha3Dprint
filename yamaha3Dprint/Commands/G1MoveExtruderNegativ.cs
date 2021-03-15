using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveExtruderNegativ : GcodeCommand
    {
        private readonly double e;

        public G1MoveExtruderNegativ(double e)
        {
            this.e = e;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            
        }
        public static G1MoveExtruderNegativ Parse(string parameters)
        {
            
            if (!parameters.StartsWith("E"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            parameters = parameters.Replace("E", "");
            double e = double.Parse(parameters, new CultureInfo("en-us"));

            return new G1MoveExtruderNegativ(e);
        }
    }
}