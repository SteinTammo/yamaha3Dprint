using System.Collections.Generic;

namespace yamaha3Dprint.Commands
{
    public class G1MoveCollection : GcodeCommand
    {
        public List<G1Move> G1Move { get; }
        public G1MoveCollection(List<G1Move> g1Move)
        {
            G1Move = g1Move;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            
        }
    }
}