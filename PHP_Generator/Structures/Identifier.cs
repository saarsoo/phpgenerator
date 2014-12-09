namespace PHP_Generator.Structures
{
    public class Identifier : IStatement
    {
        public readonly string Name;

        public Identifier(string name)
        {
            Name = name;
        }
    }
}