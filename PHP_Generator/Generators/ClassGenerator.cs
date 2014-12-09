using System;
using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ClassGenerator : IClassGenerator, IDependency<IPropertyGenerator>, IDependency<IMethodGenerator>
    {
        private IPropertyGenerator _propertyGenerator;
        private IMethodGenerator _methodGenerator;

        public string Generate(Class @class)
        {
            var code = String.Format("class {0}", @class.Name);

            if (!String.IsNullOrWhiteSpace(@class.Extends))
            {
                code += String.Format(" extends {0}", @class.Extends);
            }

            if (@class.Implements.Length > 0)
            {
                code += String.Format(" implements {0}", String.Join(",", @class.Implements));
            }

            code += "{";

            foreach (var property in @class.Properties)
            {
                code += _propertyGenerator.Generate(property);
            }

            foreach (var method in @class.Methods)
            {
                code += _methodGenerator.Generate(method);
            }

            code += "}";

            return code;
        }

        public void InjectDependency(IPropertyGenerator dependency)
        {
            _propertyGenerator = dependency;
        }

        public void InjectDependency(IMethodGenerator dependency)
        {
            _methodGenerator = dependency;
        }
    }
}
