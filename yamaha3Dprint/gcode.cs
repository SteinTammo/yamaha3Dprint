namespace yamaha3Dprint
{
    public class processGCode
    {
        public string[] writeline;
        public string[] coordinates;
        public processGCode()
        {
            writeline = new string[2];
            writeline[0] = "";
            writeline[1] = "";
            coordinates = new string[3];
            coordinates[0] = "0.0";
            coordinates[1] = "0.0";
            coordinates[2] = "0.0";
        }

        // delete all comments in GCode
        public string[] ProcessFile(string[] content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i].StartsWith(";"))
                    content[i] = "";
                int index = content[i].IndexOf(";");
                if (index > 0)
                {
                    content[i] = content[i].Substring(0, index);
                }
            }
            return content;
        }

        // create and modify write command for serial communication 
        public string writeLines(string gcodeline, int i)
        {
            writeline[0] = "";
            writeline[1] = "";
            if (gcodeline == "")
            {
                return writeline[0];
            }
            var parameters = gcodeline.Split(' ');
            if (parameters[0] == "G1")
            {
                G1(parameters, i);
            }
            return writeline[0];
        }
        public void G1(string[] Parameters, int i)
        {
            if (Parameters.Length == 4)
            {
                Parameters[1] = Parameters[1].Replace("X", "");
                Parameters[2] = Parameters[2].Replace("Y", "");
                int index1 = Parameters[1].IndexOf(".");
                int index2 = Parameters[2].IndexOf(".");
                Parameters[1] = Parameters[1].Remove(index1 + 3);
                Parameters[2] = Parameters[2].Remove(index2 + 3);
                coordinates[0] = Parameters[1];
                coordinates[1] = Parameters[2];
                writeline[0] = "@P" + i + "=" + coordinates[0] + " " + coordinates[1] + " " + coordinates[2] + " " + "0.0 0.0 0.0";
            }
        }
    }
}
