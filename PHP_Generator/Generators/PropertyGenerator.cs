using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class PropertyGenerator : IPropertyGenerator, IDependency<IModifierGenerator>,
        IDependency<IStatementGenerator>
    {
        private IModifierGenerator _modifierGenerator;
        private IStatementGenerator _statementGenerator;

        public void InjectDependency(IModifierGenerator dependency)
        {
            _modifierGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }

        public string Generate(Property property)
        {
            var modifier = _modifierGenerator.Generate(property.Modifier);

            var code = String.Format("{0} ${1}", modifier, property.Name);

            if (property.Statement != null)
            {
                code += "=" + _statementGenerator.Generate(property.Statement);
            }

            return code + ";";
        }
    }
}