using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IConditionGenerator
    {
        string Generate(Condition condition);
    }
}
