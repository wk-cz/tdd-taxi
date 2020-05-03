using System;
using System.Collections.Generic;
using System.Linq;

namespace tdd_taxi
{
    public class Command
    {
        private List<CommandData> commandDatas = new List<CommandData>();
        public Command(string commandLine)
        {
            var commands = commandLine.Split(' ').ToList();
            if (null != commands && commands.Count > 0)
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    var tempType = commands[i];
                    if (tempType[0] == '-' && !isValue(tempType))
                    {
                        string type = tempType.Substring(1);
                        string value = string.Empty;
                        if (i + 1 < commands.Count)
                        {
                            var tempValue = commands[i + 1];
                            if (tempValue[0] != '-' || isValue(tempValue)) { value = tempValue; }
                        }
                        CommandData commandData = new CommandData(type, value);
                        commandDatas.Add(commandData);
                    }
                }
            }
        }

        public object GetValue(string name)
        {
            int iTemp = 0;
            string value = string.Empty;
            foreach (var tempData in commandDatas)
            {
                if (0 == string.Compare(tempData.Type, name))
                {
                    value = tempData.Value;
                }
            }
            switch (name)
            {
                case "M":
                case "T":
                    if (Int32.TryParse(value, out iTemp)) { return iTemp; }
                    else { return null; }
                default:
                    return value;
            }
        }

        private bool isValue(string value)
        {
            bool ret = false;
            if (value[0] == '-')
            {
                if (value.Length > 2) { ret = true; }
                if (value[1] >= '0' && value[1] <= '9') { ret = true; }
            }
            return ret;
        }
    }
}
