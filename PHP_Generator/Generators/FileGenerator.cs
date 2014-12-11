using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class FileGenerator : IFileGenerator, IDependency<IReferenceGenerator>, IDependency<IClassGenerator>
    {
        private IClassGenerator _classGenerator;
        private IReferenceGenerator _referenceGenerator;

        public static FileGenerator CreateGenerator()
        {
            return new Resolver("PHP_Generator").Resolve<FileGenerator>();
        }

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

        public void InjectDependency(IClassGenerator dependency)
        {
            _classGenerator = dependency;
        }

        public void InjectDependency(IReferenceGenerator dependency)
        {
            _referenceGenerator = dependency;
        }
    }
}