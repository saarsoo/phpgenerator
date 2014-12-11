namespace PHP_Generator.Structures
{
    public class Method : IMember
    {
        public IStatement Body { get; set; }
        public Modifier Modifier { get; set; }
        public string Name { get; set; }
        public Parameter[] Parameters { get; set; }

        public Method(string name)
        {
            Name = name;
            Parameters = new Parameter[] {};
        }
    }
}