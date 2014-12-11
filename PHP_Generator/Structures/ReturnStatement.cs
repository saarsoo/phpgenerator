namespace PHP_Generator.Structures
{
    public class ReturnStatement : IStatement
    {
        public IStatement Statement { get; set; }

        public ReturnStatement(IStatement statement)
        {
            Statement = statement;
        }
    }
}
