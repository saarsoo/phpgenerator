namespace PHP_Generator.Structures
{
    public class Property : IMember
    {
        public Modifier Modifier { get; set; }
        public string Name { get; set; }
        public IStatement DefaultValue { get; set; }

        public Property(string name)
        {
            Name = name;
        }
    }
}