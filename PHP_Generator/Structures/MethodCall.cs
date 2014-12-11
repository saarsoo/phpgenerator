namespace PHP_Generator.Structures
{
    public class MethodCall : IStatement
    {
        public string Name { get; set; }
        public IStatement[] Arguments { get; set; }

        public MethodCall(string name)
        {
            Name = name;
            Arguments = new IStatement[] { };
        }
    }
}