using System;

namespace yamaha3Dprint.Commands
{
    // setzt die Koordinaten zurück. 
    public class G92 : GcodeCommand
    {
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            arduino.Write("G92&E&");
            //arduino.WaitForOk(1);
        }

        public static G92 Parse(string parameters)
        {
            var parameter = parameters.Split(' ');
            if (parameter[0] != "G92")
            {
                throw new ArgumentException("Falsche Parameter: " + parameter);
            }
            return new G92();
        }
    }
}