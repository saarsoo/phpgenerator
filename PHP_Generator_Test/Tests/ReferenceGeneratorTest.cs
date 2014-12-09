using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ReferenceGeneratorTest
    {
        private ReferenceGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ReferenceGenerator();
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Reference(@"foo\bar"));

            Assert.AreEqual(@"use foo\bar;", php);
        }
    }
}