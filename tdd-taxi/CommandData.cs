using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tdd_taxi
{
    public class CommandData
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public CommandData(string Type, string Value)
        {
            this.Type = Type;
            this.Value = Value;
        }
    }
}
