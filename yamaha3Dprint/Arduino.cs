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
            {
                Write("G1E&" + e + "&");
            }
        }
        public float GetExtruderTemp()
        {
            float temp=0;
            for(int i=0;i<10;i++)
            {
                Write("GETTEMP&0&");
                string read;
                do
                {
                    read = ReadLine();
                }
                while (read == "");
                read.Replace(@"\", "");
                read.Replace("r", "");
                    
                temp += float.Parse(read);
            }
            temp /= 10;
            return temp;
        }

        public void Connect(string portname, int bautrate)
        {
            serialPort.PortName = portname;
            serialPort.BaudRate = bautrate;
            serialPort.ReadTimeout = 300;
            if (serialPort.IsOpen)
            {
                return;
            }
            serialPort.Open();
            serialPort.DiscardInBuffer();
        }

        internal void SetFlow(double flow)
        {
            Write("G1F&" + flow + "&");
            WaitForOk(1);
        }
        internal string Read()
        {
            string recieve = ReadLine();
            return recieve;
        }
        private string ReadLine()
        {
            var recieve = "";
            try
            {
                recieve = serialPort.ReadLine();
                //Console.WriteLine(recieve);
            }
            catch (TimeoutException)
            {
                //Console.WriteLine("nothing in Buffer: Readtimeout triggered");
            }
            if(recieve!="")
            {
                yamaha3DPrint.TeBox_SerialArduinoRead.Invoke(new Action(() =>
                {
                    yamaha3DPrint.TeBox_SerialArduinoRead.AppendText(recieve + Environment.NewLine);
                }));
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

        internal void Write(string text)
        {            
            yamaha3DPrint.TeBox_SerialControllino.Invoke(new Action(() =>
            {
                yamaha3DPrint.TeBox_SerialControllino.AppendText(text + Environment.NewLine);
            }));
            serialPort.Write(text);
        }
    }
}