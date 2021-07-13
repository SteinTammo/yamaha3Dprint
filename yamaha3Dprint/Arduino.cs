using System;
using System.IO.Ports;
using System.Threading;

namespace yamaha3Dprint
{
    public class Arduino
    {
        private Yamaha3DPrint yamaha3DPrint;
        private readonly SerialPort serialPort;

        public int CurrentSpeed { get; private set; } //aktuelle geschwindigkeit
        public int OkCount { get; private set; }    // anzahl der Oks die erwartet werden
        public double Flowrate { get; private set; }    // Flowrate des Extruders
        public double FlowMultiplier { get; private set; }  // Verhältnis der Slicereinstellung zur realen Bewegung
        public Arduino(Yamaha3DPrint yamaha3DPrint)
        {
            this.yamaha3DPrint = yamaha3DPrint;
            serialPort = new SerialPort();
            CurrentSpeed = 100;
            FlowMultiplier = 1 / 6;
        }

        internal void SetBTemp(int Temp)
        {
            Write("M104&" + Temp + "&");
            WaitForOk(1);
        }

        // Längenabhängige Extrusion
        public void MoveExtruder(double e)
        {
            double time;
            time = e / (Flowrate/60)*1000;
            if(time<0)
            {
                time = time * (-1);
            }
            if(e>0)
            {
                //Move(1);
                //Thread.Sleep((int)time);
                //Move(0);
            }
            else if(e<0)
            {
                //Move(-1);
                //Thread.Sleep((int)time);
                //Move(0);
            }
            
        }

        // bewege Extruder. e>0 nach vorn e<0 nach hinten
        internal void Move(double? e)
        {
            if(e!=null)
            {
                Write("G1E&" + e + "&");
            }
        }
        // lese Extrudertemperatur vom arduino
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

        // öffnet den Seriellen Port mit dem Arduino
        public void Connect(string portname, int bautrate)
        {
            if (serialPort.IsOpen)
            {
                return;
            }
            serialPort.PortName = portname;
            serialPort.BaudRate = bautrate;
            serialPort.ReadTimeout = 300;            
            serialPort.Open();
            serialPort.DiscardInBuffer();
        }

        // Setze Druckgeschwindigkeit
        internal void SetFlow(double flow)
        {
            double floweffektiv = flow * FlowMultiplier;
            Flowrate = floweffektiv;
            Write("G1F&" + floweffektiv + "&");
            WaitForOk(1);
        }
        // Übrmittle die Zieltemperatur des Extruders an den Arduino
        internal void SetETemp(int Temp)
        {
            Write("M104&" + Temp + "&");
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

        // warte auf bestimmte Anzahl an Oks vom Arduino
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

        // sende String an arduino und zeige diesen im Porgramm
        internal void Write(string text)
        {            
            yamaha3DPrint.TeBox_SerialControllino.Invoke(new Action(() =>
            {
                yamaha3DPrint.TeBox_SerialControllino.AppendText(text + Environment.NewLine);
            }));
            serialPort.Write(text);
        }

        //
        public void SetFlowMultiplier(double multiplier)
        {
            FlowMultiplier = multiplier;
        }
    }
}