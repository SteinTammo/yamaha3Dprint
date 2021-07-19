using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yamaha3Dprint
{

    public partial class Yamaha3DPrint : Form
    {
        string[] fileContent = null;
        string filePath;
        int commandcounter;
        public processGCode gcode = new processGCode();
        public Yamaha yamaha;
        public Arduino arduino;
        Task printTask;
        CancellationTokenSource source;

        public Yamaha3DPrint()
        {
            InitializeComponent();
            filePath = string.Empty;
            Lbl_Gcode.Visible = false;
            string[] names = SerialPort.GetPortNames();
            for (int i = 0; i < names.Length; i++)
            {
                cBoxYamaha.Items.Add(names[i]);
                cBoxArduino.Items.Add(names[i]);
            }
            source = new CancellationTokenSource();
            cBoxYamaha.Text = "COM8";
            cBoxArduino.Text = "COM5";
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

                    //Auskommentieren für Kriesbewegungen
                    //Funktioniert noch nicht

                    /*
                    string pathwithoutname = Path.ChangeExtension(filePath, null);
                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.Start();
                    string arcwelderpath = @"ArcWelder.exe";
                    string outputpath = pathwithoutname + "_processed.gcode";
                    cmd.StandardInput.WriteLine(arcwelderpath + " -m=5000 \"" + filePath + "\" \"" + outputpath + "\"");
                    Console.WriteLine(arcwelderpath + " -m=5000 \"" + filePath + "\" \"" + outputpath + "\"");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    cmd.WaitForExit();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                    Thread.Sleep(1000);
                    filePath = outputpath;
                    */
                    fileContent = File.ReadAllLines(filePath);
                }


            }
        }
        // Sammelt die Exceptions und gibt sie aus. 
        public void ConnectException(Exception m)
        {
            LblConnectDevice.Visible = true;
            LblConnectDevice.Text = m.Message;
        }

        // Methode zum Einlesen des Gcodes
        private void CmdReadGCode_Click(object sender, EventArgs e)
        {
            Lbl_Gcode.Text = "";
            Lbl_Gcode.Visible = true;
            Lbl_Gcode.Text = "Reading GCode";
            Readfile(); //Hier ist das eigentliche Einlesen
            if (fileContent == null)
            {
                Lbl_Gcode.Text = "Keine gültige Datei eingelesen";
                return;
            }
            Lbl_Gcode.Text = "Ready \nZeilenanzahl: " + fileContent.Length + "\nProcessing GCode";
            progressBarDruck.Maximum = fileContent.Length;
            Lbl_Gcode.Text += "\nGCodeProcesses";
        }

        //Methode zum Öffnen der seriellen Schnittstellen. Übergibt baudrate und Port und checkt ob die Schnittstelle aufgebaut werden kann. 
        private void CmdConnectDevice_Click(object sender, EventArgs e)
        {
            if (cBoxYamaha.Text == "" || cBoxArduino.Text == "")
            {
                LblConnectDevice.Visible = true;
                LblConnectDevice.Text = "Bitte Port Auswählen";
                return;
            }
            if (yamaha == null && arduino == null)
            {
                yamaha = new Yamaha(this);
                arduino = new Arduino(this);
                bool connectedy = yamaha.Connect(cBoxYamaha.Text, 9600);
                bool connecteda = arduino.Connect(cBoxArduino.Text, 57600);

                // wenn Schnittstelle vorhanden stelle buttons zur verfügung
                if(connecteda==true && connectedy==true)
                {
                    LblConnectDevice.Text = "Connected";
                    LblConnectDevice.Visible = true;
                    CmdReadYamaha.Visible = true;
                    CmdSendArduino.Visible = true;
                    CmdSendYamaha.Visible = true;
                    CmdReadArduino.Visible = true;
                    CmdStartPrint.Visible = true;
                    Lbl_Temperatur_LoadFIlament.Visible = true;
                    TeBox_LoadFilament.Visible = true;
                    Cmd_LoadFilament.Visible = true;
                    Cmd_UnloadFilament.Visible = true;
                    progressBarDruck.Visible = true;
                }
                // wenn nicht Instanzen wieder Löschen.
                else
                {
                    yamaha = null;
                    arduino = null;
                }
            }
        }
        // Sendet String an den Roboter. Hier können die yamaha Befehle Manuell eingeben werden.  
        private void CmdSendYamaha_Click(object sender, EventArgs e)
        {
            yamaha.SendCommand(TeBox_SendYamaha.Text);
            TeBox_ReadYamaha.AppendText(TeBox_SendYamaha.Text + Environment.NewLine);
        }

        // Sendet Test an den Arduino
        private void CmdSendControllino_Click(object sender, EventArgs e)
        {
            arduino.Write(TeBox_SendArduino.Text);
            TeBox_SerialArduinoWrite.Invoke(new Action(() =>
            {
                TeBox_SerialArduinoRead.AppendText(arduino.Read() + Environment.NewLine);
            }));
        }

        private void CmdClearSerialYamaha_Click(object sender, EventArgs e)
        {
            TeBox_ReadYamaha.Text = "";
            TeBox_SendYamaha.Text = "";
            TeBoxSendYamaha.Text = "";
        }

        private void CmdClearSerialControllino_Click(object sender, EventArgs e)
        {
            TeBox_SerialArduinoWrite.Text = "";
            TeBox_SerialArduinoRead.Text = "";
        }

        private void CmdStartPrint_Click(object sender, EventArgs e)
        {
            progressBarDruck.Maximum = 100;
            progressBarDruck.Step = 1;
            progressBarDruck.Value = 0;
            source = new CancellationTokenSource();
            var token = source.Token;

            //Parallele Programmabfolge über Tasks: Methode Print() wird in einem weiteren Task ausgeführt. 
            printTask = Task.Run(() => Print(token), token);
            CmdStopPrint.Visible = true;
        }
        public void UpdateProgessbar(int percentage)
        {
            progressBarDruck.Value = percentage;
        }
        public void UpdateRemaindingTime(int time)
        {

            LblDruckStatus.Text = "Verbleibende Druckzeit laut Slicer: " + time + "min";
        }

        // Eigentlicher Druckprozess. Wird nebenbei Ausgeführt, wenn Taste gedrückt wird. Der CancellationToken dient dafür den Ablauf abzubrechen. 
        public void Print(CancellationToken token)
        {
            yamaha.DiscardInBuffer();
            if (filePath == "")
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
                Lbl_Progressbar.Text = "0 von " + commands.Count() + " Commands";
                Lbl_Progressbar.Visible = true;
            }));
            foreach (var i in commands)
            {
                Console.WriteLine(i);
                TeBox_ReadYamaha.Invoke(new Action(() =>
                {
                    commandcounter = commands.IndexOf(i);
                    progressBarDruck.PerformStep();
                    Lbl_Progressbar.Text = commandcounter + " von " + commands.Count();
                    TeBox_Programmablauf.AppendText(i.ToString() + Environment.NewLine);
                }));
                i.ExecuteCommand(yamaha, arduino);
                if (token.IsCancellationRequested)
                {
                    progressBarDruck.Invoke(new Action(() =>
                    {
                        progressBarDruck.Maximum = 100;
                        progressBarDruck.Step = 1;
                        progressBarDruck.Value = 0;

                    }));
                    arduino.Move(0);
                    yamaha.SetPosition(0, 0, 0, 0);
                    yamaha.Move(0);
                    yamaha.WaitForOk(2);
                    return;
                }
            }
        }

        internal void SendCommand(string data)
        {
            TeBoxSendYamaha.Invoke(new Action(() =>
            {
                TeBoxSendYamaha.AppendText(data + Environment.NewLine);
            }));
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (arduino == null && yamaha == null)
            {
                return;
            }
            arduino.SetETempWithoutOk(0);
            arduino.SetBTempWithoutOk(0);
            arduino.Move(0);
            yamaha.SetPosition(0, 0, 0, 0);
            yamaha.Move(0);
        }

        private void CmdReadYamaha_Click(object sender, EventArgs e)
        {
            string data = yamaha.ReadLine();
            TeBox_ReadYamaha.AppendText("Read: " + data + Environment.NewLine);
        }

        private void progressBarDruck_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Command " + commandcounter + " von " + progressBarDruck.Maximum);
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
                yamaha.SendCommand("@MOVE L,P0,P1,P2,P3,P4,P5,P6,P7,S=" + i);
                yamaha.WaitForOk(1);
                stopwatch.Stop();
                TeBox_ReadYamaha.AppendText(i + stopwatch.Elapsed.ToString() + Environment.NewLine);
            }
        }

        private void CmdReadControllino_Click(object sender, EventArgs e)
        {
            TeBox_SerialArduinoWrite.Invoke(new Action(() =>
            {
                TeBox_SerialArduinoWrite.AppendText(arduino.Read() + Environment.NewLine);
            }));
        }

        private void Cmd_LoadFilament_Click(object sender, EventArgs e)
        {
            if (Cmd_LoadFilament.Text == "Load Filament")
            {
                arduino.SetETemp(Convert.ToInt32(TeBox_LoadFilament.Text));
                arduino.SetFlow(800);
                arduino.Move(1);
                Cmd_LoadFilament.Text = "Stop Loading";
            }
            else if (Cmd_LoadFilament.Text == "Stop Loading")
            {
                arduino.Move(0);
                Cmd_LoadFilament.Text = "Load Filament";
            }
        }

        private void CmdStopPrint_Click(object sender, EventArgs e)
        {
            source.Cancel();
            CmdStopPrint.Visible = false;
        }

        private void Cmd_Safe_Multiplier_Click(object sender, EventArgs e)
        {
            arduino.SetFlowMultiplier(double.Parse(TeBox_Flow_Multiplier.Text));
        }

        private void Cmd_Clear_Programmablauf_Click(object sender, EventArgs e)
        {
            TeBox_Programmablauf.Text = "";
        }

        private void Cmd_HelpSetup_Click(object sender, EventArgs e)
        {
            UseHelp f1 = new UseHelp();
            f1.ShowDialog();
        }

        private void Cmd_HelpArduino_Click(object sender, EventArgs e)
        {
            ArduinoHelp AH = new ArduinoHelp();
            AH.ShowDialog();
        }

        private void Cmd_UnloadFilament_Click(object sender, EventArgs e)
        {
            if (Cmd_UnloadFilament.Text == "Unload Filament")
            {
                arduino.SetETemp(Convert.ToInt32(TeBox_LoadFilament.Text));
                arduino.SetFlow(800);
                arduino.Move(-1);
                Cmd_UnloadFilament.Text = "Stop Unloading";
            }
            else if (Cmd_UnloadFilament.Text == "Stop Unloading")
            {
                arduino.Move(0);
                Cmd_UnloadFilament.Text = "Unload Filament";
            }
        }
    }
}
