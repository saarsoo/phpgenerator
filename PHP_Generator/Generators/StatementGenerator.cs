using System;
using PHP_Generator.Generators.Interfaces;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class StatementGenerator : IStatementGenerator,
        IDependency<IConstantGenerator>,
        IDependency<IIdentifierGenerator>,
        IDependency<IAssignmentGenerator>,
        IDependency<IBlockGenerator>
    {
        private IConstantGenerator _constantGenerator;
        private IIdentifierGenerator _identifierGenerator;
        private IAssignmentGenerator _assignmentGenerator;
        private IBlockGenerator _blockGenerator;

        public string Generate(IStatement statement)
        {
            if (statement is Constant)
            {
                return _constantGenerator.Generate(statement as Constant);
            }
            if (statement is Identifier)
            {
                return _identifierGenerator.Generate(statement as Identifier);
            }
            if (statement is Assignment)
            {
                return _assignmentGenerator.Generate(statement as Assignment);
            }
            if (statement is Block)
            {
                return _blockGenerator.Generate(statement as Block);
            }
            if (statement is PhpStart)
            {
                return "<?php";
            }

            throw new NotImplementedException();
        }

        public void InjectDependency(IConstantGenerator dependency)
        {
            _constantGenerator = dependency;
        }

        public void InjectDependency(IIdentifierGenerator dependency)
        {
            _identifierGenerator = dependency;
        }

        public void InjectDependency(IAssignmentGenerator dependency)
        {
            _assignmentGenerator = dependency;
        }

        public void InjectDependency(IBlockGenerator dependency)
        {
            _blockGenerator = dependency;
        }
    }
}