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
        private int OkCount { get; set; } 
        readonly Position?[] positions = new Position?[63];
        public Yamaha()
        {
            serialPort = new SerialPort();
            CurrentSpeed = 100;
            CurrentPosition = new Position(0, 0, 100);
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
            serialPort.DiscardInBuffer();

        }

        internal void ExecuteMoves(int MoveCount)
        {
            List<string> writeCommand = new List<string>(MoveCount%7);
            if (MoveCount == 0)
            {
                return;
            }
            for (int i = 0; i<MoveCount;i++)
            {
               
                if (i % 7 == 0)
                {                    
                    writeCommand.Add("@MOVE L");                    
                }
                writeCommand[(i % 63) / 7] = writeCommand[(i % 63) / 7] + ",P" + (i % 63);
            }
            for ( int i = 0;i<writeCommand.Count;i++)
            {
                writeCommand[i] += ",S=" + CurrentSpeed.ToString();
            }
            foreach ( var moveCommand in writeCommand)
            {                
                SendCommand(moveCommand);
            }
            SendCount += writeCommand.Count;
            WaitForOk(SendCount);
            SendCount = 0;
        }

        public void SetFlow(double flow)
        {
            
        }
        public Position SetPosition(int index, double x, double y, double z)
        {
            z = 100.0 - z;
            if (z < 0)
            {
                z = 0;
            }
            Position position = new Position(x, y, z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            CurrentPosition = position;
            positions[index] = position;
            SendCommand($"P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            return position;
        }
        public Position SetPosition(int index, double z)
        {
            z = 100.0 - z;
            if(z<0)
            {
                z=0;
            }
            Position position = new Position(CurrentPosition.X, CurrentPosition.Y, z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            CurrentPosition = position;
            positions[index] = position;
            SendCommand($"P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            return position;
        }

        internal void Move(int index)
        {
            SendCommand("@MOVE P,P"+index+",S="+this.CurrentSpeed);
            WaitForOk(SendCount+1);
            SendCount = 0;
        }
        
        private void SendCommand(string data)
        {
            serialPort.Write(data);
            serialPort.Write(eol, 0, 2);
            Console.WriteLine(data);
        }
        public Position SetPosition(int index, double x, double y)
        {
            Position position = new Position(x,y,CurrentPosition.Z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            CurrentPosition = position;
            positions[index] = position;
            SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            SendCount++;
            return position;
        }
        public bool WaitForOk(int OkCounts)
        {
            while(OkCounts!=OkCount)
            {                
                if (ReadLine() == "OK\r")
                    OkCount++;
            }
            OkCount = 0;
            return true;
        }

        private string ReadLine()
        {
            var recieve = "";
            try
            {
                recieve = serialPort.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("nothing in Buffer: Readtimeout triggered");
            }
            return recieve;
        }
    }
}