using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IArrayGenerator
    {
        string Generate(ArrayStatement array);
    }
}