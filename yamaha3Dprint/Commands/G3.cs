using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
    // Hier wird probiert die Kreisbewegung G3 in circularbefehle zu überführen. Funktioniert noch nicht
    public class G3 : GcodeCommand
    {
        private double x;
        private double y;
        private double i;
        private double j;
        private double e;
        Position aktuelleposition;
        Position mittelpunkt;
        Position neuePosition;
        
        public G3(double x, double y, double i, double j, double e)
        {
            this.x = x;
            this.y = y;
            this.i = i;
            this.j = j;
            this.e = e;
        }

        public override void ExecuteCommand(Yamaha yamaha, Arduino arduino)
        {
            if (Math.Sqrt(Math.Pow(i, 2) + Math.Pow(j, 2)) < 1)
            {
                yamaha.SetPosition(0, x, y);
                arduino.Move(e);
                yamaha.Move(0);
                yamaha.WaitForOk(2);
                yamaha.SendCount = 0;
                arduino.Move(0);
            }
            else
            {
                aktuelleposition = yamaha.GetCurrentPosition();
                mittelpunkt = new Position(aktuelleposition.X + i, aktuelleposition.Y + i, aktuelleposition.Z);
                neuePosition = GetNewPosition(aktuelleposition, mittelpunkt);
                Console.WriteLine(aktuelleposition.X + " " + aktuelleposition.Y);
                Console.WriteLine(neuePosition.X + " " + neuePosition.Y);
                Console.WriteLine(x + " " + y);
                Console.WriteLine(mittelpunkt.X + " " + mittelpunkt.Y);
                yamaha.SetPosition(0, neuePosition.X, neuePosition.Y);
                yamaha.SetPosition(1, x, y);
                arduino.Move(e);
                yamaha.MoveC(2);
                yamaha.WaitForOk(3);
                yamaha.SendCount = 0;
                arduino.Move(0);
            }
        }
        public Position GetNewPosition(Position aktuell, Position mittelpunkt)
        {
            double[] Richtungsvektoralt = new double[2];
            double[] Richtungsvektornew = new double[2];
            Richtungsvektoralt[0] = aktuell.X - mittelpunkt.X;
            Richtungsvektoralt[1] = aktuell.Y - mittelpunkt.Y;
            Richtungsvektornew[0] = x - mittelpunkt.X;
            Richtungsvektornew[1] = y - mittelpunkt.Y;
            double radius = Norm(Richtungsvektornew[0], Richtungsvektornew[1]);
            double Winkel1 = Winkelberechnung(Richtungsvektoralt);
            double Winkel2 = Winkelberechnung(Richtungsvektornew);
            int quadrant1 = Quadranten(Richtungsvektoralt);
            int quadrant2 = Quadranten(Richtungsvektornew);
            double Winkelerg = Winkel1 - Winkel2;
            bool otherside = GetOtherside(Winkel1, Winkel2, Winkelerg, quadrant1, quadrant2);
            if (Winkelerg > 180)
            {
                Winkelerg -= 360.0;
            }
            if (Winkelerg < -180)
            {
                Winkelerg += 360;
            }
            if (otherside == true)
            {
                Winkelerg += 180;
            }
            double newpointx = Math.Cos(Winkel1 + Winkelerg * Math.PI / 180) * radius + mittelpunkt.X;
            double newpointy = Math.Sin(Winkel1 + Winkelerg * Math.PI / 180) * radius + mittelpunkt.Y;
            Position Mittelposition = new Position(newpointx, newpointy, aktuell.Z);
            return Mittelposition;
        }

        private bool GetOtherside(double winkel1, double winkel2, double winkelerg, int quadrant1, int quadrant2)
        {
            if (quadrant1 == 1 && quadrant2 == 1)
            {
                return winkel1 > winkel2;
            }
            else if (quadrant1 == 1 && quadrant2 == 2)
            {
                return false;
            }
            else if (quadrant1 == 1 && quadrant2 == 3)
            {
                if (Math.Abs(winkelerg) > 180)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (quadrant1 == 1 && quadrant2 == 4)
            {
                return true;
            }
            else if (quadrant1 == 2 && quadrant2 == 1)
            {
                return true;
            }
            else if (quadrant1 == 2 && quadrant2 == 2)
            {
                return winkel1 > winkel2;
            }
            else if (quadrant1 == 2 && quadrant2 == 3)
            {
                return true;
            }
            else if (quadrant1 == 2 && quadrant2 == 4)
            {
                if (Math.Abs(winkelerg) > 180)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (quadrant1 == 3 && quadrant2 == 1)
            {
                if (Math.Abs(winkelerg) > 180)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (quadrant1 == 3 && quadrant2 == 2)
            {
                return true;
            }
            else if (quadrant1 == 3 && quadrant2 == 3)
            {
                return winkel1 > winkel2;
            }
            else if (quadrant1 == 3 && quadrant2 == 4)
            {
                return false;
            }
            else if (quadrant1 == 4 && quadrant2 == 1)
            {
                return false;
            }
            else if (quadrant1 == 4 && quadrant2 == 2)
            {
                if (Math.Abs(winkelerg) > 180)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (quadrant1 == 4 && quadrant2 == 3)
            {
                return true;
            }
            else if (quadrant1 == 4 && quadrant2 == 4)
            {
                return winkel1 > winkel2;
            }
            else
            {
                return false;
            }
        }

        public double Skalarprodukt(double x1, double y1, double x2, double y2)
        {
            return (x1 * x2 + y1 * y2);
        }
        public double Norm(double a, double b, double c = 0)
        {
            return Math.Sqrt(a * a + b * b + c * c);
        }
        public double Winkelberechnung(double[] richtungsvektor)
        {
            double zaehler = Skalarprodukt(richtungsvektor[0], richtungsvektor[1], 1, 0);
            double nenner = Norm(richtungsvektor[0], richtungsvektor[1]) * Norm(1, 0);
            double Winkel = Math.Acos(zaehler / nenner) * 180 / Math.PI;
            if (Quadranten(richtungsvektor) == 3)
            {
                Winkel = -1 * Winkel;
            }
            else if (Quadranten(richtungsvektor) == 4)
            {
                Winkel = -1 * Winkel;
            }
            return Winkel;
        }
        public int Quadranten(double[] v1)
        {
            if (v1[0] == 0 && v1[1] == 0)
            {
                return 0;
            }
            else if (v1[0] >= 0 && v1[1] > 0)
            {
                return 1;
            }
            else if (v1[0] < 0 && v1[1] > 0)
            {
                return 2;
            }
            else if (v1[0] < 0 && v1[1] <= 0)
            {
                return 3;
            }
            else if (v1[0] >= 0 && v1[1] <= 0)
            {
                return 4;
            }
            else return 0;
        }
        public static G3 Parse(string data)
        {
            var split = data.Split(' ');
            split[0] = split[0].Replace("X", "");
            split[1] = split[1].Replace("Y", "");
            split[2] = split[2].Replace("I", "");
            split[3] = split[3].Replace("J", "");
            split[4] = split[4].Replace("E", "");
            double x = double.Parse(split[0], new CultureInfo("en-us"));
            double y = double.Parse(split[1], new CultureInfo("en-us"));
            double I = double.Parse(split[2], new CultureInfo("en-us"));
            double J = double.Parse(split[3], new CultureInfo("en-us"));
            double e = double.Parse(split[4], new CultureInfo("en-us"));
            return new G3(x, y, I, J, e);
        }
    }
}