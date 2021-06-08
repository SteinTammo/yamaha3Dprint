using System;

namespace yamaha3Dprint.Commands
{
    public class G2 : GcodeCommand
    {
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            throw new System.NotImplementedException();
        }

        public static G2 Parse(string v)
        {
            throw new NotImplementedException();
        }
    }
}