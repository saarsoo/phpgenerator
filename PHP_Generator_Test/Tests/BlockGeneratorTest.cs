using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test
{
    [TestClass]
    public class BlockGeneratorTest
    {
        private BlockGenerator generator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new BlockGenerator();
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            this.statementGenerator.Result = "$foo = \"bar\"";

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var block = new Block(new []{assignment});

            string php = this.generator.Generate(block);

            Assert.AreEqual("$foo = \"bar\";", php);
        }
    }
}
