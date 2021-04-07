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
        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            int i = 0;
            if (G1MoveNegativ.Count == 0)
            {
                return;
            }
            foreach (var move in G1MoveNegativ)
            {
                yamaha.SetPosition(i, move.x, move.y);
                i++;
                if (i == 7)
                {
                    arduino.Move(-1);
                    yamaha.ExecuteMoves(i);
                    i = 0;
                    arduino.Move(0);
                }
            }
            arduino.Move(-1);
            yamaha.ExecuteMoves(i);
            arduino.Move(0);
        }
    }
}