using System;
using System.IO.Ports;

namespace yamaha3Dprint
{
    public class Arduino
    {
        private Yamaha3DPrint yamaha3DPrint;
        private readonly SerialPort serialPort;

        public int CurrentSpeed { get; private set; }
        public int OkCount { get; private set; }

        public Arduino(Yamaha3DPrint yamaha3DPrint)
        {
            this.yamaha3DPrint = yamaha3DPrint;
            serialPort = new SerialPort();
            CurrentSpeed = 100;
        }

        internal void Move(double? e)
        {
            if(e!=null)
            serialPort.Write("G1E&" + e + "&");
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

        internal void SetFlow(double flow)
        {
            serialPort.Write("G1F&" + flow + "&");
            WaitForOk(1);
        }
        private string ReadLine()
        {
            var recieve = "";
            try
            {
                recieve = serialPort.ReadLine();
                Console.WriteLine(recieve);
            }
            catch (TimeoutException)
            {
                Console.WriteLine("nothing in Buffer: Readtimeout triggered");
            }
            return recieve;
        }
        public bool WaitForOk(int OkCounts)
        {
            while (OkCounts != OkCount)
            {
                if (ReadLine() == "OK\r")
                    OkCount++;
            }
            OkCount = 0;
            return true;
        }
    }
}