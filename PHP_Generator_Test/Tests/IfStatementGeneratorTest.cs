using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class IfStatementGeneratorTest
    {
        private IfStatementGenerator generator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new IfStatementGenerator();
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            this.statementGenerator.Results = new string[] { "true", "$foo=\"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            string php = this.generator.Generate(new IfStatement(new Constant(true), assignment));

            Assert.AreEqual("if(true){$foo=\"bar\";}", php);
        }

        [TestMethod]
        public void TestGenerateFalseBody()
        {
            this.statementGenerator.Results = new string[] { "true", "$foo=\"bar\"", "$bar=\"foo\"" };

            var assignment1 = new Assignment(new Identifier("foo"), new Constant("bar"));
            var assignment2 = new Assignment(new Identifier("bar"), new Constant("foo"));

            string php = this.generator.Generate(new IfStatement(new Constant(true), assignment1, assignment2));

            Assert.AreEqual("if(true){$foo=\"bar\";}else{$bar=\"foo\";}", php);
        }
    }
}
