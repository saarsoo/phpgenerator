using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ArithmeticOperatorGeneratorTest
    {
        private ArithmeticOperatorGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ArithmeticOperatorGenerator();
        }

        [TestMethod]
        public void TestGenerateAddition()
        {
            Assert.AreEqual("+", _generator.Generate(ArithmeticOperator.Addition));
        }

        [TestMethod]
        public void TestGenerateSubtraction()
        {
            Assert.AreEqual("-", _generator.Generate(ArithmeticOperator.Subtraction));
        }

        [TestMethod]
        public void TestGenerateMultiplication()
        {
            Assert.AreEqual("*", _generator.Generate(ArithmeticOperator.Multiplication));
        }

        [TestMethod]
        public void TestGenerateDivision()
        {
            Assert.AreEqual("/", _generator.Generate(ArithmeticOperator.Division));
        }
    }
}
