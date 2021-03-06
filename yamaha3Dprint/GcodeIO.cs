using System;
using System.Collections.Generic;
using System.IO;
using yamaha3Dprint.Commands;

namespace yamaha3Dprint
{
    public class GcodeIO
    {
        public List<GcodeCommand> ReadFile(string path)
        {
            List<GcodeCommand> commands = new List<GcodeCommand>();
            var lines = File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var parsedCommands = ReadLine(line);
                commands.AddRange(parsedCommands);
            }
            // Fasse Moves zusammen
            SimplifyCommands(commands);
            return commands;
        }
        
        // Stellt Collections zusammen, die alle gleichartigen Commands in einem Collection Command zusammenfasst, um mehr als einen Punkt auf einmal zu übertragen und die Zeit zwischen der Abfrage der Oks zu verlängern.
        private void SimplifyCommands(List<GcodeCommand> commands)
        {
            // Simplify Positiv
            int currentmoveindexpositiv = -1;
            G1MovePositiv currentpositiv = null;
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] is G1MovePositiv g1movepositiv)
                {
                    if (currentpositiv == null)
                    {
                        currentpositiv = g1movepositiv;
                        currentmoveindexpositiv = i;
                    }

                }
                else if (currentpositiv != null)
                {
                    if (i - currentmoveindexpositiv > 1)
                    {
                        // Zusammenfassen
                        List<G1MovePositiv> moves = new List<G1MovePositiv>();
                        for (int j = currentmoveindexpositiv; j < i; j++)
                        {
                            moves.Add((G1MovePositiv)commands[j]);
                        }
                        foreach (var move in moves)
                        {
                            commands.Remove(move);
                        }
                        var movecollection = new G1MoveCollectionPositiv(moves);
                        commands.Insert(currentmoveindexpositiv, movecollection);
                        i = currentmoveindexpositiv + 1;
                    }
                    currentpositiv = null;
                    currentmoveindexpositiv = -1;

                }
            }
            // Simplify negative
            int currentmoveindexnegativ = -1;
            G1MoveNegativ currentnegativ = null;
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] is G1MoveNegativ g1movenegativ)
                {
                    if (currentnegativ == null)
                    {
                        currentnegativ = g1movenegativ;
                        currentmoveindexnegativ = i;
                    }

                }
                else if (currentnegativ != null)
                {
                    if (i - currentmoveindexnegativ > 1)
                    {
                        // Zusammenfassen
                        List<G1MoveNegativ> moves = new List<G1MoveNegativ>();
                        for (int j = currentmoveindexnegativ; j < i; j++)
                        {
                            moves.Add((G1MoveNegativ)commands[j]);
                        }
                        foreach (var move in moves)
                        {
                            commands.Remove(move);
                        }
                        var movecollection = new G1MoveCollectionNegativ(moves);
                        commands.Insert(currentmoveindexnegativ, movecollection);
                        i = currentmoveindexnegativ + 1;
                    }
                    currentnegativ = null;
                    currentmoveindexnegativ = -1;

                }
            }

        }

        // Hier wird für jede Ziele in der eingelesenen GCode Datei überprüft welche Informationen enthalten sind. Bei relevanten Informationen werden jeweils Instanzen der jeweiligen Command Klasse erzeugt, an die die relevanten Informationen über eine Parse-Methode übertragen werden. 
        // Die Parse-Methode gibt eine Instanz der Klasse zurück, die in der Liste commands gespeichert werden. Sie enthält am Ende alle Commands in richtiger Reihenfolge wie in der GCode Datei. Für den Druck werden dann alle Commands nacheinander abgearbeitet. 
        // Es muss für jeden Command eine Fallunterscheidung durchgeführt werden, da es sehr viele verschiedene Variationen gibt. 
        private List<GcodeCommand> ReadLine(string line)
        {
            List<GcodeCommand> commands = new List<GcodeCommand>();
            bool behandelt = false;
            // Remove Comments
            if (line.Contains(";"))
            {
                int index = line.IndexOf(";");
                if (index == 0)
                {
                    line = string.Empty;
                    behandelt = true;
                }
                else
                {
                    line = line.Substring(0, index);
                }
            }
            line = line.Trim();
            if (line.StartsWith("G1 "))
            {
                var parameters = line.Split(' ');
                if (parameters.Length == 4)
                {
                    //G1 X60.0 E9.0 F1000.0
                    //G1 X117.477 Y124.252 E0.01235
                    //G1 X117.545 Y124.623 F10800.000
                    //G1 X109.866 Y42.627 E - 0.18749
                    if (parameters[1].StartsWith("X") && parameters[2].StartsWith("Y"))
                    {
                        //G1 X117.545 Y124.623 F10800.000
                        if (parameters[3].StartsWith("F"))
                        {
                            var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[3]}");
                            commands.Add(setflow);
                            var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                            commands.Add(move);
                            behandelt = true;
                        }
                        //G1 X117.477 Y124.252 E0.01235
                        //G1 X109.866 Y42.627 E - 0.18749
                        if (parameters[3].StartsWith("E"))
                        {
                            //G1 X109.866 Y42.627 E - 0.18749
                            if (parameters[3].IndexOf("-") != -1)
                            {
                                var move = G1MoveNegativ.Parse($"{parameters[0]} {parameters[1]} {parameters[2]} {parameters[3]}");
                                commands.Add(move);
                                behandelt = true;
                            }
                            //G1 X117.477 Y124.252 E0.01235
                            else
                            {
                                var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[1]} {parameters[2]} {parameters[3]}");
                                commands.Add(move);
                                behandelt = true;
                            }
                        }
                    }
                    if (parameters[1].StartsWith("X") && parameters[2].StartsWith("E") && parameters[3].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[3]}");
                        commands.Add(setflow);
                        var move = G1MoveXE.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                        commands.Add(move);
                        behandelt = true;
                    }
                    //G1 Y-2.0 X179 F2400
                    if (parameters[1].StartsWith("Y") && parameters[2].StartsWith("X") && parameters[3].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[3]}");
                        commands.Add(setflow);
                        var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[2]} {parameters[1]}");
                        commands.Add(move);
                        behandelt = true;
                    }
                }
                //G1 Z0.400 F10800.000
                //G1 X109.128 Y42.788
                //G1 E-0.04000 F2100.00000
                if (parameters.Length == 3)
                {
                    //G1 Z0.400 F10800.000
                    if (parameters[1].StartsWith("Z") && parameters[2].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                        commands.Add(setflow);
                        var moveZ = G1MoveZ.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(moveZ);
                        behandelt = true;
                    }

                    //G1 X109.128 Y42.788
                    if (parameters[1].StartsWith("X") && parameters[2].StartsWith("Y"))
                    {
                        var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                        commands.Add(move);
                        behandelt = true;
                    }

                    //G1 E-0.04000 F2100.00000
                    //G1 E0.04000 F2100.00000
                    if (parameters[1].StartsWith("E") && parameters[2].StartsWith("F"))
                    {
                        //G1 E-0.04000 F2100.00000
                        if (parameters[1].IndexOf("-") != -1)
                        {
                            var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                            commands.Add(setflow);
                            var extrudeNegative = G1MoveExtruderNegativ.Parse(parameters[1]);
                            commands.Add(extrudeNegative);
                            behandelt = true;
                        }
                        //G1 E0.04000 F2100.00000
                        else
                        {
                            var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                            commands.Add(setflow);
                            var extruderPositiv = G1MoveExtruderPositiv.Parse(parameters[1]);
                            commands.Add(extruderPositiv);
                            behandelt = true;
                        }
                    }
                    //G1 Y-3.0 F1000.0
                    if (parameters[1].StartsWith("Y") && parameters[2].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                        commands.Add(setflow);
                        var move = G1MoveY.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(move);
                        behandelt = true;
                    }
                    //G1 X170 F1000
                    if (parameters[1].StartsWith("X") && parameters[2].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                        commands.Add(setflow);
                        var move = G1MoveX.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(move);
                        behandelt = true;
                    }
                }
                if (parameters.Length == 2)
                {
                    if (parameters[1].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(setflow);
                        behandelt = true;
                    }
                    if (parameters[1].StartsWith("Z"))
                    {
                        var movez = G1MoveZ.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(movez);
                        behandelt = true;
                    }

                }
            }
            if (line.StartsWith("G2 "))
            {
                var parameters = line.Split(' ');
                if (parameters[0].StartsWith("G2") && parameters[1].StartsWith("X"))
                {
                    var Temp = G2.Parse($"{parameters[1]} {parameters[2]} {parameters[3]} {parameters[4]} {parameters[5]}");
                    commands.Add(Temp);
                    behandelt = true;
                }
            }
            if (line.StartsWith("G3"))
            {
                var parameters = line.Split(' ');
                if (parameters[0].StartsWith("G3") && parameters[1].StartsWith("X"))
                {
                    var Temp = G3.Parse($"{parameters[1]} {parameters[2]} {parameters[3]} {parameters[4]} {parameters[5]}");
                    commands.Add(Temp);
                    behandelt = true;
                }
            }
            if (line.StartsWith("M204"))
            {
                behandelt = true;
                // Accelarationchange 
            }
            if (line.StartsWith("M104"))
            {
                behandelt = true;
                var parameters = line.Split(' ');
                if (parameters[0].StartsWith("M104") && parameters[1].StartsWith("S"))
                {
                    var Temp = M104.Parse(parameters[1]);
                    commands.Add(Temp);
                }
            }
            if (line.StartsWith("M73"))
            {
                var parameters = line.Split(' ');
                if (parameters[0].StartsWith("M73") && parameters[1].StartsWith("P") && parameters[2].StartsWith("R"))
                {
                    var percentage = M73.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                    commands.Add(percentage);
                    behandelt = true;
                }
            }
            if (line.StartsWith("M190"))
            {
                var parameters = line.Split(' ');
                if (parameters[0].StartsWith("M190") && parameters[1].StartsWith("S"))
                {
                    var Temp = M190.Parse(parameters[1]);
                    commands.Add(Temp);
                    behandelt = true;
                }
            }
            if (line.StartsWith("G28"))
            {
                var setOrigin = G28.Parse("G28");
                commands.Add(setOrigin);
                behandelt = true;
            }
            if (line.StartsWith("G92"))
            {
                var parameters = line.Split(' ');
                var setzero = G92.Parse($"{parameters[0]} {parameters[1]}");
                commands.Add(setzero);
                behandelt = true;
            }
            if (line.StartsWith("M106"))
            {
                var parameters = line.Split(' ');
                var setfanspeed = M106.Parse($"{parameters[0]} {parameters[1]}");
                commands.Add(setfanspeed);
                behandelt = true;
            }
            if (!behandelt && line != "")
            {
                Console.WriteLine(line);
            }
            return commands;
        }
    }
}
