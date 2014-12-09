namespace PHP_Generator.Structures
{
    public class Block : IStatement
    {
        public readonly IStatement[] Statements;

        public Block(Assignment[] statements)
        {
            Statements = statements;
        }
    }
}
