using System;

namespace yamaha3Dprint.Commands
{
    public class M190 : GcodeCommand
    {
        public readonly int Temp;

        public M190(int temp)
        {
            Temp = temp;
        }

        public static M190 Parse(string v)
        {
            int Temp = 20;
            if (v.StartsWith("S"))
            {
                v = v.Replace("S", "");
                Temp = Convert.ToInt32(v);
            }
            return new M190(Temp);
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            arduino.SetBTemp(Temp);
        }
    }
}