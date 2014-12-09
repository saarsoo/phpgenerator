using System;

namespace PHP_Generator_Test.Stubs
{
    internal abstract class GeneratorStub<T>
    {
        private int _index;
        public string[] Results = {};

        public string Generate(T obj)
        {
            var index = _index++;

            if (Results.Length == index)
            {
                throw new Exception("Result not configured");
            }

            return Results[index];
        }
    }
}