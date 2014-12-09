namespace PHP_Generator.Structures
{
    public class Constant : IStatement
    {
        public readonly object Value;

        public Constant(object value)
        {
            Value = value;
        }
    }
}
