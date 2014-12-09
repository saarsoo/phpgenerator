using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class MemberGenerator : IMemberGenerator, IDependency<IPropertyGenerator>, IDependency<IMethodGenerator>
    {
        private IMethodGenerator _methodGenerator;
        private IPropertyGenerator _propertyGenerator;

        public void InjectDependency(IMethodGenerator dependency)
        {
            _methodGenerator = dependency;
        }

        public void InjectDependency(IPropertyGenerator dependency)
        {
            _propertyGenerator = dependency;
        }

        public string Generate(IMember member)
        {
            if (member is Property)
            {
                return _propertyGenerator.Generate((Property) member);
            }
            if (member is Method)
            {
                return _methodGenerator.Generate((Method) member);
            }

            throw new NotImplementedException();
        }
    }
}