using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ModifierGeneratorTest
    {
        private ModifierGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ModifierGenerator();
        }

        [TestMethod]
        public void TestGeneratePublic()
        {
            var php = _generator.Generate(Modifier.Public);

            Assert.AreEqual("public", php);
        }

        [TestMethod]
        public void TestGenerateProtected()
        {
            var php = _generator.Generate(Modifier.Protected);

            Assert.AreEqual("protected", php);
        }

        [TestMethod]
        public void TestGeneratePrivate()
        {
            var php = _generator.Generate(Modifier.Private);

            Assert.AreEqual("private", php);
        }
    }
}
