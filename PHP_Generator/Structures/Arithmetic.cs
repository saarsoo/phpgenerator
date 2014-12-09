namespace PHP_Generator.Structures
{
    public class Arithmetic : IStatement
    {
        public readonly IStatement LeftStatement;
        public readonly ArithmeticOperator Operator;
        public readonly IStatement RightStatement;

        public Arithmetic(IStatement leftStatement, ArithmeticOperator @operator, IStatement rightStatement)
        {
            LeftStatement = leftStatement;
            Operator = @operator;
            RightStatement = rightStatement;
        }
    }
}