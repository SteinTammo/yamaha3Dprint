using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G3 : GcodeCommand
    {
        private double x;
        private double y;
        private double i;
        private double j;
        private double e;
        Position position;

        public G3(double x, double y, double i, double j, double e)
        {
            this.x = x;
            this.y = y;
            this.i = i;
            this.j = j;
            this.e = e;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            if(Math.Sqrt(Math.Pow(i,2)+Math.Pow(j,2))<1)
            {
                yamaha.SetPosition(0,x,y);
                arduino.Move(e);
                yamaha.Move(0);
                yamaha.WaitForOk(2);
                yamaha.SendCount = 0;
                arduino.Move(0);
            }
            else
            {
                position = yamaha.GetCurrentPosition();
                double mittelpunktx = x + i;
                double mittelpunkty = y + j;
                yamaha.SetPosition(0, x, y);
                yamaha.SetPosition(1, x + i, y + j);
                arduino.Move(e);
                yamaha.MoveC(2);
            }
        }

        public static G3 Parse(string data)
        {
            var split = data.Split(' ');

            split[0] = split[0].Replace("X", "");
            split[1] = split[1].Replace("Y", "");
            split[2] = split[2].Replace("I", "");
            split[3] = split[3].Replace("J", "");
            split[4] = split[4].Replace("E", "");
            double x = double.Parse(split[0], new CultureInfo("en-us"));
            double y = double.Parse(split[1], new CultureInfo("en-us"));
            double I = double.Parse(split[2], new CultureInfo("en-us"));
            double J = double.Parse(split[3], new CultureInfo("en-us"));
            double e = double.Parse(split[4], new CultureInfo("en-us"));

            return new G3(x, y, I, J, e);
        }
    }
}