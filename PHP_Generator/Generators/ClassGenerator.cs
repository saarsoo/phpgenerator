using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class ClassGenerator : IClassGenerator, IDependency<IPropertyGenerator>, IDependency<IMethodGenerator>
    {
        private IPropertyGenerator propertyGenerator;
        private IMethodGenerator methodGenerator;

        public string Generate(Class @class)
        {
            string code = String.Format("class {0}", @class.Name);

            if (!String.IsNullOrWhiteSpace(@class.Extends))
            {
                code += String.Format(" extends {0}", @class.Extends);
            }

            if (@class.Implements.Length > 0)
            {
                code += String.Format(" implements {0}", String.Join(",", @class.Implements));
            }

            code += "{";

            foreach (Property property in @class.Properties)
            {
                code += this.propertyGenerator.Generate(property);
            }

            foreach (Method method in @class.Methods)
            {
                code += this.methodGenerator.Generate(method);
            }

            code += "}";

            return code;
        }

        public void InjectDependency(IPropertyGenerator dependency)
        {
            this.propertyGenerator = dependency;
        }

        public void InjectDependency(IMethodGenerator dependency)
        {
            this.methodGenerator = dependency;
        }
    }
}
