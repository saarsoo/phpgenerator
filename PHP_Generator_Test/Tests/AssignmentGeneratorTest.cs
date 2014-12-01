using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test
{
    [TestClass]
    public class AssignmentGeneratorTest
    {
        private AssignmentGenerator generator;
        private IdentifierGeneratorStub identifierGenerator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new AssignmentGenerator();
            this.generator.InjectDependency(this.identifierGenerator = new IdentifierGeneratorStub());
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            this.identifierGenerator.Result = "$foo";
            this.statementGenerator.Result = "\"bar\"";

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            string php = this.generator.Generate(assignment);

            Assert.AreEqual("$foo=\"bar\"", php);
        }
    }
}
