using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class ArrayStatement : IStatement
    {
        public Dictionary<IStatement, IStatement> Values { get; set; }

        public ArrayStatement()
        {
            Values = new Dictionary<IStatement, IStatement>();
        }

        public ArrayStatement(Dictionary<IStatement, IStatement> values)
        {
            Values = values;
        }
    }
}