﻿using System;
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

namespace yamaha3Dprint
{

    public partial class Yamaha3DPrint : Form
    {
        string[] fileContent = null;
        string filePath;
        bool[] SerialConnection;
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
                    yamaha = new Yamaha(this);
                    arduino = new Arduino(this);
                                        
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
            yamaha.Connect("COM8", 9600);
            arduino.Connect("COM5", 56000);   
        }

        private void CmdSendYamaha_Click(object sender, EventArgs e)
        {            
            yamaha.SendCommand(TeBox_SendYamaha.Text);
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
            var test = new GcodeIO();
            var commands = test.ReadFile(filePath);
            progressBarDruck.Invoke(new Action(() =>
            {
                progressBarDruck.Maximum = commands.Count();
            }));
            foreach (var i in commands)
            {
                Console.WriteLine(i);
                TeBox_SerialYamaha.Invoke(new Action(() =>
                {
                    commandcounter = commands.IndexOf(i);
                    progressBarDruck.PerformStep();
                    TeBox_SerialYamaha.AppendText(i.ToString() + Environment.NewLine);
                }));
                i.ExecuteCommand(yamaha, arduino);                             
            }
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
    }
}
