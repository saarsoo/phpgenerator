namespace PHP_Generator.Structures
{
    public class Assignment : IStatement
    {
        public readonly IStatement From;
        public readonly IStatement To;

        public Assignment(IStatement @from, IStatement to)
        {
            From = @from;
            To = to;
        }
    }
}