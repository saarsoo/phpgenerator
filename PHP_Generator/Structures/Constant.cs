namespace PHP_Generator.Structures
{
    public class Constant : IStatement
    {
        public object Value { get; set; }

        public Constant(object value)
        {
            Value = value;
        }
    }
}