using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.Configuration;

namespace yamaha3Dprint
{
    public class Serial
    {
        SerialPort _SerialPort;   
        public string send;
        public string recieve;

        Yamaha3DPrint form;

        byte[] eol = new byte[] { 0x0D, 0x0A };
        public Serial(string portname, int Bautrate, Yamaha3DPrint form)
        {
            _SerialPort = new SerialPort();
            _SerialPort.PortName = portname;
            _SerialPort.BaudRate = Bautrate;
            _SerialPort.ReadTimeout = 500;
            send = "";
            recieve = "";
            this.form = form;
        }    
        public void ConnectToPort()
        {
            _SerialPort.Open();
        }
        public void SendYamahaData(string data)
        {
            {
                send = data;
                _SerialPort.Write(data);
                _SerialPort.Write(eol, 0, 2);
                form.TeBox_SerialYamaha.Invoke(new Action(() =>
                {
                    form.TeBox_SerialYamaha.AppendText("Write: " + send + Environment.NewLine);
                }));
                
            }
        }
        public string getYamahaData()
        {
            try
            {
                recieve = _SerialPort.ReadLine();

            }
            catch (Exception MS)
            {
                recieve = "Not Data in ReadBuffer";
            }
            _SerialPort.DiscardInBuffer(); 
            form.TeBox_SerialYamaha.Invoke(new Action(() =>
            {
                form.TeBox_SerialYamaha.AppendText("Read: " + recieve + Environment.NewLine);
            }));
            
            return recieve;
        }
        public string getControllinoData()
        {
            try
            {
                recieve = _SerialPort.ReadLine();

            }
            catch (Exception MS)
            {
                recieve = "Not Data in ReadBuffer";
            }
            _SerialPort.DiscardInBuffer();
            form.TeBox_SerialYamaha.AppendText("Read: " + recieve + Environment.NewLine);
            return recieve;
        }
        public void SendControllinoData(string data)
        {
            {
                send = data;
                _SerialPort.Write(data);
                _SerialPort.Write(eol, 0, 2);

                form.TeBox_SerialYamaha.AppendText("Write: " + send + Environment.NewLine);
            }
        }
    }
}
