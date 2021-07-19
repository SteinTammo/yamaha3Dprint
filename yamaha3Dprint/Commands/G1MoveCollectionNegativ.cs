using System.Collections.Generic;

namespace yamaha3Dprint.Commands
{
    public class G1MoveCollectionNegativ : GcodeCommand
    {
        public List<G1MoveNegativ> G1MoveNegativ { get; }
        public G1MoveCollectionNegativ(List<G1MoveNegativ> g1MoveNegativ)
        {
            G1MoveNegativ = g1MoveNegativ;
        }
        // Für alle G1MoveNegativ befehle in der Liste werden für jede 50 Befehle die Punkte direkt hinteinander abgefahren. Danach werden erst die Oks gezählt
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            int i = 0;
            int j = 0;
            double? extruder = 0;
            if (G1MoveNegativ.Count == 0)
            {
                return;
            }
            foreach (var move in G1MoveNegativ)
            {
                yamaha.SetPosition(i, move.x, move.y);
                extruder = extruder + move.e;
                i++;
                j++;
                if (i == 50)
                {
                    arduino.Move(-1);
                    yamaha.ExecuteMoves(i);
                    arduino.MoveExtruder(0);
                    i = 0;
                    extruder = 0;
                }
                if (i != 0 && j == G1MoveNegativ.Count)
                {
                    arduino.Move(-1);
                    yamaha.ExecuteMoves(i);
                    arduino.MoveExtruder(0);

                }
            }
        }
    }
}