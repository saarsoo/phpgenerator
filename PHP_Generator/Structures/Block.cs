using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class Block : IStatement
    {
        public IEnumerable<IStatement> Statements { get; set; }

        public Block()
        {
            Statements = new IStatement[] { };
        }

        public Block(IStatement[] statements)
        {
            Statements = statements;
        }
    }
}