using System;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class StatementGenerator : IStatementGenerator,
        IDependency<IConstantGenerator>,
        IDependency<IIdentifierGenerator>,
        IDependency<IAssignmentGenerator>,
        IDependency<IBlockGenerator>,
        IDependency<IArrayGenerator>,
        IDependency<IAccessorGenerator>,
        IDependency<IMethodCallGenerator>,
        IDependency<IReturnStatementGenerator>
    {
        private IAssignmentGenerator _assignmentGenerator;
        private IBlockGenerator _blockGenerator;
        private IConstantGenerator _constantGenerator;
        private IIdentifierGenerator _identifierGenerator;
        private IArrayGenerator _arrayGenerator;
        private IAccessorGenerator _accessorGenerator;
        private IMethodCallGenerator _methodCallGenerator;
        private IReturnStatementGenerator _returnStatementGenerator;

        public void InjectDependency(IAssignmentGenerator dependency)
        {
            _assignmentGenerator = dependency;
        }

        public void InjectDependency(IBlockGenerator dependency)
        {
            _blockGenerator = dependency;
        }

        public void InjectDependency(IConstantGenerator dependency)
        {
            _constantGenerator = dependency;
        }

        public void InjectDependency(IIdentifierGenerator dependency)
        {
            _identifierGenerator = dependency;
        }

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
            if (statement is ArrayStatement)
            {
                return _arrayGenerator.Generate(statement as ArrayStatement);
            }
            if (statement is Accessor)
            {
                return _accessorGenerator.Generate(statement as Accessor);
            }
            if (statement is MethodCall)
            {
                return _methodCallGenerator.Generate(statement as MethodCall);
            }
            if (statement is ReturnStatement)
            {
                return _returnStatementGenerator.Generate(statement as ReturnStatement);
            }

            throw new NotImplementedException();
        }

        public void InjectDependency(IArrayGenerator dependency)
        {
            _arrayGenerator = dependency;
        }

        public void InjectDependency(IAccessorGenerator dependency)
        {
            _accessorGenerator = dependency;
        }

        public void InjectDependency(IMethodCallGenerator dependency)
        {
            _methodCallGenerator = dependency;
        }

        public void InjectDependency(IReturnStatementGenerator dependency)
        {
            _returnStatementGenerator = dependency;
        }
    }
}