using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1SetFlow : GcodeCommand
    {
        public readonly double flow;
        public G1SetFlow(double flow)
        {
            this.flow = flow;
        }

        // Übermittelt die neuen Flow Einstellungen des GCodes an die Arduino und Yamaha klasse, die die Information in geschwindigkeitsänderungen des Roboters bzw Extruders übersetzt
        public static G1SetFlow Parse(string parameters)
        {
            var split = parameters.Split(' ');
            if (split.Length != 2 || !split[0].StartsWith("G1") || !split[1].StartsWith("F"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("F", "");
            double flow = double.Parse(split[1], new CultureInfo("en-us"));
            return new G1SetFlow(flow);
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetFlow(flow);
            arduino.SetFlow(flow);
        }
    }
}