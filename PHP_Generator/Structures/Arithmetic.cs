namespace PHP_Generator.Structures
{
    public class Arithmetic : IStatement
    {
        public IStatement LeftStatement { get; set; }
        public ArithmeticOperator Operator { get; set; }
        public IStatement RightStatement { get; set; }

        public Arithmetic(IStatement leftStatement, ArithmeticOperator @operator, IStatement rightStatement)
        {
            LeftStatement = leftStatement;
            Operator = @operator;
            RightStatement = rightStatement;
        }
    }
}