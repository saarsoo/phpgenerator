using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class BlockGenerator : IBlockGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(Block block)
        {
            var code = "";

            foreach (var statement in block.Statements)
            {
                code += _statementGenerator.Generate(statement);
                code += ";";
            }

            return code;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
