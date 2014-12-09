using System;
using System.Runtime.Remoting.Channels;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ArithmeticOperatorGenerator : IArithmeticOperatorGenerator
    {
        public string Generate(ArithmeticOperator @operator)
        {
            switch (@operator)
            {
                case ArithmeticOperator.Addition:
                    return "+";
                case ArithmeticOperator.Division:
                    return "/";
                case ArithmeticOperator.Multiplication:
                    return "*";
                case ArithmeticOperator.Subtraction:
                    return "-";
            }

            throw new NotImplementedException();
        }
    }
}
