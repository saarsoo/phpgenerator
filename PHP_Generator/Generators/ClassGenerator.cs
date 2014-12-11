using System;
using System.Linq;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ClassGenerator : IClassGenerator, IDependency<IMemberGenerator>
    {
        private IMemberGenerator _memberGenerator;

        public string Generate(Class @class)
        {
            var code = String.Format("class {0}", @class.Name);

            if (!String.IsNullOrWhiteSpace(@class.Extends))
            {
                code += String.Format(" extends {0}", @class.Extends);
            }

            if (@class.Implements.Any())
            {
                code += String.Format(" implements {0}", String.Join(",", @class.Implements));
            }

            code += "{";

            foreach (var member in @class.Members)
            {
                code += _memberGenerator.Generate(member);
            }

            code += "}";

            return code;
        }

        public void InjectDependency(IMemberGenerator dependency)
        {
            _memberGenerator = dependency;
        }
    }
}