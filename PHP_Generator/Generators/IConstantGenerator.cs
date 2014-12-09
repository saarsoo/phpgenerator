using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IConstantGenerator
    {
        string Generate(Constant constant);
    }
}