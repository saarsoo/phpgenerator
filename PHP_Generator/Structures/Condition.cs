namespace PHP_Generator.Structures
{
    public class Condition : IStatement
    {
        public IStatement LeftCondition { get; set; }
        public ConditionalOperator Operator { get; set; }
        public IStatement RightCondition { get; set; }

        public Condition(IStatement leftCondition, ConditionalOperator @operator, IStatement rightCondition)
        {
            LeftCondition = leftCondition;
            Operator = @operator;
            RightCondition = rightCondition;
        }
    }
}
