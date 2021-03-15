using System.Collections.Generic;

namespace yamaha3Dprint.Commands
{
    public class G1MoveCollectionPositiv : GcodeCommand
    {
        public List<G1MovePositiv> G1MovePositiv { get; }
        public G1MoveCollectionPositiv(List<G1MovePositiv> g1MovePositiv)
        {
            G1MovePositiv = g1MovePositiv;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            int i = 0;
            if(G1MovePositiv.Count==0)
            {
                return;
            }
            foreach (var move in G1MovePositiv)
            {
                yamaha.SetPosition(i,move.x,move.y);                
                i++;
                if(i==63)
                {
                    yamaha.ExecuteMoves(i);
                    i = 0;
                }                                    
            }
            yamaha.ExecuteMoves(i);
        }
    }
}