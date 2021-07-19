using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;

namespace yamaha3Dprint
{

    // Dient als kommunikationsschnittstelle zwischen dem Programm des Druckers und den Befehlen des Roboters. 
    public class Yamaha
    {
        private readonly SerialPort serialPort;

        byte[] eol = new byte[] { 0x0D, 0x0A }; // Zeilenumbruch um Befehlsende zu signalisieren
        private Yamaha3DPrint yamaha3DPrintform;

        public Position CurrentPosition { get; private set; } // Akuelle Position
        public int CurrentSpeed { get; private set; } // Aktuelle Geschiwndigkeit
        public int MaxSpeed { get; private set; } = 8000;
        public int SendCount { get; set; } // anzahl an erwarteten Oks  
        public int OkCount { get; set; }    // Zählcounter für die Empfangenen Oks
        readonly Position?[] positions = new Position?[63];

        public Yamaha(Yamaha3DPrint yamaha3DPrint)
        {
            this.yamaha3DPrintform = yamaha3DPrint;
            serialPort = new SerialPort();
            CurrentSpeed = 15;
            CurrentPosition = new Position(0, 0, 100);
        }

        // Stellt Serielle Verbidnung her
        public bool Connect(string portname, int bautrate)
        {
            serialPort.PortName = portname;
            serialPort.BaudRate = bautrate;
            serialPort.ReadTimeout = 200;
            serialPort.Handshake = Handshake.XOnXOff;
            serialPort.Parity = Parity.Odd;
            serialPort.StopBits = StopBits.One;
            serialPort.DataBits = 8;
            if (serialPort.IsOpen)
            {
                return true;
            }
            try
            {
                serialPort.Open();
                serialPort.DiscardInBuffer();
                return true;
            }
            catch(Exception M)
            {
                yamaha3DPrintform.ConnectException(M);
                return false;
            }            
        }

        // Löscht den Eingangsbuffer
        public void DiscardInBuffer()
        {
            serialPort.DiscardInBuffer();
        }

        // Für die MoveCollection um alle vorhandenen Positionen direkt hintereinander abzufahren
        internal void ExecuteMoves(int MoveCount)
        {
            List<string> writeCommand = new List<string>(MoveCount % 7);
            if (MoveCount == 0)
            {
                return;
            }
            for (int i = 0; i < MoveCount; i++)
            {

                if (i % 7 == 0)
                {
                    writeCommand.Add("@MOVE L");
                }
                writeCommand[(i % 63) / 7] = writeCommand[(i % 63) / 7] + ",P" + (i % 63);
            }
            for (int i = 0; i < writeCommand.Count; i++)
            {
                writeCommand[i] += ",S=" + CurrentSpeed.ToString();
            }
            foreach (var moveCommand in writeCommand)
            {
                SendCommand(moveCommand);
            }
            SendCount += writeCommand.Count;
            WaitForOk(SendCount);
            SendCount = 0;
        }

        // Linearregression da die Geschwindigkeit des Roboters von 1-100 läuft. Gemessen wurden die Zeiten für definierte Distanzen und daraus das Verhältnis der vom GCode eingestellten Flowwerts und der Geschwindigkeit des ROboters bestimmt. 
        public void SetFlow(double flow)
        {

            CurrentSpeed = (int)(0.0072 * flow - 0.8359);

            if (CurrentSpeed >= 100)
            {
                Console.WriteLine("Speedlimit Exceeded");
                CurrentSpeed = 100;
            }
        }
        public Position GetCurrentPosition()
        {
            return CurrentPosition;
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

        // setzten eines neuen Punkts mit der Fallunterscheidung welche Koordinaten neu sind. 
        public Position SetPosition(int index, double z, string xyz)
        {
            if (xyz == "z")
            {
                z = 100.0 - z;
                if (z < 0)
                {
                    z = 0;
                }
                Position position = new Position(CurrentPosition.X, CurrentPosition.Y, z);
                string strx = position.X.ToString("0.00", new CultureInfo("en-us")); // Umwandlung der Zahlen in ein String in der Form mit . und zwei nachkommastellen
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

        // Move zu einem einzelnen Punkt
        internal void Move(int index)
        {
            SendCommand("@MOVE L,P" + index + ",S=" + this.CurrentSpeed);
            SendCount++;
        }

        // Move als Circularbefehl
        internal void MoveC(int anzPunkte)
        {
            string sendcommand = "";

            sendcommand = "@MOVE C,P0,P1,S = " + this.CurrentSpeed;

            //else
            //{
            //    sendcommand = "@MOVE C,P0,P1";
            //    for(int i=0;i<anzPunkte;i++)
            //    {

            //    }
            //    sendcommand = sendcommand + "S=" + this.CurrentSpeed;
            //}
            SendCommand(sendcommand);
            SendCount++;
        }

        // Sende den String data mit dem zeilenumbruch an den Roboter.
        public void SendCommand(string data)
        {
            serialPort.Write(data);
            serialPort.Write(eol, 0, 2);
            Console.WriteLine(data);
            yamaha3DPrintform.SendCommand(data);
        }

        //Setze neue Postion mit einem Index und neuen x und y koordinanten. Befehl wird gesendet und die Anzahl zu zählender Oks um einen erhöht. 
        public Position SetPosition(int index, double x, double y)
        {
            Position position = new Position(x, y, CurrentPosition.Z);
            string strx = position.X.ToString("0.00", new CultureInfo("en-us"));
            string stry = position.Y.ToString("0.00", new CultureInfo("en-us"));
            string strz = position.Z.ToString("0.00", new CultureInfo("en-us"));
            CurrentPosition = position;
            positions[index] = position;
            SendCommand($"@P{index}={strx} {stry} {strz} 0.0 0.0 0.0");
            SendCount++;
            return position;
        }

        // Wartet auf Oks vom Roboter. Jeder Befehl erzeugt eine Reaktion vom Roboter. Für die hier genutzten Befehle wird jeweils ein "OK" zurückgegeben. 
        // mit dem zählen der Oks wird überprüft ob der Befehl erfolgreich durchgeführt wird. 
        public bool WaitForOk(int OkCounts)
        {            
            yamaha3DPrintform.TeBox_ReadYamaha.Invoke(new Action(() =>
            {
                yamaha3DPrintform.TeBox_ReadYamaha.AppendText("WaitForOks: Count:" + (OkCounts - OkCount) + Environment.NewLine);
            }));
            while (OkCounts != OkCount)
            {
                if (ReadLine() == "OK\r")
                    OkCount++;
            }
            OkCount = 0;
            return true;
        }

        // Prüft auf neue Daten im Seriellen Buffer
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

        // Nulle den Roboter
        public void SetOrigin()
        {
            SendCommand("@?ORIGIN");
            if (WaitForOrigin() != true)
            {
                SendCommand("@ABSRST");
                WaitForOk(1);
            }
        }
        // Überprüfe ob Roboter bereits Origin erreicht hat oder nicht.
        private bool WaitForOrigin()
        {
            string recieve = "";
            while (recieve != "Complete" && recieve != "Incomplete")
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