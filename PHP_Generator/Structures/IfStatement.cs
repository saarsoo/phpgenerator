namespace PHP_Generator.Structures
{
    public class IfStatement : IStatement
    {
        public readonly IStatement Condition;
        public readonly IStatement FalseBody;
        public readonly IStatement TrueBody;

        public IfStatement(IStatement condition, IStatement trueBody)
        {
            Condition = condition;
            TrueBody = trueBody;
        }

        public IfStatement(IStatement condition, IStatement trueBody, IStatement falseBody)
        {
            Condition = condition;
            TrueBody = trueBody;
            FalseBody = falseBody;
        }
    }
}