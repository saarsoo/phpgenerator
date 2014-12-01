using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Block : IStatement
    {
        public readonly IStatement[] Statements;

        public Block(IStatement[] statements)
        {
            this.Statements = statements;
        }
    }
}
