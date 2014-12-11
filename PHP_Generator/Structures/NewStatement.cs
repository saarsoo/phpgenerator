namespace PHP_Generator.Structures
{
    public class NewStatement : IStatement
    {
        public IStatement Statement { get; set; }

        public NewStatement(IStatement statement)
        {
            Statement = statement;
        }
    }
}
