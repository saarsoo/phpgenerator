using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ReferenceGeneratorTest
    {
        private ReferenceGenerator generator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new ReferenceGenerator();
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Reference(@"foo\bar"));

            Assert.AreEqual(@"use foo\bar;", php);
        }
    }
}
