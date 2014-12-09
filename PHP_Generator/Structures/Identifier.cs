namespace PHP_Generator.Structures
{
    public class Identifier : IStatement
    {
        public readonly string Name;
        public readonly bool Accessed;

        public Identifier(string name, bool accessed = false)
        {
            Name = name;
            Accessed = accessed;
        }
    }
}