namespace PHP_Generator.Structures
{
    public class Property : IMember
    {
        public readonly Modifier Modifier = Modifier.Private;
        public readonly string Name;
        public readonly IStatement Statement;

        public Property(string name)
        {
            Name = name;
        }

        public Property(string name, IStatement statement)
        {
            Name = name;
            Statement = statement;
        }

        public Property(string name, Modifier modifier)
        {
            Name = name;
            Modifier = modifier;
        }

        public Property(string name, Modifier modifier, IStatement statement)
        {
            Name = name;
            Modifier = modifier;
            Statement = statement;
        }
    }
}