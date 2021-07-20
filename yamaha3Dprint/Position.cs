namespace yamaha3Dprint
{
    // Spiechert die Information einer Position
    public struct Position
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Position(double x, double y, double z)
        {
            if(y<0)
            {
                this.Y = 0;
                this.X = x;
                this.Z = z;
            }
            else
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }
        }
    }
}