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
            if (cBoxYamaha.Text == "" || cBoxControllino.Text == "")
            {
                LblConnectDevice.Visible = true;
                LblConnectDevice.Text = "Bitte Port Auswählen";
                return;
            }
            YamahaSerial = new Serial(cBoxYamaha.Text, 9600);
            ControllinoSerial = new Serial(cBoxControllino.Text, 9600);
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
            YamahaSerial.SendData(TeBox_SendYamaha.Text);
        }

        private void CmdSendControllino_Click(object sender, EventArgs e)
        {
            if (!SerialConnection[1])
            {
                TeBox_SerialControllino.AppendText("Nicht Verbunden" + Environment.NewLine);
                return;
            }
            ControllinoSerial.SendData(TeBox_SendControllino.Text);
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
            string[] writelines;
            writelines = new string[2];
            bool firstmove = true;
            for (int i=0;i<fileContent.Length;i++)
            {
                if (firstmove==true || YamahaSerial.getData()!="OK")
                {
                    firstmove = false;
                }                    
                writelines = gcode.writeLines(fileContent[i]);
                YamahaSerial.SendData(writelines[0]);
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
    }
}
