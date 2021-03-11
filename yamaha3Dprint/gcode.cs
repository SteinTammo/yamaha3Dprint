using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yamaha3Dprint
{
    public class processGCode
    {
        string[] writeline;
        public processGCode()
        {
            writeline = new string[2];
            writeline[0] = "";
            writeline[1] = "";
        }
        public string[] ProcessFile(string[] content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].StartsWith(";"))
                    content[i] = "";
                int index = content[i].IndexOf(";");
                if(index > 0)
                {
                    content[i] = content[i].Substring(0, index);
                }
            }
            return content;
        }
        public string[] writeLines(string gcodeline)
        {
            writeline[0] = "";
            writeline[1] = "";
            if (gcodeline == "")
            {
                return writeline;
            }
            var parameters = gcodeline.Split(' ');
            if (parameters[0]=="G1")
            {
                G1(parameters);
            }
            return writeline;
        }
        public void G1(string[] Parameters)
        {
            if(Parameters.Length==4)
            {
                Parameters[1]=Parameters[1].Replace("X", "");
                Parameters[2]=Parameters[2].Replace("Y", "");
                writeline[0] = "@MOVE L," + Parameters[1] + " " + Parameters[2] + "0.0 0.0 0.0";
            }
        }
    }
}
