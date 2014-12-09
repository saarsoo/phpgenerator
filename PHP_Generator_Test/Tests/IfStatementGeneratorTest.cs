using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class IfStatementGeneratorTest
    {
        private IfStatementGenerator _generator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new IfStatementGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] { "true", "$foo=\"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var php = _generator.Generate(new IfStatement(new Constant(true), assignment));

            Assert.AreEqual("if(true){$foo=\"bar\";}", php);
        }

        [TestMethod]
        public void TestGenerateFalseBody()
        {
            _statementGenerator.Results = new[] { "true", "$foo=\"bar\"", "$bar=\"foo\"" };

            var assignment1 = new Assignment(new Identifier("foo"), new Constant("bar"));
            var assignment2 = new Assignment(new Identifier("bar"), new Constant("foo"));

            var php = _generator.Generate(new IfStatement(new Constant(true), assignment1, assignment2));

            Assert.AreEqual("if(true){$foo=\"bar\";}else{$bar=\"foo\";}", php);
        }
    }
}
