using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ParameterGeneratorTest
    {
        private ParameterGenerator _generator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ParameterGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Parameter("foo"));

            Assert.AreEqual("$foo", php);
        }

        [TestMethod]
        public void TestGenerateDefaultValue()
        {
            _statementGenerator.Results = new[] {"\"bar\""};

            var php = _generator.Generate(new Parameter("foo", new Constant("bar")));

            Assert.AreEqual("$foo=\"bar\"", php);
        }

        [TestMethod]
        public void TestGenerateWithType()
        {
            var php = _generator.Generate(new Parameter("Foo", "bar"));

            Assert.AreEqual("Foo $bar", php);
        }
    }
}