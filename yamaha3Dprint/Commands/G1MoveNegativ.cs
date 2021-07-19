using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    public class G1MoveNegativ : GcodeCommand
    {
        public readonly double x;
        public readonly double y;
        public readonly double? e;

        public G1MoveNegativ(double x, double y, double? e)
        {
            this.x = x;
            this.y = y;
            this.e = e;
        }
        // setzt einen neuen Punkt mit den übergebenen Koordinaten und fährt diesen an. 
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            var position = yamaha.SetPosition(0, x, y); //Setze Punkt
            arduino.Move(e);    //Bewege Extruder
            yamaha.Move(0); //fahre zum neuen punkt
            yamaha.WaitForOk(2); // warte bis der neue punkt angefahren ist
            yamaha.SendCount = 0;   //setze oks zurück
            arduino.Move(0);    // Schalte extruder ab
        }
        // Liest den GcodeComand ein und wandelt ihn in parameter um und speichert diese für die Befehlsausführung
        public static G1MoveNegativ Parse(string parameters)
        {
            //G1 X109.866 Y42.627 E - 0.18749
            var split = parameters.Split(' ');
            //split beinhaltet als array die Zeichenfolgen die von ' ' abgetrennt sind.

            //Split[0]=G1
            //split[1]=X109.866
            //Split[2]=Y42.627
            //Split[3]=E - 0.18749
            if (split.Length != 3 && split.Length != 4 || !split[0].StartsWith("G1") || !split[1].StartsWith("X") || !split[2].StartsWith("Y"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            split[1] = split[1].Replace("X", "");
            split[2] = split[2].Replace("Y", "");
            double x = double.Parse(split[1], new CultureInfo("en-us"));
            double y = double.Parse(split[2], new CultureInfo("en-us"));
            double? e = null;
            if (split.Length == 4)
            {
                split[3] = split[3].Replace("E", "");
                e = double.Parse(split[3], new CultureInfo("en-us"));
            }

            return new G1MoveNegativ(x, y, e);
        }
    }
}