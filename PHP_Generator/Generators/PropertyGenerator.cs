using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class PropertyGenerator : IPropertyGenerator, IDependency<IModifierGenerator>, IDependency<IStatementGenerator>
    {
        private IModifierGenerator modifierGenerator;
        private IStatementGenerator statementGenerator;

        public string Generate(Property property)
        {
            string modifier = this.modifierGenerator.Generate(property.Modifier);

            string code = String.Format("{0} ${1}", modifier, property.Name);

            if (property.Statement != null)
            {
                code += "=" + this.statementGenerator.Generate(property.Statement);
            }

            return code + ";";
        }

        public void InjectDependency(IModifierGenerator dependency)
        {
            this.modifierGenerator = dependency;
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            this.statementGenerator = dependency;
        }
    }
}
