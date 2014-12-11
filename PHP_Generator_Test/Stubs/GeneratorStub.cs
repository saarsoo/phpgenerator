using System;
using System.Collections.Generic;
using System.Linq;

namespace PHP_Generator_Test.Stubs
{
    internal abstract class GeneratorStub<T>
    {
        private int _index;
        public IEnumerable<string> Results = new string[] { };

        public string Generate(T obj)
        {
            var index = _index++;

            if (Results.Count() == index)
            {
                throw new Exception("Result not configured");
            }

            return Results.ElementAt(index);
        }
    }
}