using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ArithmeticGeneratorTest
    {
        private ArithmeticGenerator _generator;
        private StatementGeneratorStub _statementGenerator;
        private ArithmeticOperatorGeneratorStub _arithmeticOperatorGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ArithmeticGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
            _generator.InjectDependency(_arithmeticOperatorGenerator = new ArithmeticOperatorGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] { "$foo", "$bar" };
            _arithmeticOperatorGenerator.Results = new[] { "+" };

            var php = _generator.Generate(new Arithmetic(new Identifier("foo"), ArithmeticOperator.Addition, new Identifier("bar")));

            Assert.AreEqual("$foo+$bar", php);
        }
    }
}
