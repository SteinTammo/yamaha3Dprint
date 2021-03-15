using System;

namespace yamaha3Dprint.Commands
{
    public class G28 : GcodeCommand
    {
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            
            yamaha.SetPosition(0, 0.0, 0.0, 100.0);
            yamaha.Move(0);
        }
    }
}