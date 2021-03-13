using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;

namespace yamaha3Dprint
{
    public class Yamaha
    {
        private readonly SerialPort serialPort;
        byte[] eol = new byte[] { 0x0D, 0x0A };
        public Position CurrentPosition { get; private set; }
        public int CurrentSpeed { get; private set; }
        private int SendCount { get;  set; } // Todo Implement
        private int OkCount { get; set; } // Todo implement
        readonly Position?[] positions = new Position?[40];
        public Yamaha()
        {
            serialPort = new SerialPort();
            CurrentSpeed = 20;
        }
        public void Connect(string portname, int bautrate)
        {
            serialPort.PortName = portname;
            serialPort.BaudRate = bautrate;
            serialPort.ReadTimeout = 200;
            if (serialPort.IsOpen)
            {
                return;
            }
            serialPort.Open();
        }
        public void SetFlow(double flow)
        {
            
        }
        public Position SetPosition(int index, double z)
        {
            Position position = new Position(CurrentPosition.X, CurrentPosition.Y, z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            positions[index] = position;
            SendCommand($"P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            return position;
        }

        internal void Move(int index)
        {
            SendCommand("@MOVE P"+index+",S="+this.CurrentSpeed);
        }

        private void SendCommand(string data)
        {
            //serialPort.Write(data);
            //serialPort.Write(eol, 0, 2);
            Console.WriteLine(data);
        }
        public Position SetPosition(int index, double x, double y)
        {
            Position position = new Position(x,y,CurrentPosition.Z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            positions[index] = position;
            SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            return position;
        }
    }
}