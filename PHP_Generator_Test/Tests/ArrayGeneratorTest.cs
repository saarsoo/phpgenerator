using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class ArrayGeneratorTest
    {
        private ArrayGenerator _generator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new ArrayGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerateEmpty()
        {
            var php = _generator.Generate(new ArrayStatement(new Dictionary<IStatement, IStatement>()));

            Assert.AreEqual("array()", php);
        }

        [TestMethod]
        public void TestGenerateSingle()
        {
            _statementGenerator.Results = new[] {"\"foo\"", "\"bar\""};

            var php = _generator.Generate(new ArrayStatement(new Dictionary<IStatement, IStatement>
            {
                {new Constant("foo"), new Constant("bar")}
            }));

            Assert.AreEqual("array(\"foo\"=>\"bar\")", php);
        }

        [TestMethod]
        public void TestGenerateMultiple()
        {
            _statementGenerator.Results = new[] {"\"foo\"", "65", "$bar=\"foobus\""};

            var php = _generator.Generate(new ArrayStatement(new Dictionary<IStatement, IStatement>
            {
                {new EmptyStatement(), new Constant("foo")},
                {new Constant(65), new Assignment(new Identifier("bar"), new Constant("foobus"))}
            }));

            Assert.AreEqual("array(\"foo\",65=>$bar=\"foobus\")", php);
        }
    }
}