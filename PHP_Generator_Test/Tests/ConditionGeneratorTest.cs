using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ConditionGeneratorTest
    {
        private ConditionGenerator _generator;
        private ConditionalOperatorGeneratorStub _conditionalOperatorGenerator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ConditionGenerator();
            _generator.InjectDependency(_conditionalOperatorGenerator = new ConditionalOperatorGeneratorStub());
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] { "\"foo\"", "\"bar\"" };
            _conditionalOperatorGenerator.Results = new[] { "&&" };

            var php = _generator.Generate(new Condition(new Constant("foo"), ConditionalOperator.And, new Constant("bar")));

            Assert.AreEqual("\"foo\"&&\"bar\"", php);
        }
    }
}