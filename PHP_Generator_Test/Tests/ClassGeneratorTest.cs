using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ClassGeneratorTest
    {
        private ClassGenerator generator;
        private PropertyGeneratorStub propertyGenerator;
        private MethodGeneratorStub methodGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new ClassGenerator();
            this.generator.InjectDependency(this.propertyGenerator = new PropertyGeneratorStub());
            this.generator.InjectDependency(this.methodGenerator = new MethodGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new Class("Foo"));

            Assert.AreEqual("class Foo{}", php);
        }

        [TestMethod]
        public void TestGenerateExtends()
        {
            string php = this.generator.Generate(new Class("Foo", "Bar"));

            Assert.AreEqual("class Foo extends Bar{}", php);
        }

        [TestMethod]
        public void TestGenerateImplements()
        {
            string php = this.generator.Generate(new Class("Foo", new string[] { "Bar" }));

            Assert.AreEqual("class Foo implements Bar{}", php);
        }

        [TestMethod]
        public void TestGenerateProperty()
        {
            this.propertyGenerator.Result = "private $bar;";

            string php = this.generator.Generate(new Class("Foo", new[] { new Property("bar") }));

            Assert.AreEqual("class Foo{private $bar;}", php);
        }

        [TestMethod]
        public void TestGenerateMethod()
        {
            this.methodGenerator.Result = "private function bar(){}";

            string php = this.generator.Generate(new Class("Foo", new[] { new Method("bar") }));

            Assert.AreEqual("class Foo{private function bar(){}}", php);
        }
    }
}
