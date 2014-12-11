using System.Collections.Generic;

namespace PHP_Generator.Structures
{
    public class MethodCall : IStatement
    {
        public IStatement From { get; set; }
        public IEnumerable<IStatement> Arguments { get; set; }

        public MethodCall(IStatement from)
        {
            From = from;
            Arguments = new IStatement[] { };
        }

        public MethodCall(string name)
        {
            From = new Identifier(name, true);
            Arguments = new IStatement[] { };
        }
    }
}