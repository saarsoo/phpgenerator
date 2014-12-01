using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ModifierGeneratorTest
    {
        private ModifierGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new ModifierGenerator();
        }

        [TestMethod]
        public void TestGeneratePublic()
        {
            string php = this.generator.Generate(Modifier.Public);

            Assert.AreEqual("public", php);
        }

        [TestMethod]
        public void TestGenerateProtected()
        {
            string php = this.generator.Generate(Modifier.Protected);

            Assert.AreEqual("protected", php);
        }

        [TestMethod]
        public void TestGeneratePrivate()
        {
            string php = this.generator.Generate(Modifier.Private);

            Assert.AreEqual("private", php);
        }
    }
}
