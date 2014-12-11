using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ClassGeneratorTest
    {
        private ClassGenerator _generator;
        private MemberGeneratorStub _memberGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ClassGenerator();
            _generator.InjectDependency(_memberGenerator = new MemberGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            var php = _generator.Generate(new Class("Foo"));

            Assert.AreEqual("class Foo{}", php);
        }

        [TestMethod]
        public void TestGenerateExtends()
        {
            var php = _generator.Generate(new Class("Foo")
            {
                Extends = "Bar"
            });

            Assert.AreEqual("class Foo extends Bar{}", php);
        }

        [TestMethod]
        public void TestGenerateImplements()
        {
            var php = _generator.Generate(new Class("Foo")
            {
                Implements = new string[]{ "Bar" }
            });

            Assert.AreEqual("class Foo implements Bar{}", php);
        }

        [TestMethod]
        public void TestGenerateProperty()
        {
            _memberGenerator.Results = new[] {"private $bar;"};

            var php = _generator.Generate(new Class("Foo")
            {
                Members = new IMember[] {new Property("bar")}
                
            });

            Assert.AreEqual("class Foo{private $bar;}", php);
        }

        [TestMethod]
        public void TestGenerateMethod()
        {
            _memberGenerator.Results = new[] {"private function bar(){}"};

            var php = _generator.Generate(new Class("Foo")
            {
                Members = new IMember[] {new Method("bar")}
            });

            Assert.AreEqual("class Foo{private function bar(){}}", php);
        }
    }
}