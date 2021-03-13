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
            int currentmoveindex = -1;
            G1Move current = null;
            for (int i = 0; i < commands.Count; i++)
            {
                if (commands[i] is G1Move g1move)
                {
                    if (current == null)
                    {
                        current = g1move;
                        currentmoveindex = i;
                    }

                }
                else if (current != null)
                {
                    if (i - currentmoveindex > 1)
                    {
                        // Zusammenfassen
                        List<G1Move> moves = new List<G1Move>();
                        for (int j = currentmoveindex; j < i; j++)
                        {
                            moves.Add((G1Move)commands[j]);
                        }
                        foreach (var move in moves)
                        {
                            commands.Remove(move);
                        }
                        var movecollection = new G1MoveCollection(moves);
                        commands.Insert(currentmoveindex, movecollection);
                        i = currentmoveindex + 1;
                    }
                    current = null;
                    currentmoveindex = -1;

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
                            var move = G1Move.Parse($"{parameters[0]} {parameters[1]} {parameters[2]}");
                            commands.Add(move);
                        }
                        if (parameters[3].StartsWith("E"))
                        {
                            var move = G1Move.Parse($"{parameters[0]} {parameters[1]} {parameters[2]} {parameters[3]}");
                            commands.Add(move);
                        }
                    }
                }
                if (parameters.Length == 3)
                {

                }
                if (parameters.Length == 2)
                {

                }
            }
            return commands;
        }
    }
}
