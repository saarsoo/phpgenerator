using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class AccessorGeneratorTest
    {
        private AccessorGenerator _generator;
        private AccessorTypeGeneratorStub _accessorTypeGenerator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new AccessorGenerator();
            _generator.InjectDependency(_accessorTypeGenerator = new AccessorTypeGeneratorStub());
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] { "$foo", "bar" };
            _accessorTypeGenerator.Results = new[] { "->" };

            var php = _generator.Generate(new Accessor(new Identifier("foo"), AccessorType.Pointer, new Identifier("bar", true)));

            Assert.AreEqual("$foo->bar", php);
        }

        [TestMethod]
        public void TestGenerateIndex()
        {
            _statementGenerator.Results = new[] { "$this", "\"is sparta!\"" };

            var php = _generator.Generate(new Accessor(new Identifier("this"), AccessorType.Index, new Constant("is sparta!")));

            Assert.AreEqual("$this[\"is sparta!\"]", php);
        }
    }
}
