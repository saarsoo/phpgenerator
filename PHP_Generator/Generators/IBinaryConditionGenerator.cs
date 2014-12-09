using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IBinaryConditionGenerator
    {
        string Generate(BinaryCondition condition);
    }
}
