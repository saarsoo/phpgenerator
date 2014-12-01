using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test
{
    [TestClass]
    public class IdentifierGeneratorTest
    {
        private IdentifierGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new IdentifierGenerator();
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Identifier("foo"));

            Assert.AreEqual("$foo", php);
        }
    }
}
