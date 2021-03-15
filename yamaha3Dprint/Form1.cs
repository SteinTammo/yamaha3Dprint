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
        public Yamaha yamaha;
        public Arduino arduino;
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
                    var test = new GcodeIO();
                    yamaha = new Yamaha();
                    arduino = new Arduino();
                                        
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
            //fileContent = gcode.ProcessFile(fileContent);
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
            yamaha.Connect("COM3", 9600);            
            //ControllinoSerial = new Serial("COM5", 9600,this);            
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
            printTask = Task.Run(()=>Print());
        }
        public void Print()
        {
            var test = new GcodeIO();
            var commands = test.ReadFile(filePath);
            foreach (var i in commands)
            {
                i.ExecuteCommand(yamaha, null);
            }
        }      
        

        private void CmdReadYamaha_Click(object sender, EventArgs e)
        {
            string data=YamahaSerial.getYamahaData();
            TeBox_SerialYamaha.AppendText("Read: " + data + Environment.NewLine);
        }
    }
}
