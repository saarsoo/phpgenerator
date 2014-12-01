using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Parameter
    {
        public readonly string Name;
        public readonly IStatement Statement;

        public Parameter(string name)
        {
            this.Name = name;
        }

        public Parameter(string name, IStatement statement)
        {
            this.Name = name;
            this.Statement = statement;
        }
    }
}
