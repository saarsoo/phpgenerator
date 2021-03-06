﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class BlockGeneratorTest
    {
        private BlockGenerator _generator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new BlockGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            _statementGenerator.Results = new[] {"$foo = \"bar\""};

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var block = new Block(new[] {assignment});

            var php = _generator.Generate(block);

            Assert.AreEqual("$foo = \"bar\";", php);
        }
    }
}