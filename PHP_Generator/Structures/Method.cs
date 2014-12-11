namespace PHP_Generator.Structures
{
    public class Method : IMember
    {
        public readonly IStatement Body;
        public readonly Modifier Modifier = Modifier.Private;
        public readonly string Name;
        public readonly Parameter[] Parameters = {};

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

        public Method(string name, Parameter[] parameters, IStatement body)
        {
            Name = name;
            Parameters = parameters;
            Body = body;
        }
    }
}