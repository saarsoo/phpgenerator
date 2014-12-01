using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator
{
    public class StatementGenerator : IStatementGenerator,
        IDependency<IConstantGenerator>,
        IDependency<IIdentifierGenerator>,
        IDependency<IAssignmentGenerator>,
        IDependency<IBlockGenerator>
    {
        private IConstantGenerator constantGenerator;
        private IIdentifierGenerator identifierGenerator;
        private IAssignmentGenerator assignmentGenerator;
        private IBlockGenerator blockGenerator;

        public string Generate(IStatement statement)
        {
            if (statement is Constant)
            {
                return this.constantGenerator.Generate(statement as Constant);
            }
            else if (statement is Identifier)
            {
                return this.identifierGenerator.Generate(statement as Identifier);
            }
            else if (statement is Assignment)
            {
                return this.assignmentGenerator.Generate(statement as Assignment);
            }
            else if (statement is Block)
            {
                return this.blockGenerator.Generate(statement as Block);
            }
            else if (statement is PHPStart)
            {
                return "<?php";
            }

            throw new NotImplementedException();
        }

        public void InjectDependency(IConstantGenerator dependency)
        {
            this.constantGenerator = dependency;
        }

        public void InjectDependency(IIdentifierGenerator dependency)
        {
            this.identifierGenerator = dependency;
        }

        public void InjectDependency(IAssignmentGenerator dependency)
        {
            this.assignmentGenerator = dependency;
        }

        public void InjectDependency(IBlockGenerator dependency)
        {
            this.blockGenerator = dependency;
        }
    }
}