using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class MethodGeneratorTest
    {
        private MethodGenerator _generator;
        private ModifierGeneratorStub _modifierGenerator;
        private ParameterGeneratorStub _parameterGenerator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new MethodGenerator();
            _generator.InjectDependency(_modifierGenerator = new ModifierGeneratorStub());
            _generator.InjectDependency(_parameterGenerator = new ParameterGeneratorStub());
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());

            _modifierGenerator.Results = new []{ "private" };
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Method("foo"));

            Assert.AreEqual("private function foo(){}", php);
        }

        [TestMethod]
        public void TestGenerateParameter()
        {
            _parameterGenerator.Results = new []{ "$bar" };

            var php = _generator.Generate(new Method("foo", new[] { new Parameter("bar") }));

            Assert.AreEqual("private function foo($bar){}", php);
        }

        [TestMethod]
        public void TestGenerateBody()
        {
            _statementGenerator.Results = new []{ "$foo=\"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var php = _generator.Generate(new Method("foo", assignment));

            Assert.AreEqual("private function foo(){$foo=\"bar\";}", php);
        }

        [TestMethod]
        public void TestGenerateBlockBody()
        {
            _statementGenerator.Results = new []{ "$foo=\"bar\";" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));
            var block = new Block(new[] { assignment });

            var php = _generator.Generate(new Method("foo", block));

            Assert.AreEqual("private function foo(){$foo=\"bar\";}", php);
        }
    }
}
