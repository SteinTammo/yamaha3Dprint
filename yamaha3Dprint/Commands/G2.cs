using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G2 : GcodeCommand
    {
        public readonly double x;
        public readonly double y;
        public readonly double I;
        public readonly double J;
        public readonly double e;

        public G2(double x, double y, double I, double J,double e)
        {
            this.x = x;
            this.y = y;
            this.I = I;
            this.J = J;
            this.e = e;
        }
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            throw new System.NotImplementedException();
        }
        // G2 X221.489 Y173.538 I-3.371 J0.225 E0.21595
        public static G2 Parse(string data)
        {
            var split = data.Split(' ');
            
            split[1] = split[1].Replace("X", "");
            split[2] = split[2].Replace("Y", "");
            split[3] = split[3].Replace("I", "");
            split[4] = split[4].Replace("J", "");
            split[5] = split[5].Replace("E", "");
            double x = double.Parse(split[1], new CultureInfo("en-us"));
            double y = double.Parse(split[2], new CultureInfo("en-us"));
            double I = double.Parse(split[3], new CultureInfo("en-us"));
            double J = double.Parse(split[4], new CultureInfo("en-us"));
            double e = double.Parse(split[5], new CultureInfo("en-us"));
            
            return new G2(x,y,I,J,e);
        }
    }
}