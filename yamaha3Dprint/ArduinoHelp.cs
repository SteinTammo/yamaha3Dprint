using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yamaha3Dprint
{
    public partial class ArduinoHelp : Form
    {
        List<Command> commands = new List<Command>();
        public ArduinoHelp()
        {
            InitializeComponent();
            commands.Add(new Command("GETETEMP&1&","Fordert die Rückgabe der Extrudertemperatur",""));
            commands.Add(new Command("M104&“Temperatur“&", "Setzt neue Zieltemperatur für den Extruder", "M104&215&"));
            commands.Add(new Command("G1E&“Richtung“&", "Aktiviert die Bewegung des Extruders: >0 vorwärts;0 stehen; <0 rückwärts", "G1E&1&"));
            commands.Add(new Command("G1F&“Flowrate“&", "Änderung der Flowrate des Extruders (Drehzahl)", "G1F&300&"));
            commands.Add(new Command("GETBTEMP&1&", "Fordert die Temperatur des Druckbetts an", ""));
            commands.Add(new Command("M190&“Temperatur“&", "Setze die Druckbetttemperatur", "M190&50&"));

        }
        public class Command
        {
            public string Prototyp { get; set; }
            public string Erklärung { get; set; }
            public string Beispiel { get; set; }
            public Command(string prototyp, string Erklärung, string beispiel)
            {
                this.Prototyp = prototyp;
                this.Erklärung = Erklärung;
                Beispiel = beispiel;
            }
        }

        private void ArduinoHelp_Load(object sender, EventArgs e)
        {
            var commands = this.commands;
            dataGridView1.DataSource = commands;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
