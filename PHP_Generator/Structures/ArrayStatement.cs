using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class ArrayStatement : IStatement
    {
        public readonly Dictionary<IStatement, IStatement> Values;

        public ArrayStatement(Dictionary<IStatement, IStatement> values)
        {
            Values = values;
        }
    }
}