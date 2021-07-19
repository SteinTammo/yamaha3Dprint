namespace yamaha3Dprint
{
    partial class Yamaha3DPrint
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yamaha3DPrint));
            this.CmdReadGCode = new System.Windows.Forms.Button();
            this.Lbl_Gcode = new System.Windows.Forms.Label();
            this.CmdConnectDevice = new System.Windows.Forms.Button();
            this.LblConnectDevice = new System.Windows.Forms.Label();
            this.TeBox_ReadYamaha = new System.Windows.Forms.TextBox();
            this.TeBox_SerialArduinoWrite = new System.Windows.Forms.TextBox();
            this.Lbl_SerialYamaha = new System.Windows.Forms.Label();
            this.Lbl_Serial_Arduino = new System.Windows.Forms.Label();
            this.CmdSendYamaha = new System.Windows.Forms.Button();
            this.TeBox_SendYamaha = new System.Windows.Forms.TextBox();
            this.TeBox_SendArduino = new System.Windows.Forms.TextBox();
            this.CmdSendArduino = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxYamaha = new System.Windows.Forms.ComboBox();
            this.cBoxArduino = new System.Windows.Forms.ComboBox();
            this.CmdStartPrint = new System.Windows.Forms.Button();
            this.CmdClearSerialYamaha = new System.Windows.Forms.Button();
            this.CmdClearSerialControllino = new System.Windows.Forms.Button();
            this.progressBarDruck = new System.Windows.Forms.ProgressBar();
            this.LblDruckStatus = new System.Windows.Forms.Label();
            this.CmdReadYamaha = new System.Windows.Forms.Button();
            this.TeBox_SerialArduinoRead = new System.Windows.Forms.TextBox();
            this.Cmd_YamahaMove = new System.Windows.Forms.Button();
            this.CmdReadArduino = new System.Windows.Forms.Button();
            this.Lbl_Progressbar = new System.Windows.Forms.Label();
            this.Cmd_UnloadFilament = new System.Windows.Forms.Button();
            this.Cmd_LoadFilament = new System.Windows.Forms.Button();
            this.CmdStopPrint = new System.Windows.Forms.Button();
            this.TeBox_Flow_Multiplier = new System.Windows.Forms.TextBox();
            this.Cmd_Safe_Multiplier = new System.Windows.Forms.Button();
            this.toolTipSaveMultiplier = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipreadGcode = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipConnectDevices = new System.Windows.Forms.ToolTip(this.components);
            this.Cmd_HelpSetup = new System.Windows.Forms.Button();
            this.toolTipStartPrint = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipStopPrint = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSendYamaha = new System.Windows.Forms.ToolTip(this.components);
            this.TeBoxSendYamaha = new System.Windows.Forms.TextBox();
            this.TeBox_LoadFilament = new System.Windows.Forms.TextBox();
            this.Lbl_Temperatur_LoadFIlament = new System.Windows.Forms.Label();
            this.TeBox_Programmablauf = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmd_Clear_Programmablauf = new System.Windows.Forms.Button();
            this.Cmd_HelpArduino = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CmdReadGCode
            // 
            this.CmdReadGCode.Location = new System.Drawing.Point(12, 12);
            this.CmdReadGCode.Name = "CmdReadGCode";
            this.CmdReadGCode.Size = new System.Drawing.Size(83, 39);
            this.CmdReadGCode.TabIndex = 1;
            this.CmdReadGCode.Text = "Read GCode";
            this.toolTipreadGcode.SetToolTip(this.CmdReadGCode, "Öffnet Fenster zum Einlesen der GCode-Datei, die vorher vom Prusaslicer erstellt " +
        "wurde.");
            this.CmdReadGCode.UseVisualStyleBackColor = true;
            this.CmdReadGCode.Click += new System.EventHandler(this.CmdReadGCode_Click);
            // 
            // Lbl_Gcode
            // 
            this.Lbl_Gcode.AutoSize = true;
            this.Lbl_Gcode.Location = new System.Drawing.Point(12, 54);
            this.Lbl_Gcode.Name = "Lbl_Gcode";
            this.Lbl_Gcode.Size = new System.Drawing.Size(30, 13);
            this.Lbl_Gcode.TabIndex = 2;
            this.Lbl_Gcode.Text = "(leer)";
            // 
            // CmdConnectDevice
            // 
            this.CmdConnectDevice.Location = new System.Drawing.Point(101, 12);
            this.CmdConnectDevice.Name = "CmdConnectDevice";
            this.CmdConnectDevice.Size = new System.Drawing.Size(96, 39);
            this.CmdConnectDevice.TabIndex = 3;
            this.CmdConnectDevice.Text = "Connect Devices ";
            this.toolTipConnectDevices.SetToolTip(this.CmdConnectDevice, resources.GetString("CmdConnectDevice.ToolTip"));
            this.CmdConnectDevice.UseVisualStyleBackColor = true;
            this.CmdConnectDevice.Click += new System.EventHandler(this.CmdConnectDevice_Click);
            // 
            // LblConnectDevice
            // 
            this.LblConnectDevice.AutoSize = true;
            this.LblConnectDevice.Location = new System.Drawing.Point(98, 54);
            this.LblConnectDevice.Name = "LblConnectDevice";
            this.LblConnectDevice.Size = new System.Drawing.Size(30, 13);
            this.LblConnectDevice.TabIndex = 4;
            this.LblConnectDevice.Text = "(leer)";
            this.LblConnectDevice.Visible = false;
            // 
            // TeBox_ReadYamaha
            // 
            this.TeBox_ReadYamaha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeBox_ReadYamaha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TeBox_ReadYamaha.Location = new System.Drawing.Point(328, 178);
            this.TeBox_ReadYamaha.Multiline = true;
            this.TeBox_ReadYamaha.Name = "TeBox_ReadYamaha";
            this.TeBox_ReadYamaha.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_ReadYamaha.Size = new System.Drawing.Size(310, 322);
            this.TeBox_ReadYamaha.TabIndex = 6;
            // 
            // TeBox_SerialArduinoWrite
            // 
            this.TeBox_SerialArduinoWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeBox_SerialArduinoWrite.Location = new System.Drawing.Point(656, 178);
            this.TeBox_SerialArduinoWrite.MaxLength = 65000;
            this.TeBox_SerialArduinoWrite.Multiline = true;
            this.TeBox_SerialArduinoWrite.Name = "TeBox_SerialArduinoWrite";
            this.TeBox_SerialArduinoWrite.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_SerialArduinoWrite.Size = new System.Drawing.Size(310, 322);
            this.TeBox_SerialArduinoWrite.TabIndex = 6;
            // 
            // Lbl_SerialYamaha
            // 
            this.Lbl_SerialYamaha.AutoSize = true;
            this.Lbl_SerialYamaha.Location = new System.Drawing.Point(13, 507);
            this.Lbl_SerialYamaha.Name = "Lbl_SerialYamaha";
            this.Lbl_SerialYamaha.Size = new System.Drawing.Size(75, 13);
            this.Lbl_SerialYamaha.TabIndex = 7;
            this.Lbl_SerialYamaha.Text = "Serial Yamaha";
            // 
            // Lbl_Serial_Arduino
            // 
            this.Lbl_Serial_Arduino.AutoSize = true;
            this.Lbl_Serial_Arduino.Location = new System.Drawing.Point(659, 506);
            this.Lbl_Serial_Arduino.Name = "Lbl_Serial_Arduino";
            this.Lbl_Serial_Arduino.Size = new System.Drawing.Size(72, 13);
            this.Lbl_Serial_Arduino.TabIndex = 8;
            this.Lbl_Serial_Arduino.Text = "Serial Arduino";
            // 
            // CmdSendYamaha
            // 
            this.CmdSendYamaha.Location = new System.Drawing.Point(398, 150);
            this.CmdSendYamaha.Name = "CmdSendYamaha";
            this.CmdSendYamaha.Size = new System.Drawing.Size(75, 23);
            this.CmdSendYamaha.TabIndex = 9;
            this.CmdSendYamaha.Text = "Send";
            this.CmdSendYamaha.UseVisualStyleBackColor = true;
            this.CmdSendYamaha.Visible = false;
            this.CmdSendYamaha.Click += new System.EventHandler(this.CmdSendYamaha_Click);
            // 
            // TeBox_SendYamaha
            // 
            this.TeBox_SendYamaha.Location = new System.Drawing.Point(12, 152);
            this.TeBox_SendYamaha.Name = "TeBox_SendYamaha";
            this.TeBox_SendYamaha.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TeBox_SendYamaha.Size = new System.Drawing.Size(380, 20);
            this.TeBox_SendYamaha.TabIndex = 10;
            // 
            // TeBox_SendArduino
            // 
            this.TeBox_SendArduino.Location = new System.Drawing.Point(656, 150);
            this.TeBox_SendArduino.Name = "TeBox_SendArduino";
            this.TeBox_SendArduino.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TeBox_SendArduino.Size = new System.Drawing.Size(380, 20);
            this.TeBox_SendArduino.TabIndex = 11;
            // 
            // CmdSendArduino
            // 
            this.CmdSendArduino.Location = new System.Drawing.Point(1042, 147);
            this.CmdSendArduino.Name = "CmdSendArduino";
            this.CmdSendArduino.Size = new System.Drawing.Size(75, 23);
            this.CmdSendArduino.TabIndex = 12;
            this.CmdSendArduino.Text = "Send";
            this.CmdSendArduino.UseVisualStyleBackColor = true;
            this.CmdSendArduino.Visible = false;
            this.CmdSendArduino.Click += new System.EventHandler(this.CmdSendControllino_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Port Yamaha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(652, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port Arduino:";
            // 
            // cBoxYamaha
            // 
            this.cBoxYamaha.FormattingEnabled = true;
            this.cBoxYamaha.Location = new System.Drawing.Point(124, 114);
            this.cBoxYamaha.Name = "cBoxYamaha";
            this.cBoxYamaha.Size = new System.Drawing.Size(121, 21);
            this.cBoxYamaha.TabIndex = 18;
            // 
            // cBoxArduino
            // 
            this.cBoxArduino.FormattingEnabled = true;
            this.cBoxArduino.Location = new System.Drawing.Point(759, 114);
            this.cBoxArduino.Name = "cBoxArduino";
            this.cBoxArduino.Size = new System.Drawing.Size(121, 21);
            this.cBoxArduino.TabIndex = 19;
            // 
            // CmdStartPrint
            // 
            this.CmdStartPrint.Location = new System.Drawing.Point(656, 12);
            this.CmdStartPrint.Name = "CmdStartPrint";
            this.CmdStartPrint.Size = new System.Drawing.Size(75, 39);
            this.CmdStartPrint.TabIndex = 20;
            this.CmdStartPrint.Text = "Start Print";
            this.toolTipStartPrint.SetToolTip(this.CmdStartPrint, "Startet den Druckvorgang. \r\nVorher muss ein gültiger GCode eingelesen und die Ger" +
        "äte verbunden werden. \r\n");
            this.CmdStartPrint.UseVisualStyleBackColor = true;
            this.CmdStartPrint.Visible = false;
            this.CmdStartPrint.Click += new System.EventHandler(this.CmdStartPrint_Click);
            // 
            // CmdClearSerialYamaha
            // 
            this.CmdClearSerialYamaha.Location = new System.Drawing.Point(563, 502);
            this.CmdClearSerialYamaha.Name = "CmdClearSerialYamaha";
            this.CmdClearSerialYamaha.Size = new System.Drawing.Size(75, 21);
            this.CmdClearSerialYamaha.TabIndex = 21;
            this.CmdClearSerialYamaha.Text = "Clear";
            this.CmdClearSerialYamaha.UseVisualStyleBackColor = true;
            this.CmdClearSerialYamaha.Click += new System.EventHandler(this.CmdClearSerialYamaha_Click);
            // 
            // CmdClearSerialControllino
            // 
            this.CmdClearSerialControllino.Location = new System.Drawing.Point(1207, 502);
            this.CmdClearSerialControllino.Name = "CmdClearSerialControllino";
            this.CmdClearSerialControllino.Size = new System.Drawing.Size(75, 23);
            this.CmdClearSerialControllino.TabIndex = 22;
            this.CmdClearSerialControllino.Text = "Clear";
            this.CmdClearSerialControllino.UseVisualStyleBackColor = true;
            this.CmdClearSerialControllino.Click += new System.EventHandler(this.CmdClearSerialControllino_Click);
            // 
            // progressBarDruck
            // 
            this.progressBarDruck.Location = new System.Drawing.Point(656, 57);
            this.progressBarDruck.Name = "progressBarDruck";
            this.progressBarDruck.Size = new System.Drawing.Size(232, 23);
            this.progressBarDruck.TabIndex = 23;
            this.progressBarDruck.Visible = false;
            this.progressBarDruck.Click += new System.EventHandler(this.progressBarDruck_Click);
            // 
            // LblDruckStatus
            // 
            this.LblDruckStatus.AutoSize = true;
            this.LblDruckStatus.Location = new System.Drawing.Point(653, 83);
            this.LblDruckStatus.Name = "LblDruckStatus";
            this.LblDruckStatus.Size = new System.Drawing.Size(30, 13);
            this.LblDruckStatus.TabIndex = 24;
            this.LblDruckStatus.Text = "(leer)";
            this.LblDruckStatus.Visible = false;
            // 
            // CmdReadYamaha
            // 
            this.CmdReadYamaha.Location = new System.Drawing.Point(479, 150);
            this.CmdReadYamaha.Name = "CmdReadYamaha";
            this.CmdReadYamaha.Size = new System.Drawing.Size(75, 23);
            this.CmdReadYamaha.TabIndex = 25;
            this.CmdReadYamaha.Text = "Read";
            this.CmdReadYamaha.UseVisualStyleBackColor = true;
            this.CmdReadYamaha.Visible = false;
            this.CmdReadYamaha.Click += new System.EventHandler(this.CmdReadYamaha_Click);
            // 
            // TeBox_SerialArduinoRead
            // 
            this.TeBox_SerialArduinoRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeBox_SerialArduinoRead.Location = new System.Drawing.Point(972, 178);
            this.TeBox_SerialArduinoRead.MaxLength = 65000;
            this.TeBox_SerialArduinoRead.Multiline = true;
            this.TeBox_SerialArduinoRead.Name = "TeBox_SerialArduinoRead";
            this.TeBox_SerialArduinoRead.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_SerialArduinoRead.Size = new System.Drawing.Size(310, 322);
            this.TeBox_SerialArduinoRead.TabIndex = 6;
            // 
            // Cmd_YamahaMove
            // 
            this.Cmd_YamahaMove.Location = new System.Drawing.Point(398, 121);
            this.Cmd_YamahaMove.Name = "Cmd_YamahaMove";
            this.Cmd_YamahaMove.Size = new System.Drawing.Size(75, 23);
            this.Cmd_YamahaMove.TabIndex = 26;
            this.Cmd_YamahaMove.Text = "Measure";
            this.Cmd_YamahaMove.UseVisualStyleBackColor = true;
            this.Cmd_YamahaMove.Visible = false;
            this.Cmd_YamahaMove.Click += new System.EventHandler(this.Cmd_YamahaMove_Click);
            // 
            // CmdReadArduino
            // 
            this.CmdReadArduino.Location = new System.Drawing.Point(1123, 148);
            this.CmdReadArduino.Name = "CmdReadArduino";
            this.CmdReadArduino.Size = new System.Drawing.Size(75, 23);
            this.CmdReadArduino.TabIndex = 27;
            this.CmdReadArduino.Text = "Read";
            this.CmdReadArduino.UseVisualStyleBackColor = true;
            this.CmdReadArduino.Visible = false;
            this.CmdReadArduino.Click += new System.EventHandler(this.CmdReadControllino_Click);
            // 
            // Lbl_Progressbar
            // 
            this.Lbl_Progressbar.AutoSize = true;
            this.Lbl_Progressbar.Location = new System.Drawing.Point(821, 83);
            this.Lbl_Progressbar.Name = "Lbl_Progressbar";
            this.Lbl_Progressbar.Size = new System.Drawing.Size(30, 13);
            this.Lbl_Progressbar.TabIndex = 28;
            this.Lbl_Progressbar.Text = "(leer)";
            this.Lbl_Progressbar.Visible = false;
            // 
            // Cmd_UnloadFilament
            // 
            this.Cmd_UnloadFilament.Location = new System.Drawing.Point(968, 57);
            this.Cmd_UnloadFilament.Name = "Cmd_UnloadFilament";
            this.Cmd_UnloadFilament.Size = new System.Drawing.Size(75, 39);
            this.Cmd_UnloadFilament.TabIndex = 29;
            this.Cmd_UnloadFilament.Text = "Unload Filament";
            this.Cmd_UnloadFilament.UseVisualStyleBackColor = true;
            this.Cmd_UnloadFilament.Visible = false;
            this.Cmd_UnloadFilament.Click += new System.EventHandler(this.Cmd_UnloadFilament_Click);
            // 
            // Cmd_LoadFilament
            // 
            this.Cmd_LoadFilament.Location = new System.Drawing.Point(968, 12);
            this.Cmd_LoadFilament.Name = "Cmd_LoadFilament";
            this.Cmd_LoadFilament.Size = new System.Drawing.Size(75, 39);
            this.Cmd_LoadFilament.TabIndex = 30;
            this.Cmd_LoadFilament.Text = "Load Filament";
            this.Cmd_LoadFilament.UseVisualStyleBackColor = true;
            this.Cmd_LoadFilament.Visible = false;
            this.Cmd_LoadFilament.Click += new System.EventHandler(this.Cmd_LoadFilament_Click);
            // 
            // CmdStopPrint
            // 
            this.CmdStopPrint.Location = new System.Drawing.Point(737, 12);
            this.CmdStopPrint.Name = "CmdStopPrint";
            this.CmdStopPrint.Size = new System.Drawing.Size(75, 39);
            this.CmdStopPrint.TabIndex = 32;
            this.CmdStopPrint.Text = "Stop Print";
            this.toolTipStopPrint.SetToolTip(this.CmdStopPrint, "Stoppt den Druck und fährt auf die Home-Position");
            this.CmdStopPrint.UseVisualStyleBackColor = true;
            this.CmdStopPrint.Visible = false;
            this.CmdStopPrint.Click += new System.EventHandler(this.CmdStopPrint_Click);
            // 
            // TeBox_Flow_Multiplier
            // 
            this.TeBox_Flow_Multiplier.Location = new System.Drawing.Point(1198, 64);
            this.TeBox_Flow_Multiplier.Name = "TeBox_Flow_Multiplier";
            this.TeBox_Flow_Multiplier.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TeBox_Flow_Multiplier.Size = new System.Drawing.Size(84, 20);
            this.TeBox_Flow_Multiplier.TabIndex = 34;
            this.TeBox_Flow_Multiplier.Text = "0.1666";
            // 
            // Cmd_Safe_Multiplier
            // 
            this.Cmd_Safe_Multiplier.Location = new System.Drawing.Point(1198, 19);
            this.Cmd_Safe_Multiplier.Name = "Cmd_Safe_Multiplier";
            this.Cmd_Safe_Multiplier.Size = new System.Drawing.Size(84, 39);
            this.Cmd_Safe_Multiplier.TabIndex = 33;
            this.Cmd_Safe_Multiplier.Text = "Save Flowmultiplier";
            this.toolTipSaveMultiplier.SetToolTip(this.Cmd_Safe_Multiplier, "Setze das Verhältnis von der Extruderdrehzahl und der Floweinstellung des GCodes." +
        " ");
            this.Cmd_Safe_Multiplier.UseVisualStyleBackColor = true;
            this.Cmd_Safe_Multiplier.Click += new System.EventHandler(this.Cmd_Safe_Multiplier_Click);
            // 
            // Cmd_HelpSetup
            // 
            this.Cmd_HelpSetup.Location = new System.Drawing.Point(328, 12);
            this.Cmd_HelpSetup.Name = "Cmd_HelpSetup";
            this.Cmd_HelpSetup.Size = new System.Drawing.Size(96, 39);
            this.Cmd_HelpSetup.TabIndex = 41;
            this.Cmd_HelpSetup.Text = "Help Setup";
            this.toolTipConnectDevices.SetToolTip(this.Cmd_HelpSetup, resources.GetString("Cmd_HelpSetup.ToolTip"));
            this.Cmd_HelpSetup.UseVisualStyleBackColor = true;
            this.Cmd_HelpSetup.Click += new System.EventHandler(this.Cmd_HelpSetup_Click);
            // 
            // TeBoxSendYamaha
            // 
            this.TeBoxSendYamaha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeBoxSendYamaha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TeBoxSendYamaha.Location = new System.Drawing.Point(12, 178);
            this.TeBoxSendYamaha.Multiline = true;
            this.TeBoxSendYamaha.Name = "TeBoxSendYamaha";
            this.TeBoxSendYamaha.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBoxSendYamaha.Size = new System.Drawing.Size(310, 322);
            this.TeBoxSendYamaha.TabIndex = 35;
            // 
            // TeBox_LoadFilament
            // 
            this.TeBox_LoadFilament.Location = new System.Drawing.Point(1086, 31);
            this.TeBox_LoadFilament.Name = "TeBox_LoadFilament";
            this.TeBox_LoadFilament.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TeBox_LoadFilament.Size = new System.Drawing.Size(74, 20);
            this.TeBox_LoadFilament.TabIndex = 36;
            this.TeBox_LoadFilament.Text = "230";
            this.TeBox_LoadFilament.Visible = false;
            // 
            // Lbl_Temperatur_LoadFIlament
            // 
            this.Lbl_Temperatur_LoadFIlament.AutoSize = true;
            this.Lbl_Temperatur_LoadFIlament.Location = new System.Drawing.Point(1083, 54);
            this.Lbl_Temperatur_LoadFIlament.Name = "Lbl_Temperatur_LoadFIlament";
            this.Lbl_Temperatur_LoadFIlament.Size = new System.Drawing.Size(67, 13);
            this.Lbl_Temperatur_LoadFIlament.TabIndex = 37;
            this.Lbl_Temperatur_LoadFIlament.Text = "Temperature";
            this.Lbl_Temperatur_LoadFIlament.Visible = false;
            // 
            // TeBox_Programmablauf
            // 
            this.TeBox_Programmablauf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TeBox_Programmablauf.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TeBox_Programmablauf.Location = new System.Drawing.Point(12, 531);
            this.TeBox_Programmablauf.Multiline = true;
            this.TeBox_Programmablauf.Name = "TeBox_Programmablauf";
            this.TeBox_Programmablauf.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_Programmablauf.Size = new System.Drawing.Size(1270, 135);
            this.TeBox_Programmablauf.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 685);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Programm";
            // 
            // Cmd_Clear_Programmablauf
            // 
            this.Cmd_Clear_Programmablauf.Location = new System.Drawing.Point(1207, 680);
            this.Cmd_Clear_Programmablauf.Name = "Cmd_Clear_Programmablauf";
            this.Cmd_Clear_Programmablauf.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Clear_Programmablauf.TabIndex = 40;
            this.Cmd_Clear_Programmablauf.Text = "Clear";
            this.Cmd_Clear_Programmablauf.UseVisualStyleBackColor = true;
            this.Cmd_Clear_Programmablauf.Click += new System.EventHandler(this.Cmd_Clear_Programmablauf_Click);
            // 
            // Cmd_HelpArduino
            // 
            this.Cmd_HelpArduino.Location = new System.Drawing.Point(1198, 96);
            this.Cmd_HelpArduino.Name = "Cmd_HelpArduino";
            this.Cmd_HelpArduino.Size = new System.Drawing.Size(84, 39);
            this.Cmd_HelpArduino.TabIndex = 42;
            this.Cmd_HelpArduino.Text = "Arduino Commands";
            this.Cmd_HelpArduino.UseVisualStyleBackColor = true;
            this.Cmd_HelpArduino.Click += new System.EventHandler(this.Cmd_HelpArduino_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(886, 117);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 17);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "Print without heated print bed";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Yamaha3DPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1294, 717);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Cmd_HelpArduino);
            this.Controls.Add(this.Cmd_HelpSetup);
            this.Controls.Add(this.Cmd_Clear_Programmablauf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TeBox_Programmablauf);
            this.Controls.Add(this.Lbl_Temperatur_LoadFIlament);
            this.Controls.Add(this.TeBox_LoadFilament);
            this.Controls.Add(this.TeBoxSendYamaha);
            this.Controls.Add(this.TeBox_Flow_Multiplier);
            this.Controls.Add(this.Cmd_Safe_Multiplier);
            this.Controls.Add(this.CmdStopPrint);
            this.Controls.Add(this.Cmd_LoadFilament);
            this.Controls.Add(this.Cmd_UnloadFilament);
            this.Controls.Add(this.Lbl_Progressbar);
            this.Controls.Add(this.CmdReadArduino);
            this.Controls.Add(this.Cmd_YamahaMove);
            this.Controls.Add(this.TeBox_SerialArduinoRead);
            this.Controls.Add(this.CmdReadYamaha);
            this.Controls.Add(this.LblDruckStatus);
            this.Controls.Add(this.progressBarDruck);
            this.Controls.Add(this.CmdClearSerialControllino);
            this.Controls.Add(this.CmdClearSerialYamaha);
            this.Controls.Add(this.CmdStartPrint);
            this.Controls.Add(this.cBoxArduino);
            this.Controls.Add(this.cBoxYamaha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdSendArduino);
            this.Controls.Add(this.TeBox_SendArduino);
            this.Controls.Add(this.TeBox_SendYamaha);
            this.Controls.Add(this.CmdSendYamaha);
            this.Controls.Add(this.Lbl_Serial_Arduino);
            this.Controls.Add(this.Lbl_SerialYamaha);
            this.Controls.Add(this.TeBox_SerialArduinoWrite);
            this.Controls.Add(this.TeBox_ReadYamaha);
            this.Controls.Add(this.LblConnectDevice);
            this.Controls.Add(this.CmdConnectDevice);
            this.Controls.Add(this.Lbl_Gcode);
            this.Controls.Add(this.CmdReadGCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Yamaha3DPrint";
            this.Text = "Yamaha3DPrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CmdReadGCode;
        private System.Windows.Forms.Label Lbl_Gcode;
        private System.Windows.Forms.Button CmdConnectDevice;
        private System.Windows.Forms.Label LblConnectDevice;
        private System.Windows.Forms.Label Lbl_SerialYamaha;
        private System.Windows.Forms.Label Lbl_Serial_Arduino;
        private System.Windows.Forms.Button CmdSendYamaha;
        private System.Windows.Forms.TextBox TeBox_SendYamaha;
        private System.Windows.Forms.TextBox TeBox_SendArduino;
        private System.Windows.Forms.Button CmdSendArduino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxYamaha;
        private System.Windows.Forms.ComboBox cBoxArduino;
        private System.Windows.Forms.Button CmdStartPrint;
        private System.Windows.Forms.Button CmdClearSerialYamaha;
        private System.Windows.Forms.Button CmdClearSerialControllino;
        private System.Windows.Forms.ProgressBar progressBarDruck;
        private System.Windows.Forms.Label LblDruckStatus;
        public System.Windows.Forms.TextBox TeBox_ReadYamaha;
        private System.Windows.Forms.Button CmdReadYamaha;
        public System.Windows.Forms.TextBox TeBox_SerialArduinoWrite;
        public System.Windows.Forms.TextBox TeBox_SerialArduinoRead;
        private System.Windows.Forms.Button Cmd_YamahaMove;
        private System.Windows.Forms.Button CmdReadArduino;
        private System.Windows.Forms.Label Lbl_Progressbar;
        private System.Windows.Forms.Button Cmd_UnloadFilament;
        private System.Windows.Forms.Button Cmd_LoadFilament;
        private System.Windows.Forms.Button CmdStopPrint;
        private System.Windows.Forms.TextBox TeBox_Flow_Multiplier;
        private System.Windows.Forms.Button Cmd_Safe_Multiplier;
        private System.Windows.Forms.ToolTip toolTipSaveMultiplier;
        private System.Windows.Forms.ToolTip toolTipreadGcode;
        private System.Windows.Forms.ToolTip toolTipConnectDevices;
        private System.Windows.Forms.ToolTip toolTipStartPrint;
        private System.Windows.Forms.ToolTip toolTipStopPrint;
        private System.Windows.Forms.ToolTip toolTipSendYamaha;
        public System.Windows.Forms.TextBox TeBoxSendYamaha;
        private System.Windows.Forms.TextBox TeBox_LoadFilament;
        private System.Windows.Forms.Label Lbl_Temperatur_LoadFIlament;
        public System.Windows.Forms.TextBox TeBox_Programmablauf;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Cmd_Clear_Programmablauf;
        private System.Windows.Forms.Button Cmd_HelpSetup;
        private System.Windows.Forms.Button Cmd_HelpArduino;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}

