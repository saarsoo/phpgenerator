using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class MemberGenerator : IMemberGenerator, IDependency<IPropertyGenerator>, IDependency<IMethodGenerator>
    {
        private IPropertyGenerator _propertyGenerator;
        private IMethodGenerator _methodGenerator;

        public string Generate(IMember member)
        {
            if (member is Property)
            {
                return _propertyGenerator.Generate((Property) member);
            }
            else if (member is Method)
            {
                return _methodGenerator.Generate((Method) member);
            }

            throw new NotImplementedException();
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