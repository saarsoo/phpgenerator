using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class AssignmentGeneratorTest
    {
        private AssignmentGenerator _generator;
        private IdentifierGeneratorStub _identifierGenerator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new AssignmentGenerator();
            _generator.InjectDependency(_identifierGenerator = new IdentifierGeneratorStub());
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _identifierGenerator.Results = new []{ "$foo" };
            _statementGenerator.Results = new []{ "\"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var php = _generator.Generate(assignment);

            Assert.AreEqual("$foo=\"bar\"", php);
        }
    }
}
