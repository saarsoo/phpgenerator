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
        private StatementGeneratorStub _statementGenerator;
        private AssignmentTypeGeneratorStub _assignmentTypeGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new AssignmentGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
            _generator.InjectDependency(_assignmentTypeGenerator = new AssignmentTypeGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] { "$foo", "\"bar\"" };
            _assignmentTypeGenerator.Results = new[] { "=" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var php = _generator.Generate(assignment);

            Assert.AreEqual("$foo=\"bar\"", php);
        }
    }
}