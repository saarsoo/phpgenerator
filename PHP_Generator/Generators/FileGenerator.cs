using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class FileGenerator : IFileGenerator, IDependency<IReferenceGenerator>, IDependency<IClassGenerator>
    {
        private IReferenceGenerator referenceGenerator;
        private IClassGenerator classGenerator;

        public string Generate(File file)
        {
            string code = "<?php ";

            if (!String.IsNullOrWhiteSpace(file.Namespace))
            {
                code += "namespace " + file.Namespace + ";";
            }

            foreach (Reference reference in file.References)
            {
                code += this.referenceGenerator.Generate(reference);
            }

            foreach (Class @class in file.Classes)
            {
                code += this.classGenerator.Generate(@class);
            }

            return code;
        }

        public void InjectDependency(IReferenceGenerator dependency)
        {
            this.referenceGenerator = dependency;
        }

        public void InjectDependency(IClassGenerator dependency)
        {
            this.classGenerator = dependency;
        }
    }
}
