namespace yamaha3Dprint.Commands
{
    public abstract class GcodeCommand
    {
        public abstract void ExecuteCommand(Yamaha yamaha, Arduino arduino);
    }
}