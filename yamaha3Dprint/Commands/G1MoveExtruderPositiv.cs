﻿using System;
using System.Globalization;
using yamaha3Dprint.Commands;

namespace yamaha3Dprint.Commands
{
    public class G1MoveExtruderPositiv : GcodeCommand
    {
        private readonly double e;

        public G1MoveExtruderPositiv(double e)
        {
            this.e = e;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            arduino.Move(e);
            arduino.WaitForOk(1);
        }

        public static G1MoveExtruderPositiv Parse(string parameters)
        {
            if (!parameters.StartsWith("E"))
            {
                throw new ArgumentException("Falsche Parameter: " + parameters);
            }
            parameters = parameters.Replace("E", "");
            double e = double.Parse(parameters, new CultureInfo("en-us"));

            return new G1MoveExtruderPositiv(e);
        }
    }
}
