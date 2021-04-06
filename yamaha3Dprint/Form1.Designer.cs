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
            this.CmdReadGCode = new System.Windows.Forms.Button();
            this.Lbl_Gcode = new System.Windows.Forms.Label();
            this.CmdConnectDevice = new System.Windows.Forms.Button();
            this.LblConnectDevice = new System.Windows.Forms.Label();
            this.TeBox_SerialYamaha = new System.Windows.Forms.TextBox();
            this.TeBox_SerialControllino = new System.Windows.Forms.TextBox();
            this.Lbl_SerialYamaha = new System.Windows.Forms.Label();
            this.Lbl_Serial_Yamaha = new System.Windows.Forms.Label();
            this.CmdSendYamaha = new System.Windows.Forms.Button();
            this.TeBox_SendYamaha = new System.Windows.Forms.TextBox();
            this.TeBox_SendControllino = new System.Windows.Forms.TextBox();
            this.CmdSendControllino = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBoxYamaha = new System.Windows.Forms.ComboBox();
            this.cBoxControllino = new System.Windows.Forms.ComboBox();
            this.CmdStartPrint = new System.Windows.Forms.Button();
            this.CmdClearSerialYamaha = new System.Windows.Forms.Button();
            this.CmdClearSerialControllino = new System.Windows.Forms.Button();
            this.progressBarDruck = new System.Windows.Forms.ProgressBar();
            this.LblDruckStatus = new System.Windows.Forms.Label();
            this.CmdReadYamaha = new System.Windows.Forms.Button();
            this.TeBox_SerialArduinoRead = new System.Windows.Forms.TextBox();
            this.Cmd_YamahaMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmdReadGCode
            // 
            this.CmdReadGCode.Location = new System.Drawing.Point(12, 12);
            this.CmdReadGCode.Name = "CmdReadGCode";
            this.CmdReadGCode.Size = new System.Drawing.Size(83, 39);
            this.CmdReadGCode.TabIndex = 1;
            this.CmdReadGCode.Text = "Read GCode";
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
            // TeBox_SerialYamaha
            // 
            this.TeBox_SerialYamaha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TeBox_SerialYamaha.Location = new System.Drawing.Point(12, 178);
            this.TeBox_SerialYamaha.Multiline = true;
            this.TeBox_SerialYamaha.Name = "TeBox_SerialYamaha";
            this.TeBox_SerialYamaha.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_SerialYamaha.Size = new System.Drawing.Size(600, 316);
            this.TeBox_SerialYamaha.TabIndex = 6;
            // 
            // TeBox_SerialControllino
            // 
            this.TeBox_SerialControllino.Location = new System.Drawing.Point(619, 178);
            this.TeBox_SerialControllino.MaxLength = 65000;
            this.TeBox_SerialControllino.Multiline = true;
            this.TeBox_SerialControllino.Name = "TeBox_SerialControllino";
            this.TeBox_SerialControllino.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_SerialControllino.Size = new System.Drawing.Size(343, 316);
            this.TeBox_SerialControllino.TabIndex = 6;
            // 
            // Lbl_SerialYamaha
            // 
            this.Lbl_SerialYamaha.AutoSize = true;
            this.Lbl_SerialYamaha.Location = new System.Drawing.Point(13, 502);
            this.Lbl_SerialYamaha.Name = "Lbl_SerialYamaha";
            this.Lbl_SerialYamaha.Size = new System.Drawing.Size(75, 13);
            this.Lbl_SerialYamaha.TabIndex = 7;
            this.Lbl_SerialYamaha.Text = "Serial Yamaha";
            // 
            // Lbl_Serial_Yamaha
            // 
            this.Lbl_Serial_Yamaha.AutoSize = true;
            this.Lbl_Serial_Yamaha.Location = new System.Drawing.Point(618, 502);
            this.Lbl_Serial_Yamaha.Name = "Lbl_Serial_Yamaha";
            this.Lbl_Serial_Yamaha.Size = new System.Drawing.Size(85, 13);
            this.Lbl_Serial_Yamaha.TabIndex = 8;
            this.Lbl_Serial_Yamaha.Text = "Serial Controllino";
            // 
            // CmdSendYamaha
            // 
            this.CmdSendYamaha.Location = new System.Drawing.Point(398, 150);
            this.CmdSendYamaha.Name = "CmdSendYamaha";
            this.CmdSendYamaha.Size = new System.Drawing.Size(75, 23);
            this.CmdSendYamaha.TabIndex = 9;
            this.CmdSendYamaha.Text = "Send";
            this.CmdSendYamaha.UseVisualStyleBackColor = true;
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
            // TeBox_SendControllino
            // 
            this.TeBox_SendControllino.Location = new System.Drawing.Point(619, 150);
            this.TeBox_SendControllino.Name = "TeBox_SendControllino";
            this.TeBox_SendControllino.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.TeBox_SendControllino.Size = new System.Drawing.Size(380, 20);
            this.TeBox_SendControllino.TabIndex = 11;
            // 
            // CmdSendControllino
            // 
            this.CmdSendControllino.Location = new System.Drawing.Point(1005, 147);
            this.CmdSendControllino.Name = "CmdSendControllino";
            this.CmdSendControllino.Size = new System.Drawing.Size(75, 23);
            this.CmdSendControllino.TabIndex = 12;
            this.CmdSendControllino.Text = "Send";
            this.CmdSendControllino.UseVisualStyleBackColor = true;
            this.CmdSendControllino.Click += new System.EventHandler(this.CmdSendControllino_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(615, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Port:";
            // 
            // cBoxYamaha
            // 
            this.cBoxYamaha.FormattingEnabled = true;
            this.cBoxYamaha.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cBoxYamaha.Location = new System.Drawing.Point(60, 114);
            this.cBoxYamaha.Name = "cBoxYamaha";
            this.cBoxYamaha.Size = new System.Drawing.Size(121, 21);
            this.cBoxYamaha.TabIndex = 18;
            // 
            // cBoxControllino
            // 
            this.cBoxControllino.FormattingEnabled = true;
            this.cBoxControllino.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cBoxControllino.Location = new System.Drawing.Point(663, 114);
            this.cBoxControllino.Name = "cBoxControllino";
            this.cBoxControllino.Size = new System.Drawing.Size(121, 21);
            this.cBoxControllino.TabIndex = 19;
            // 
            // CmdStartPrint
            // 
            this.CmdStartPrint.Location = new System.Drawing.Point(619, 12);
            this.CmdStartPrint.Name = "CmdStartPrint";
            this.CmdStartPrint.Size = new System.Drawing.Size(75, 39);
            this.CmdStartPrint.TabIndex = 20;
            this.CmdStartPrint.Text = "Start Print";
            this.CmdStartPrint.UseVisualStyleBackColor = true;
            this.CmdStartPrint.Click += new System.EventHandler(this.CmdStartPrint_Click);
            // 
            // CmdClearSerialYamaha
            // 
            this.CmdClearSerialYamaha.Location = new System.Drawing.Point(537, 500);
            this.CmdClearSerialYamaha.Name = "CmdClearSerialYamaha";
            this.CmdClearSerialYamaha.Size = new System.Drawing.Size(75, 21);
            this.CmdClearSerialYamaha.TabIndex = 21;
            this.CmdClearSerialYamaha.Text = "Clear";
            this.CmdClearSerialYamaha.UseVisualStyleBackColor = true;
            this.CmdClearSerialYamaha.Click += new System.EventHandler(this.CmdClearSerialYamaha_Click);
            // 
            // CmdClearSerialControllino
            // 
            this.CmdClearSerialControllino.Location = new System.Drawing.Point(1144, 502);
            this.CmdClearSerialControllino.Name = "CmdClearSerialControllino";
            this.CmdClearSerialControllino.Size = new System.Drawing.Size(75, 23);
            this.CmdClearSerialControllino.TabIndex = 22;
            this.CmdClearSerialControllino.Text = "Clear";
            this.CmdClearSerialControllino.UseVisualStyleBackColor = true;
            this.CmdClearSerialControllino.Click += new System.EventHandler(this.CmdClearSerialControllino_Click);
            // 
            // progressBarDruck
            // 
            this.progressBarDruck.Location = new System.Drawing.Point(619, 57);
            this.progressBarDruck.Name = "progressBarDruck";
            this.progressBarDruck.Size = new System.Drawing.Size(232, 23);
            this.progressBarDruck.TabIndex = 23;
            this.progressBarDruck.Click += new System.EventHandler(this.progressBarDruck_Click);
            // 
            // LblDruckStatus
            // 
            this.LblDruckStatus.AutoSize = true;
            this.LblDruckStatus.Location = new System.Drawing.Point(616, 83);
            this.LblDruckStatus.Name = "LblDruckStatus";
            this.LblDruckStatus.Size = new System.Drawing.Size(35, 13);
            this.LblDruckStatus.TabIndex = 24;
            this.LblDruckStatus.Text = "label3";
            // 
            // CmdReadYamaha
            // 
            this.CmdReadYamaha.Location = new System.Drawing.Point(479, 150);
            this.CmdReadYamaha.Name = "CmdReadYamaha";
            this.CmdReadYamaha.Size = new System.Drawing.Size(75, 23);
            this.CmdReadYamaha.TabIndex = 25;
            this.CmdReadYamaha.Text = "Read";
            this.CmdReadYamaha.UseVisualStyleBackColor = true;
            this.CmdReadYamaha.Click += new System.EventHandler(this.CmdReadYamaha_Click);
            // 
            // TeBox_SerialArduinoRead
            // 
            this.TeBox_SerialArduinoRead.Location = new System.Drawing.Point(968, 178);
            this.TeBox_SerialArduinoRead.MaxLength = 65000;
            this.TeBox_SerialArduinoRead.Multiline = true;
            this.TeBox_SerialArduinoRead.Name = "TeBox_SerialArduinoRead";
            this.TeBox_SerialArduinoRead.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TeBox_SerialArduinoRead.Size = new System.Drawing.Size(255, 316);
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
            this.Cmd_YamahaMove.Click += new System.EventHandler(this.Cmd_YamahaMove_Click);
            // 
            // Yamaha3DPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 537);
            this.Controls.Add(this.Cmd_YamahaMove);
            this.Controls.Add(this.TeBox_SerialArduinoRead);
            this.Controls.Add(this.CmdReadYamaha);
            this.Controls.Add(this.LblDruckStatus);
            this.Controls.Add(this.progressBarDruck);
            this.Controls.Add(this.CmdClearSerialControllino);
            this.Controls.Add(this.CmdClearSerialYamaha);
            this.Controls.Add(this.CmdStartPrint);
            this.Controls.Add(this.cBoxControllino);
            this.Controls.Add(this.cBoxYamaha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmdSendControllino);
            this.Controls.Add(this.TeBox_SendControllino);
            this.Controls.Add(this.TeBox_SendYamaha);
            this.Controls.Add(this.CmdSendYamaha);
            this.Controls.Add(this.Lbl_Serial_Yamaha);
            this.Controls.Add(this.Lbl_SerialYamaha);
            this.Controls.Add(this.TeBox_SerialControllino);
            this.Controls.Add(this.TeBox_SerialYamaha);
            this.Controls.Add(this.LblConnectDevice);
            this.Controls.Add(this.CmdConnectDevice);
            this.Controls.Add(this.Lbl_Gcode);
            this.Controls.Add(this.CmdReadGCode);
            this.Name = "Yamaha3DPrint";
            this.Text = "Yamaha3DPrint";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CmdReadGCode;
        private System.Windows.Forms.Label Lbl_Gcode;
        private System.Windows.Forms.Button CmdConnectDevice;
        private System.Windows.Forms.Label LblConnectDevice;
        private System.Windows.Forms.Label Lbl_SerialYamaha;
        private System.Windows.Forms.Label Lbl_Serial_Yamaha;
        private System.Windows.Forms.Button CmdSendYamaha;
        private System.Windows.Forms.TextBox TeBox_SendYamaha;
        private System.Windows.Forms.TextBox TeBox_SendControllino;
        private System.Windows.Forms.Button CmdSendControllino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBoxYamaha;
        private System.Windows.Forms.ComboBox cBoxControllino;
        private System.Windows.Forms.Button CmdStartPrint;
        private System.Windows.Forms.Button CmdClearSerialYamaha;
        private System.Windows.Forms.Button CmdClearSerialControllino;
        private System.Windows.Forms.ProgressBar progressBarDruck;
        private System.Windows.Forms.Label LblDruckStatus;
        public System.Windows.Forms.TextBox TeBox_SerialYamaha;
        private System.Windows.Forms.Button CmdReadYamaha;
        public System.Windows.Forms.TextBox TeBox_SerialControllino;
        public System.Windows.Forms.TextBox TeBox_SerialArduinoRead;
        private System.Windows.Forms.Button Cmd_YamahaMove;
    }
}

