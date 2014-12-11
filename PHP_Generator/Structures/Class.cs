namespace PHP_Generator.Structures
{
    public class Class : IStatement
    {
        public string Name { get; set; }

        public string Extends { get; set; }
        public string[] Implements { get; set; }
        public IMember[] Members { get; set; }

        public Class(string name)
        {
            Name = name;
            Implements = new string[] { };
            Members = new IMember[] { };
        }
    }
}