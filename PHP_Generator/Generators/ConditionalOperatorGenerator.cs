using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ConditionalOperatorGenerator : IConditionalOperatorGenerator
    {
        public string Generate(ConditionalOperator @operator)
        {
            switch (@operator)
            {
                case ConditionalOperator.And:
                    return "&&";
                case ConditionalOperator.Or:
                    return "||";
                case ConditionalOperator.Equal:
                    return "==";
                case ConditionalOperator.NotEqual:
                    return "!=";
            }

            throw new NotImplementedException();
        }
    }
}
