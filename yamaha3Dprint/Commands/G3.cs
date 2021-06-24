﻿using System;
using System.Globalization;

namespace yamaha3Dprint.Commands
{
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
            if(Math.Sqrt(Math.Pow(i,2)+Math.Pow(j,2))<1)
            {
                yamaha.SetPosition(0,x,y);
                arduino.Move(e);
                yamaha.Move(0);
                yamaha.WaitForOk(2);
                yamaha.SendCount = 0;
                arduino.Move(0);
            }
            else
            {
                aktuelleposition = yamaha.GetCurrentPosition();
                mittelpunkt = new Position(x + i, y + i, aktuelleposition.Z);
                neuePosition = GetNewPosition(aktuelleposition, mittelpunkt);
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
            Richtungsvektoralt[0] = mittelpunkt.X - aktuell.X;
            Richtungsvektoralt[1] = mittelpunkt.Y - aktuell.Y;
            Richtungsvektornew[0] = mittelpunkt.X - x;
            Richtungsvektornew[1] = mittelpunkt.Y - y;
            double radius = Norm(Richtungsvektornew[0],Richtungsvektornew[0]);
            double Winkel1 = Winkelberechnung(Richtungsvektoralt);
            double Winkel2 = Winkelberechnung(Richtungsvektornew);
            double Winkelerg = (Winkel1 - Winkel2)/2;
            double newpointx = Math.Cos(Winkelerg * Math.PI / 180) * radius + mittelpunkt.X;
            double newpointy = Math.Sin(Winkelerg * Math.PI / 180) * radius + mittelpunkt.Y;
            Position Mittelposition = new Position(newpointx,newpointy,aktuell.Z);
            return Mittelposition;
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