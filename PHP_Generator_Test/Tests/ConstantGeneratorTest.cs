using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ConstantGeneratorTest
    {
        public ConstantGenerator Generator;

        [TestInitialize]
        public void TestInitialize()
        {
            Generator = new ConstantGenerator();
        }

        [TestMethod]
        public void TestGenerateString()
        {
            var php = Generator.Generate(new Constant("foo"));

            Assert.AreEqual("\"foo\"", php);
        }

        [TestMethod]
        public void TestGenerateStringWithQoutes()
        {
            var php = Generator.Generate(new Constant("foo + \"bar\""));

            Assert.AreEqual("\"foo + \\\"bar\\\"\"", php);
        }

        [TestMethod]
        public void TestGenerateInt()
        {
            var php = Generator.Generate(new Constant(1));

            Assert.AreEqual("1", php);
        }

        [TestMethod]
        public void TestGenerateFloat()
        {
            var php = Generator.Generate(new Constant(1.2));

            Assert.AreEqual("1.2", php);
        }

        [TestMethod]
        public void TestGenerateBool()
        {
            var php = Generator.Generate(new Constant(true));

            Assert.AreEqual("true", php);
        }

        [TestMethod]
        public void TestGenerateNull()
        {
            var php = Generator.Generate(new Constant(null));

            Assert.AreEqual("null", php);
        }
    }
}
