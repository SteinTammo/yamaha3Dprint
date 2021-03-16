namespace yamaha3Dprint
{
    public struct Position
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public Position(double x,double y, double z)
        {
            this.X = x; 
            this.Y = y+10.0;
            this.Z = z;
        }
    }
}