using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class PropertyGeneratorTest
    {
        private PropertyGenerator _generator;
        private ModifierGeneratorStub _modifierGenerator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new PropertyGenerator();
            _generator.InjectDependency(_modifierGenerator = new ModifierGeneratorStub());
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());

            _modifierGenerator.Results = new[] {"private"};
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Property("foo"));

            Assert.AreEqual("private $foo;", php);
        }

        [TestMethod]
        public void TestGenerateAssignment()
        {
            _statementGenerator.Results = new[] {"\"bar\""};

            var php = _generator.Generate(new Property("foo")
            {
                DefaultValue = new Constant("bar")
            });

            Assert.AreEqual("private $foo=\"bar\";", php);
        }
    }
}