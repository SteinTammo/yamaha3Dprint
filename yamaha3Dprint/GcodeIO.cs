using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
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

        private List<GcodeCommand> ReadLine(string line)
        {
            List<GcodeCommand> commands = new List<GcodeCommand>();
            // Remove Comments
            if (line.Contains(";"))
            {
                int index = line.IndexOf(";");
                if (index == 0)
                {
                    line = string.Empty;
                }
                else
                {
                    line = line.Substring(0, index);
                }
            }
            line = line.Trim();
            if (line.StartsWith("G1"))
            {
                var parameters = line.Split(' ');
                if (parameters.Length == 4)
                {
                    if (parameters[1].StartsWith("X") && parameters[2].StartsWith("Y"))
                    {
                        if (parameters[3].StartsWith("F"))
                        {
                            var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[3]}");
                            commands.Add(setflow);
                            var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                            commands.Add(move);
                        }
                        if (parameters[3].StartsWith("E"))
                        {
                            if(parameters[3].IndexOf("-")!=-1)
                            {
                                var move = G1MoveNegativ.Parse($"{parameters[0]} {parameters[1]} {parameters[2]} {parameters[3]}");
                                commands.Add(move);
                            }
                            else
                            {
                                var move = G1MovePositiv.Parse($"{parameters[0]} {parameters[1]} {parameters[2]} {parameters[3]}");
                                commands.Add(move);
                            }                            
                        }
                    }
                }
                if (parameters.Length == 3)
                {
                    if(parameters[1].StartsWith("Z") && parameters[2].StartsWith("F"))
                    {
                        var setflow = G1SetFlow.Parse($"{parameters[0]} {parameters[2]}");
                        commands.Add(setflow);
                        var moveZ = G1MoveZ.Parse($"{parameters[0]} {parameters[1]}");
                        commands.Add(moveZ);
                    }
                }
                if (parameters.Length == 2)
                {

                }
            }
            return commands;
        }
    }
}
