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
using System.Diagnostics;
using System.IO.Ports;

namespace yamaha3Dprint
{

    public partial class Yamaha3DPrint : Form
    {
        string[] fileContent = null;
        string filePath;
        int commandcounter;
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
            string[] names = SerialPort.GetPortNames();
            for(int i = 0; i<names.Length;i++)
            {
                cBoxYamaha.Items.Add(names[i]);
                cBoxControllino.Items.Add(names[i]);
            }
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
            if (yamaha == null && arduino == null)
            {
                yamaha = new Yamaha(this);
                arduino = new Arduino(this);
                yamaha.Connect(cBoxYamaha.Text, 9600);
                arduino.Connect(cBoxControllino.Text, 57600);
                LblConnectDevice.Text = "Connected";
                LblConnectDevice.Visible = true;
                CmdReadYamaha.Visible = true;
                CmdSendControllino.Visible = true;
                CmdSendYamaha.Visible = true;
                CmdReadControllino.Visible = true;
            }                 
        }

        private void CmdSendYamaha_Click(object sender, EventArgs e)
        {            
            yamaha.SendCommand(TeBox_SendYamaha.Text);
            TeBox_SerialYamaha.AppendText(TeBox_SendYamaha.Text + Environment.NewLine);
        }

        private void CmdSendControllino_Click(object sender, EventArgs e)
        {            
            arduino.Write(TeBox_SendControllino.Text);
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
            progressBarDruck.Maximum = 100;
            progressBarDruck.Step = 1;
            progressBarDruck.Value = 0;
            printTask = Task.Run(()=>Print());
        }
        public void UpdateProgessbar(int percentage)
        {
            progressBarDruck.Value = percentage;
        }
        public void UpdateRemaindingTime(int time)
        {

            LblDruckStatus.Text = "Verbleibende Druckzeit laut Slicer: " + time + "min";
        }
        public void Print()
        {
            if(filePath=="")
            {
                LblDruckStatus.Invoke(new Action(() =>
                {
                    LblDruckStatus.Text = "Bitte zuerst Gcode einlesen";
                    LblDruckStatus.Visible = true;
                }));
                return;
            }
            var test = new GcodeIO();
            var commands = test.ReadFile(filePath);
            progressBarDruck.Invoke(new Action(() =>
            {
                progressBarDruck.Maximum = commands.Count();
                LblDruckStatus.Text = "printing...";
                LblDruckStatus.Visible = true;
                Lbl_Progressbar.Text = "0 von "+ commands.Count()+ " Commands";
                Lbl_Progressbar.Visible = true;
            }));
            foreach (var i in commands)
            {
                Console.WriteLine(i);
                TeBox_SerialYamaha.Invoke(new Action(() =>
                {
                    commandcounter = commands.IndexOf(i);
                    progressBarDruck.PerformStep();
                    Lbl_Progressbar.Text = commandcounter + " von " + commands.Count();
                    TeBox_SerialYamaha.AppendText(i.ToString() + Environment.NewLine);
                }));
                i.ExecuteCommand(yamaha, arduino);                             
            }
        }
        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            yamaha.SetPosition(0, 0, 0, 0);
            yamaha.Move(0);
            arduino.Move(0);
        }

        private void CmdReadYamaha_Click(object sender, EventArgs e)
        {
            string data = yamaha.ReadLine();
            TeBox_SerialYamaha.AppendText("Read: " + data + Environment.NewLine);
        }

        private void progressBarDruck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Command "+ commandcounter + " von "+ progressBarDruck.Maximum);
        }

        private void Cmd_YamahaMove_Click(object sender, EventArgs e)
        {
            yamaha.SetPosition(0, 500.0, 0.0, 0.0);
            yamaha.SetPosition(1, 0.0, 0.0, 0.0);
            yamaha.SetPosition(2, 500.0, 0.0, 0.0);
            yamaha.SetPosition(3, 0.0, 0.0, 0.0);
            yamaha.SetPosition(4, 500.0, 0.0, 0.0);
            yamaha.SetPosition(5, 0.0, 0.0, 0.0);
            yamaha.SetPosition(6, 500.0, 0.0, 0.0);
            yamaha.SetPosition(7, 0.0, 0.0, 0.0);
            yamaha.WaitForOk(8);
            for (int i = 10; i <= 100; i += 10)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                yamaha.SendCommand("@MOVE L,P0,P1,P2,P3,P4,P5,P6,P7,S="+i);               
                yamaha.WaitForOk(1);
                stopwatch.Stop();
                TeBox_SerialYamaha.AppendText(i + stopwatch.Elapsed.ToString() + Environment.NewLine);
            }            
        }

        private void CmdReadControllino_Click(object sender, EventArgs e)
        {
            TeBox_SerialControllino.Invoke(new Action(() =>
            {
                TeBox_SerialControllino.AppendText(arduino.Read() + Environment.NewLine);
            }));
        }
    }
}
