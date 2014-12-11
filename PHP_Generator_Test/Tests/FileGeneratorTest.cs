using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class FileGeneratorTest
    {
        private ClassGeneratorStub _classGenerator;
        private FileGenerator _generator;
        private ReferenceGeneratorStub _referenceGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new FileGenerator();
            _generator.InjectDependency(_referenceGenerator = new ReferenceGeneratorStub());
            _generator.InjectDependency(_classGenerator = new ClassGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new File());

            Assert.AreEqual("<?php ", php);
        }

        [TestMethod]
        public void TestGenerateNamespace()
        {
            var php = _generator.Generate(new File(@"foo\bar"));

            Assert.AreEqual(@"<?php namespace foo\bar;", php);
        }

        [TestMethod]
        public void TestGenerateReferences()
        {
            _referenceGenerator.Results = new[] { @"use foo\bar;", @"use bar\foo;" };

            var php = _generator.Generate(new File(new[] { new Reference(@"foo\bar"), new Reference(@"bar\foo") }));

            Assert.AreEqual(@"<?php use foo\bar;use bar\foo;", php);
        }

        [TestMethod]
        public void TestGenerateClass()
        {
            _classGenerator.Results = new[] { "class foo{}" };

            var php = _generator.Generate(new File(new[] { new Class("Foo") }));

            Assert.AreEqual("<?php class foo{}", php);
        }

        [TestMethod]
        public void TestGenerateFullFile()
        {
            _generator = FileGenerator.CreateGenerator();

            var references = new[] { new Reference(@"first\reference"), new Reference(@"second\reference") };
            var assignment = new Assignment(new Identifier("localName"), new Constant("value"));
            var block = new Block(new IStatement[] { assignment });
            var method = new Method("methodName", block);
            var property = new Property("propertyName");
            var @class = new Class("className", new IMember[] { property, method });

            var file = new File(@"name\space", references, new[] { @class });

            var php = _generator.Generate(file);

            Assert.AreEqual(
                "<?php namespace name\\space;use first\\reference;use second\\reference;class className{private $propertyName;private function methodName(){$localName=\"value\";}}",
                php);
        }
    }
}