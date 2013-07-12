using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPX_Analyst.Model
{
    public class Metadata
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Metadata(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
