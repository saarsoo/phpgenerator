using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ParameterGeneratorTest
    {
        private ParameterGenerator generator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new ParameterGenerator();
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Parameter("foo"));

            Assert.AreEqual("$foo", php);
        }

        [TestMethod]

        public void TestGenerateDefaultValue()
        {
            this.statementGenerator.Result = "\"bar\"";

            string php = this.generator.Generate(new Parameter("foo", new Constant("bar")));

            Assert.AreEqual("$foo=\"bar\"", php);
        }
    }
}
