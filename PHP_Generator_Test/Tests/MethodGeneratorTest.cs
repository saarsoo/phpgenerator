using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class MethodGeneratorTest
    {
        private MethodGenerator generator;
        private ModifierGeneratorStub modifierGenerator;
        private ParameterGeneratorStub parameterGenerator;
        private StatementGeneratorStub statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new MethodGenerator();
            this.generator.InjectDependency(this.modifierGenerator = new ModifierGeneratorStub());
            this.generator.InjectDependency(this.parameterGenerator = new ParameterGeneratorStub());
            this.generator.InjectDependency(this.statementGenerator = new StatementGeneratorStub());

            this.modifierGenerator.Results = new []{ "private" };
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Method("foo"));

            Assert.AreEqual("private function foo(){}", php);
        }

        [TestMethod]
        public void TestGenerateParameter()
        {
            this.parameterGenerator.Results = new []{ "$bar" };

            string php = this.generator.Generate(new Method("foo", new[] { new Parameter("bar") }));

            Assert.AreEqual("private function foo($bar){}", php);
        }

        [TestMethod]
        public void TestGenerateBody()
        {
            this.statementGenerator.Results = new []{ "$foo=\"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            string php = this.generator.Generate(new Method("foo", assignment));

            Assert.AreEqual("private function foo(){$foo=\"bar\";}", php);
        }

        [TestMethod]
        public void TestGenerateBlockBody()
        {
            this.statementGenerator.Results = new []{ "$foo=\"bar\";" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));
            var block = new Block(new[] { assignment });

            string php = this.generator.Generate(new Method("foo", block));

            Assert.AreEqual("private function foo(){$foo=\"bar\";}", php);
        }
    }
}
