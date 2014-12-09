namespace PHP_Generator_Test.Stubs
{
    abstract class GeneratorStub<T>
    {
        public string[] Results { get; set; }
        private int _index;

        public string Generate(T obj){
            return Results[_index++];
        }
    }
}
