using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test
{
    [TestClass]
    public class ConstantGeneratorTest
    {
        public ConstantGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new ConstantGenerator();
        }

        [TestMethod]
        public void TestGenerateString()
        {
            string php = this.generator.Generate(new Constant("foo"));

            Assert.AreEqual("\"foo\"", php);
        }

        [TestMethod]
        public void TestGenerateStringWithQoutes()
        {
            string php = this.generator.Generate(new Constant("foo + \"bar\""));

            Assert.AreEqual("\"foo + \\\"bar\\\"\"", php);
        }

        [TestMethod]
        public void TestGenerateInt()
        {
            string php = this.generator.Generate(new Constant(1));

            Assert.AreEqual("1", php);
        }

        [TestMethod]
        public void TestGenerateFloat()
        {
            string php = this.generator.Generate(new Constant(1.2));

            Assert.AreEqual("1.2", php);
        }

        [TestMethod]
        public void TestGenerateBool()
        {
            string php = this.generator.Generate(new Constant(true));

            Assert.AreEqual("true", php);
        }

        [TestMethod]
        public void TestGenerateNull()
        {
            string php = this.generator.Generate(new Constant(null));

            Assert.AreEqual("null", php);
        }
    }
}
