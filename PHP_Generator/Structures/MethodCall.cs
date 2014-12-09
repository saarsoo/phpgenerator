namespace PHP_Generator.Structures
{
    public class MethodCall : IStatement
    {
        public readonly string Name;
        public readonly IStatement[] Arguments = { };

        public MethodCall(string name)
        {
            Name = name;
        }

        public MethodCall(string name, IStatement[] arguments)
        {
            Name = name;
            Arguments = arguments;
        }
    }
}