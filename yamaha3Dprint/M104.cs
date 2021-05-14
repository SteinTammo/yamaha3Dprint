using System;

namespace yamaha3Dprint.Commands
{
    public class M104 : GcodeCommand
    {
        public readonly int Temp;

        public M104(int temp)
        {
            Temp = temp;
        }

        public static M104 Parse(string v)
        {
            int Temp =20;
            if(v.StartsWith("S"))
            {
                v=v.Replace("S", "");
                Temp = Convert.ToInt32(v);
            }
            return new M104(Temp);
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            arduino.SetTemp(Temp);
        }
    }
}