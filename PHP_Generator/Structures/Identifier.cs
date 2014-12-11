namespace PHP_Generator.Structures
{
    public class Identifier : IStatement
    {
        public string Name { get; set; }
        public bool Accessed { get; set; }

        public Identifier(string name, bool accessed = false)
        {
            Name = name;
            Accessed = accessed;
        }
    }
}