namespace PHP_Generator.Structures
{
    public class Method : IMember
    {
        public readonly string Name;
        public readonly Modifier Modifier = Modifier.Private;
        public readonly Parameter[] Parameters = { };
        public readonly IStatement Body;

        public Method(string name)
        {
            Name = name;
        }

        public Method(string name, IStatement body)
        {
            Name = name;
            Body = body;
        }

        public Method(string name, Parameter[] parameters)
        {
            Name = name;
            Parameters = parameters;
        }
    }
}
