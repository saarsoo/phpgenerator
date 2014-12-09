namespace PHP_Generator.Structures
{
    public class BinaryCondition : IStatement
    {
        public readonly IStatement LeftCondition;
        public readonly ConditionalOperator Operator;
        public readonly IStatement RightCondition;

        public BinaryCondition(IStatement leftCondition, ConditionalOperator @operator, IStatement rightCondition)
        {
            LeftCondition = leftCondition;
            Operator = @operator;
            RightCondition = rightCondition;
        }
    }
}
