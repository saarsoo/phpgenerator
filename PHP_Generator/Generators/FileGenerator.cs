using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class FileGenerator : IFileGenerator, IDependency<IReferenceGenerator>, IDependency<IClassGenerator>
    {
        private IReferenceGenerator _referenceGenerator;
        private IClassGenerator _classGenerator;

        public string Generate(File file)
        {
            var code = "<?php ";

            if (!String.IsNullOrWhiteSpace(file.Namespace))
            {
                code += "namespace " + file.Namespace + ";";
            }

            foreach (var reference in file.References)
            {
                code += _referenceGenerator.Generate(reference);
            }

            foreach (var @class in file.Classes)
            {
                code += _classGenerator.Generate(@class);
            }

            return code;
        }

        public void InjectDependency(IReferenceGenerator dependency)
        {
            _referenceGenerator = dependency;
        }

        public void InjectDependency(IClassGenerator dependency)
        {
            _classGenerator = dependency;
        }
    }
}
