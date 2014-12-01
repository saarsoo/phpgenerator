using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class PropertyGeneratorTest
    {
        private PropertyGenerator generator;
        private ModifierGeneratorStub modifierGenerator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new PropertyGenerator();
            this.generator.InjectDependency(this.modifierGenerator = new ModifierGeneratorStub());
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());

            this.modifierGenerator.Result = "private";
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Property("foo"));

            Assert.AreEqual("private $foo;", php);
        }

        [TestMethod]
        public void TestGenerateAssignment()
        {
            this.statementGenerator.Result = "\"bar\"";

            string php = this.generator.Generate(new Property("foo", new Constant("bar")));

            Assert.AreEqual("private $foo=\"bar\";", php);
        }
    }
}
