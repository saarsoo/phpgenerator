using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class MemberGeneratorTest
    {
        private MemberGenerator _generator;
        private MethodGeneratorStub _methodGenerator;
        private PropertyGeneratorStub _propertyGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new MemberGenerator();
            _generator.InjectDependency(_methodGenerator = new MethodGeneratorStub());
            _generator.InjectDependency(_propertyGenerator = new PropertyGeneratorStub());
        }

        [TestMethod]
        public void TestGenerateProperty()
        {
            _propertyGenerator.Results = new[] {"private $foo;"};

            var php = _generator.Generate(new Property("foo"));

            Assert.AreEqual("private $foo;", php);
        }

        [TestMethod]
        public void TestGenerateMethod()
        {
            _methodGenerator.Results = new[] {"private function bar(){}"};

            var php = _generator.Generate(new Method("bar"));

            Assert.AreEqual("private function bar(){}", php);
        }
    }
}