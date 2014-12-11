namespace PHP_Generator.Structures
{
    public class IfStatement : IStatement
    {
        public IStatement Condition { get; set; }
        public IStatement FalseBody { get; set; }
        public IStatement TrueBody { get; set; }

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