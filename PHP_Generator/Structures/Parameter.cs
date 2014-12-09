namespace PHP_Generator.Structures
{
    public class Parameter
    {
        public readonly string Name;
        public readonly IStatement Statement;

        public Parameter(string name)
        {
            Name = name;
        }

        public Parameter(string name, IStatement statement)
        {
            Name = name;
            Statement = statement;
        }
    }
}