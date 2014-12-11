using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class ArrayStatement : IStatement
    {
        public readonly Dictionary<IStatement, IStatement> Values = new Dictionary<IStatement, IStatement>();

        public ArrayStatement()
        {
        }

        public ArrayStatement(Dictionary<IStatement, IStatement> values)
        {
            Values = values;
        }
    }
}