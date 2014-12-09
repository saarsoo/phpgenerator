namespace PHP_Generator_Test.Stubs
{
    internal abstract class GeneratorStub<T>
    {
        private int _index;
        public string[] Results { get; set; }

        public string Generate(T obj)
        {
            return Results[_index++];
        }
    }
}