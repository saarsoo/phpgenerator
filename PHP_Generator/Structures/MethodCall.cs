using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class MethodCall : IStatement
    {
        public string Name { get; set; }
        public IEnumerable<IStatement> Arguments { get; set; }

        public MethodCall(string name)
        {
            Name = name;
            Arguments = new IStatement[] { };
        }
    }
}