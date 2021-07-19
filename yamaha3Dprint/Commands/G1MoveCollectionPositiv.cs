using System.Collections.Generic;

namespace yamaha3Dprint.Commands
{
    public class G1MoveCollectionPositiv : GcodeCommand
    { 
        // Für alle G1MoveNegativ befehle in der Liste werden für jede 50 Befehle die Punkte direkt hinteinander abgefahren. Danach werden erst die Oks gezählt
        public List<G1MovePositiv> G1MovePositiv { get; }
        public G1MoveCollectionPositiv(List<G1MovePositiv> g1MovePositiv)
        {
            G1MovePositiv = g1MovePositiv;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            int i = 0;
            int j = 0;
            double? extruder = 0;
            if (G1MovePositiv.Count == 0)
            {
                return;
            }
            foreach (var move in G1MovePositiv)
            {
                yamaha.SetPosition(i, move.x, move.y);
                extruder = extruder + move.e;
                i++;
                j++;
                if (i == 50)
                {
                    //arduino.MoveExtruder(0.1);
                    arduino.Move(1);
                    yamaha.ExecuteMoves(i);
                    arduino.Move(0);
                    //arduino.MoveExtruder(-0.2);
                    i = 0;
                    extruder = 0;
                }
                if (i != 0 && j == G1MovePositiv.Count)
                {
                    //arduino.MoveExtruder(0.1);
                    arduino.Move(1);
                    yamaha.ExecuteMoves(i);
                    arduino.Move(0);
                    //arduino.MoveExtruder(-0.2);

                }
            }
        }
    }
}