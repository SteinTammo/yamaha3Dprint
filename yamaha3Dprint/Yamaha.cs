using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;

namespace yamaha3Dprint
{
    public class Yamaha
    {
        private readonly SerialPort serialPort;

        byte[] eol = new byte[] { 0x0D, 0x0A };
        private Yamaha3DPrint yamaha3DPrintform;        

        public Position CurrentPosition { get; private set; }
        public int CurrentSpeed { get; private set; }
        public int MaxSpeed { get; private set; } = 8000;
        public int SendCount { get;  set; } 
        public int OkCount { get; set; } 
        readonly Position?[] positions = new Position?[63];        

        public Yamaha(Yamaha3DPrint yamaha3DPrint)
        {
            this.yamaha3DPrintform = yamaha3DPrint;
            serialPort = new SerialPort();
            CurrentSpeed = 15;
            CurrentPosition = new Position(0, 0, 100);
        }

        public void Connect(string portname, int bautrate)
        {
            serialPort.PortName = portname;
            serialPort.BaudRate = bautrate;
            serialPort.ReadTimeout = 200;
            serialPort.Handshake=Handshake.XOnXOff;
            serialPort.Parity = Parity.Odd;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
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

            CurrentSpeed = (int)(-2*Math.Pow(10, -20) * Math.Pow(flow, 5) + 6 * Math.Pow(10, -16) * Math.Pow(flow, 4) - 7 * Math.Pow(10, -12) * Math.Pow(flow, 3) + 6 * Math.Pow(10, -8) * Math.Pow(flow, 2) + 0.0068 * flow + 0.097);
            
            if(CurrentSpeed>=100)
            {
                Console.WriteLine("Speedlimit Exceeded");
                CurrentSpeed = 100;
            }
        }


        public Position SetPosition(int index, double x, double y, double z)
        {            
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
            SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            SendCount++;
            return position;
        }
        public Position SetPosition(int index, double z,string xyz)
        {
            if(xyz=="z")
            {
                z = 100.0 - z;
                if (z < 0)
                {
                    z = 0;
                }
                Position position = new Position(CurrentPosition.X, CurrentPosition.Y, z);
                string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
                string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
                string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
                CurrentPosition = position;
                positions[index] = position;
                SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
                SendCount++;
                return position;
            }
            else if (xyz == "x")
            {
                Position position = new Position(z, CurrentPosition.Y, CurrentPosition.Z);
                string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
                string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
                string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
                CurrentPosition = position;
                positions[index] = position;
                SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
                SendCount++;
                return position;
            }
            else if (xyz == "y")
            {
                Position position = new Position(CurrentPosition.X, z, CurrentPosition.Z);
                string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
                string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
                string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
                CurrentPosition = position;
                positions[index] = position;
                SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
                SendCount++;
                return position;
            }
            else
            {
                throw new ArgumentException("no X, Y or Z");
            }
        }

        internal void Move(int index)
        {
            SendCommand("@MOVE P,P"+index+",S="+this.CurrentSpeed);
            SendCount++;
        }
        
        public void SendCommand(string data)
        {
            serialPort.Write(data);
            serialPort.Write(eol, 0, 2);     
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

        public string ReadLine()
        {
            var recieve = "";
            try
            {
                recieve = serialPort.ReadLine();
                Console.Write(recieve);
            }
            catch (TimeoutException)
            {
                //Console.WriteLine("nothing in Buffer: Readtimeout triggered");
            }
            return recieve;
        }
        public void SetOrigin()
        {
            SendCommand("@?ORIGIN");
            if(WaitForOrigin()!=true)
            {
                SendCommand("@ABSRST");
                WaitForOk(1);
            }            
        }

        private bool WaitForOrigin()
        {
            string recieve = "";
            while (recieve!="Complete" && recieve!="Incomplete")
            {
                string readLine = ReadLine();
                if (readLine == "COMPLETE\r")
                    recieve = "Complete";
                if (readLine == "INCOMPLETE\r")
                    recieve = "Incomplete";
            }
            if (recieve == "Complete")
                return true;
            else
                return false;
        }
        public void SetProgress(int percentage)
        {
            yamaha3DPrintform.Invoke(new Action(() =>
            {
                yamaha3DPrintform.UpdateProgessbar(percentage);
            }));
        }
        public void UpdateProgressTime(int time)
        {
            yamaha3DPrintform.Invoke(new Action(() =>
            {
                yamaha3DPrintform.UpdateRemaindingTime(time);
            }));
        }
    }
}