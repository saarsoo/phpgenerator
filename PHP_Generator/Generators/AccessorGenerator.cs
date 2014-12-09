using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class AccessorGenerator : IAccessorGenerator, IDependency<IStatementGenerator>, IDependency<IAccessorTypeGenerator>
    {
        private IAccessorTypeGenerator _accessorTypeGenerator;
        private IStatementGenerator _statementGenerator;

        public string Generate(Accessor accessor)
        {
            var from = _statementGenerator.Generate(accessor.From);
            var to = _statementGenerator.Generate(accessor.To);

            if (accessor.Type == AccessorType.Index)
            {
                return String.Format("{0}[{1}]", from, to);
            }

            var type = _accessorTypeGenerator.Generate(accessor.Type);

            return String.Format("{0}{1}{2}", from, type, to);
        }

        public void InjectDependency(IAccessorTypeGenerator dependency)
        {
            _accessorTypeGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}
