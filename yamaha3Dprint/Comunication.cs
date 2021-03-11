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

        byte[] eol = new byte[] { 0x0D, 0x0A };
        public Serial(string portname, int Bautrate)
        {
            _SerialPort = new SerialPort();
            _SerialPort.PortName = portname;
            _SerialPort.BaudRate = Bautrate;
            _SerialPort.ReadTimeout = 500;
        }    
        public void ConnectToPort()
        {
            _SerialPort.Open();
        }
        public void SendData(string data)
        {
            {
                _SerialPort.Write(data);
                _SerialPort.Write(eol, 0, 2);
            }
        }
        public string getData()
        {
            return _SerialPort.ReadLine();
        }
    }
}
