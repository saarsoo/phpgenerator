using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class Assignment : IStatement
    {
        public readonly Identifier Identifier;
        public readonly IStatement Statement;

        public Assignment(Identifier identifier, IStatement statement)
        {
            this.Identifier = identifier;
            this.Statement = statement;
        } 
    }
}
