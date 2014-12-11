namespace PHP_Generator.Structures
{
    public class Parameter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public IStatement DefaultValue { get; set; }

        public Parameter(string name)
        {
            Name = name;
        }
    }
}