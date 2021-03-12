using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace yamaha3Dprint
{

    public partial class Yamaha3DPrint : Form
    {
        string[] fileContent = null;
        string filePath;
        bool[] SerialConnection;
        public Serial YamahaSerial;
        public Serial ControllinoSerial;
        public processGCode gcode = new processGCode();
        Task printTask;
        public void WriteYamaha( string value)
        {
            TeBox_SerialYamaha.AppendText(value + Environment.NewLine);            
        }
        public void WriteControllino(string value)
        {
            TeBox_SerialYamaha.AppendText(value + Environment.NewLine);
        }
        
        public Yamaha3DPrint()
        {
            InitializeComponent();
            filePath = string.Empty;
            Lbl_Gcode.Visible = false;
            SerialConnection = new bool[2];
        }
        public void Readfile()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "gcode (*.gcode)|*.gcode|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    fileContent = File.ReadAllLines(filePath);
                }
            }
        }
        private void CmdReadGCode_Click(object sender, EventArgs e)
        {
            Lbl_Gcode.Text = "";
            Lbl_Gcode.Visible = true;
            Lbl_Gcode.Text = "Reading GCode";
            Readfile();
            if (fileContent == null)
            {
                Lbl_Gcode.Text = "Keine gültige Datei eingelesen";
                return;
            }
            Lbl_Gcode.Text = "Ready \nZeilenanzahl: " + fileContent.Length + "\nProcessing GCode";
            fileContent = gcode.ProcessFile(fileContent);
            progressBarDruck.Maximum = fileContent.Length;
            Lbl_Gcode.Text += "\nGCodeProcesses";
        }

        private void CmdConnectDevice_Click(object sender, EventArgs e)
        {
            //if (cBoxYamaha.Text == "" || cBoxControllino.Text == "")
            //{
            //    LblConnectDevice.Visible = true;
            //    LblConnectDevice.Text = "Bitte Port Auswählen";
            //    return;
            //}
            YamahaSerial = new Serial("COM3", 9600,this);
            ControllinoSerial = new Serial("COM5", 9600,this);
            try
            {
                YamahaSerial.ConnectToPort();
                SerialConnection[0] = true;
            }
            catch (Exception ex)
            {
                TeBox_SerialYamaha.AppendText(ex.Message + Environment.NewLine);
            }
            try
            {
                ControllinoSerial.ConnectToPort();
                SerialConnection[1] = true;
            }
            catch (Exception ex)
            {
                TeBox_SerialControllino.AppendText(ex.Message + Environment.NewLine);
            }
        }

        private void CmdSendYamaha_Click(object sender, EventArgs e)
        {
            if (!SerialConnection[0])
            {
                TeBox_SerialYamaha.AppendText("Nicht Verbunden" + Environment.NewLine);
                return;
            }
            YamahaSerial.SendYamahaData(TeBox_SendYamaha.Text);
        }

        private void CmdSendControllino_Click(object sender, EventArgs e)
        {
            if (!SerialConnection[1])
            {
                TeBox_SerialControllino.AppendText("Nicht Verbunden" + Environment.NewLine);
                return;
            }
            ControllinoSerial.SendControllinoData(TeBox_SendControllino.Text);
        }

        private void CmdClearSerialYamaha_Click(object sender, EventArgs e)
        {
            TeBox_SerialYamaha.Text = "";
        }

        private void CmdClearSerialControllino_Click(object sender, EventArgs e)
        {
            TeBox_SerialControllino.Text = "";
        }

        private void CmdStartPrint_Click(object sender, EventArgs e)
        {
            if(!CheckReady())
            {
                return;
            }
            printTask = Task.Run(()=>Print());
            ;
        }
        public void Print()
        {
            List<string> PointsToWrite = new List<string>();
            List<string> WriteMove = new List<string>();
            for(int i = 0; i<fileContent.Length;i++)
            {
                if(i%7==0)
                {
                    WriteMove.Add("@MOVE L");
                }
                WriteMove[(i%98)/7]= WriteMove[(i%98)/7] + ",P" + (i%98);
                PointsToWrite.Add(gcode.writeLines(fileContent[i], i%7));
                if(i%98==0 && i>0)
                {
                    WritePointsToYamaha(PointsToWrite);
                    PointsToWrite.Clear();
                    WriteMoveToYamaha(WriteMove);
                    WriteMove.Clear();
                    WriteMove.Add("@MOVE L");
                }

                //if (i % 48 == 0)
                //{
                //    for (int j = 0; j < 7; j++)
                //    {
                //        for (int k = 0; k < 7; k++)
                //        {
                //            PointsToWrite.Add(gcode.writeLines(fileContent[i + j * 7 + k], (j * 7 + k)));
                //            writetest[j] = writetest[j] + ",P" + (k + j * 7);
                //        }
                //    }
                //    WritePointsToYamaha(PointsToWrite);
                //    PointsToWrite.Clear();
                //    if (i==0)
                //    {
                //        continue;
                //    }
                //    for(int j=0;j<7;j++)
                //    {
                //        TeBox_SerialYamaha.Invoke(new Action(() =>
                //        {
                //            YamahaSerial.SendYamahaData(writetest[j] + ",S=30");
                //            TeBox_SerialYamaha.AppendText("Send: " + writetest[j] + Environment.NewLine);
                //        }));

                //        while (YamahaSerial.getYamahaData() != "OK\r")
                //        {

                //        }
                //        TeBox_SerialYamaha.Invoke(new Action(() =>
                //        {
                //            TeBox_SerialYamaha.AppendText("Step " + (i + 1) + ": Read: " + YamahaSerial.recieve + Environment.NewLine);
                //        }));
                //    }                  
                    
                //}
               
            }

        }
        public bool CheckReady()
        {
            if(SerialConnection[0]==false) //|| SerialConnection[1]== false)
            {
                LblDruckStatus.Text = "";
                
                LblDruckStatus.Text = "Check Communication";
                return false;
            }            
            return true;
        }

        private void CmdReadYamaha_Click(object sender, EventArgs e)
        {
            string data=YamahaSerial.getYamahaData();
            TeBox_SerialYamaha.AppendText("Read: " + data + Environment.NewLine);
        }
        public void WritePointsToYamaha(List<string> points)
        {
            foreach (string i in points)
            {
                YamahaSerial.SendYamahaData(i);
                Thread.Sleep(20);
                YamahaSerial.DiscardInBuffer();
            }
        }
        public void WriteMoveToYamaha(List<string> input)
        {
            foreach (var line in input)
            {
                TeBox_SerialYamaha.Invoke(new Action(() =>
                {
                    YamahaSerial.SendYamahaData(line + ",S=30");
                    TeBox_SerialYamaha.AppendText("Send: " + line + Environment.NewLine);
                    YamahaSerial.DiscardInBuffer();
                }));

                while (YamahaSerial.getYamahaData() != "OK\r")
                {
                    Thread.Sleep(20);
                }
            }
        }
    }
}
