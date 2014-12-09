using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class AccessorTypeGeneratorTest
    {
        private AccessorTypeGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new AccessorTypeGenerator();
        }

        [TestMethod]
        public void TestGeneratePointer()
        {
            Assert.AreEqual("->", _generator.Generate(AccessorType.Pointer));
        }

        [TestMethod]
        public void TestGenerateStatic()
        {
            Assert.AreEqual("::", _generator.Generate(AccessorType.Static));
        }
    }
}
