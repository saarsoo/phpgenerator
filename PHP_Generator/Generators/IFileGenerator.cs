using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public interface IFileGenerator
    {
        string Generate(File file);
    }
}
