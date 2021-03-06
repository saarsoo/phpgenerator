﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class MethodCallGeneratorTest
    {
        private MethodCallGenerator _generator;
        private StatementGeneratorStub _statementGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new MethodCallGenerator();
            _generator.InjectDependency(_statementGenerator = new StatementGeneratorStub());
        }

        [TestMethod]
        public void TestGenerateEmptyMethod()
        {
            _statementGenerator.Results = new[] { "foo" };

            var php = _generator.Generate(new MethodCall("foo"));

            Assert.AreEqual("foo()", php);
        }

        [TestMethod]
        public void TestGenerateWithArgument()
        {
            _statementGenerator.Results = new[] { "foo", "\"bar\"" };

            var php = _generator.Generate(new MethodCall("foo")
            {
                Arguments = new IStatement[] { new Constant("bar") }
            });

            Assert.AreEqual("foo(\"bar\")", php);
        }

        [TestMethod]
        public void TestGenerateWithArguments()
        {
            _statementGenerator.Results = new[] { "foobus", "$foo", "\"bar\"" };

            var php = _generator.Generate(new MethodCall("foobus")
            {
                Arguments = new IStatement[] { new Identifier("foo"), new Constant("bar") }
            });

            Assert.AreEqual("foobus($foo,\"bar\")", php);
        }
    }
}