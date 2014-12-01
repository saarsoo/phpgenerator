using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test
{
    [TestClass]
    public class StatementGeneratorTest
    {
        private StatementGenerator generator;
        private ConstantGeneratorStub constantGenerator;
        private IdentifierGeneratorStub identifierGenerator;
        private AssignmentGeneratorStub assignmentGenerator;
        private BlockGeneratorStub blockGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new StatementGenerator();
            this.generator.InjectDependency(this.constantGenerator = new ConstantGeneratorStub());
            this.generator.InjectDependency(this.identifierGenerator = new IdentifierGeneratorStub());
            this.generator.InjectDependency(this.assignmentGenerator = new AssignmentGeneratorStub());
            this.generator.InjectDependency(this.blockGenerator = new BlockGeneratorStub());
        }

        [TestMethod]
        public void TestGenerateConstant()
        {
            this.constantGenerator.Result = "\"foo\"";

            string php = this.generator.Generate(new Constant("foo"));

            Assert.AreEqual("\"foo\"", php);
        }

        [TestMethod]
        public void TestGenerateIdentifier()
        {
            this.identifierGenerator.Result = "$bar";

            string php = this.generator.Generate(new Identifier("bar"));

            Assert.AreEqual("$bar", php);
        }

        [TestMethod]
        public void TestGenerateAssignment()
        {
            this.assignmentGenerator.Result = "$foo = \"bar\"";

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            string php = this.generator.Generate(assignment);

            Assert.AreEqual("$foo = \"bar\"", php);
        }

        [TestMethod]
        public void TestGenerateBlock()
        {
            this.blockGenerator.Result = "$foo = \"bar\";";

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));
            var block = new Block(new []{ assignment });

            string php = this.generator.Generate(block);

            Assert.AreEqual("$foo = \"bar\";", php);
        }

        [TestMethod]
        public void TestGeneratePHPStart()
        {
            string php = this.generator.Generate(new PHPStart());

            Assert.AreEqual("<?php", php);
        }
    }
}
