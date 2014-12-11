namespace PHP_Generator.Structures
{
    public class Block : IStatement
    {
        public IStatement[] Statements { get; set; }

        public Block()
        {
            Statements = new IStatement[] { };
        }

        public Block(IStatement[] statements)
        {
            Statements = statements;
        }
    }
}