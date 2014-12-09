namespace PHP_Generator.Structures
{
    public class Condition : IStatement
    {
        public readonly IStatement LeftCondition;
        public readonly ConditionalOperator Operator;
        public readonly IStatement RightCondition;

        public Condition(IStatement leftCondition, ConditionalOperator @operator, IStatement rightCondition)
        {
            LeftCondition = leftCondition;
            Operator = @operator;
            RightCondition = rightCondition;
        }
    }
}
