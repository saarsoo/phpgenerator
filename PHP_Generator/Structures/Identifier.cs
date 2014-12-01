using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Identifier : IStatement
    {
        public readonly string Name;

        public Identifier(string name)
        {
            this.Name = name;
        }
    }
}
