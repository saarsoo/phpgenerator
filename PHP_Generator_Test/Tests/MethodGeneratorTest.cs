using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class MethodGeneratorTest
    {
        private MethodGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new MethodGenerator();
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Method("foo"));

            Assert.AreEqual("function foo(){}", php);
        }

        [TestMethod]
        public void TestGenerateParameter()
        {
        }
    }
}
