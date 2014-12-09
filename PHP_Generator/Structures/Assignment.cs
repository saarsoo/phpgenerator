namespace PHP_Generator.Structures
{
    public class Assignment : IStatement
    {
        public readonly Identifier Identifier;
        public readonly IStatement Statement;

        public Assignment(Identifier identifier, IStatement statement)
        {
            Identifier = identifier;
            Statement = statement;
        } 
    }
}
