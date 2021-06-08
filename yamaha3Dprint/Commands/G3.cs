using System;

namespace yamaha3Dprint.Commands
{
    public class G3 : GcodeCommand
    {
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
        }

        public static G3 Parse(string v)
        {
            return new G3();
        }
    }
}