using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class IdentifierGeneratorTest
    {
        private IdentifierGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new IdentifierGenerator();
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Identifier("foo"));

            Assert.AreEqual("$foo", php);
        }
    }
}
