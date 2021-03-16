using System;

namespace yamaha3Dprint.Commands
{
    public class G28 : GcodeCommand
    {
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            yamaha.SetOrigin();
            yamaha.SetPosition(0, 0.0, 0.0, 0.0);
            yamaha.Move(0); 
            yamaha.SetPosition(0, 0.0, 0.0, 98.0);
            yamaha.Move(0);
        }

        public static G28 Parse(string parameter)
        {
            if(parameter!="G28")
            {
                throw new ArgumentException("Falsche Parameter: " + parameter);
            }
            return new G28();
        }
    }
}