using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class FileGeneratorTest
    {
        private FileGenerator generator;
        private ReferenceGeneratorStub referenceGenerator;
        private ClassGeneratorStub classGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new FileGenerator();
            this.generator.InjectDependency(this.referenceGenerator = new ReferenceGeneratorStub());
            this.generator.InjectDependency(this.classGenerator = new ClassGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new File());

            Assert.AreEqual("<?php ", php);
        }

        [TestMethod]
        public void TestGenerateNamespace()
        {
            string php = this.generator.Generate(new File(@"foo\bar"));

            Assert.AreEqual(@"<?php namespace foo\bar;", php);
        }

        [TestMethod]
        public void TestGenerateReferences()
        {
            this.referenceGenerator.Result = @"use foo\bar;";

            string php = this.generator.Generate(new File(new []{new Reference(@"foo\bar")}));

            Assert.AreEqual(@"<?php use foo\bar;", php);
        }

        [TestMethod]
        public void TestGenerateClass()
        {
            this.classGenerator.Result = "class foo{}";

            string php = this.generator.Generate(new File(new []{new Class("Foo")}));

            Assert.AreEqual("<?php class foo{}", php);
        }
    }
}
