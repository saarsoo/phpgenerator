using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IMemberGenerator
    {
        string Generate(IMember member);
    }
}