using PHP_Generator.Structures;

namespace PHP_Generator.Generators.Interfaces
{
    public interface IConstantGenerator
    {
        string Generate(Constant constant);
    }
}
