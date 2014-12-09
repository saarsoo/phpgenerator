using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ConditionalOperatorGeneratorTest
    {
        private ConditionalOperatorGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ConditionalOperatorGenerator();
        }

        [TestMethod]
        public void TestGenerateAnd()
        {
            Assert.AreEqual("&&", _generator.Generate(ConditionalOperator.And));
        }

        [TestMethod]
        public void TestGenerateOr()
        {
            Assert.AreEqual("||", _generator.Generate(ConditionalOperator.Or));
        }

        [TestMethod]
        public void TestGenerateEqual()
        {
            Assert.AreEqual("==", _generator.Generate(ConditionalOperator.Equal));
        }

        [TestMethod]
        public void TestGenerateNotEqual()
        {
            Assert.AreEqual("!=", _generator.Generate(ConditionalOperator.NotEqual));
        }
    }
}
