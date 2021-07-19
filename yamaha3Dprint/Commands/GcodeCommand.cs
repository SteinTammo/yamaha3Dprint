namespace yamaha3Dprint.Commands
{
    // Abstrakte Klasse zur Implementierung der einzelnen Commands
    public abstract class GcodeCommand
    {
        public abstract void ExecuteCommand(Yamaha yamaha, Arduino arduino);
    }
}