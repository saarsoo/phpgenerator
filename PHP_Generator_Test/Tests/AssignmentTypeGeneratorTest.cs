using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class AssignmentTypeGeneratorTest
    {
        private AssignmentTypeGenerator _generator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new AssignmentTypeGenerator();
        }

        [TestMethod]
        public void TestGenerateSet()
        {
            Assert.AreEqual("=", _generator.Generate(AssignmentType.Set));
        }

        [TestMethod]
        public void TestGenerateAppendString()
        {
            Assert.AreEqual(".=", _generator.Generate(AssignmentType.AppendString));
        }

        [TestMethod]
        public void TestGenerateAddition()
        {
            Assert.AreEqual("+=", _generator.Generate(AssignmentType.Addition));
        }

        [TestMethod]
        public void TestGenerateSubtraction()
        {
            Assert.AreEqual("-=", _generator.Generate(AssignmentType.Subtraction));
        }
    }
}
