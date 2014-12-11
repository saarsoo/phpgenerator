using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class StatementGeneratorTest
    {
        private AssignmentGeneratorStub _assignmentGenerator;
        private BlockGeneratorStub _blockGenerator;
        private ConstantGeneratorStub _constantGenerator;
        private StatementGenerator _generator;
        private IdentifierGeneratorStub _identifierGenerator;
        private ArrayGeneratorStub _arrayGenerator;
        private AccessorGeneratorStub _accessorGenerator;
        private MethodCallGeneratorStub _methodCallGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            _generator = new StatementGenerator();
            _generator.InjectDependency(_constantGenerator = new ConstantGeneratorStub());
            _generator.InjectDependency(_identifierGenerator = new IdentifierGeneratorStub());
            _generator.InjectDependency(_assignmentGenerator = new AssignmentGeneratorStub());
            _generator.InjectDependency(_blockGenerator = new BlockGeneratorStub());
            _generator.InjectDependency(_arrayGenerator = new ArrayGeneratorStub());
            _generator.InjectDependency(_accessorGenerator = new AccessorGeneratorStub());
            _generator.InjectDependency(_methodCallGenerator = new MethodCallGeneratorStub());
        }

        [TestMethod]
        public void TestGenerateConstant()
        {
            _constantGenerator.Results = new[] { "\"foo\"" };

            var php = _generator.Generate(new Constant("foo"));

            Assert.AreEqual("\"foo\"", php);
        }

        [TestMethod]
        public void TestGenerateIdentifier()
        {
            _identifierGenerator.Results = new[] { "$bar" };

            var php = _generator.Generate(new Identifier("bar"));

            Assert.AreEqual("$bar", php);
        }

        [TestMethod]
        public void TestGenerateAssignment()
        {
            _assignmentGenerator.Results = new[] { "$foo = \"bar\"" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));

            var php = _generator.Generate(assignment);

            Assert.AreEqual("$foo = \"bar\"", php);
        }

        [TestMethod]
        public void TestGenerateBlock()
        {
            _blockGenerator.Results = new[] { "$foo = \"bar\";" };

            var assignment = new Assignment(new Identifier("foo"), new Constant("bar"));
            var block = new Block(new[] { assignment });

            var php = _generator.Generate(block);

            Assert.AreEqual("$foo = \"bar\";", php);
        }

        [TestMethod]
        public void TestGeneratePhpStart()
        {
            var php = _generator.Generate(new PhpStart());

            Assert.AreEqual("<?php", php);
        }

        [TestMethod]
        public void TestGenerateArray()
        {
            _arrayGenerator.Results = new[] { "array()" };

            var php = _generator.Generate(new ArrayStatement());

            Assert.AreEqual("array()", php);
        }

        [TestMethod]
        public void TestGenerateAccessor()
        {
            _accessorGenerator.Results = new[] { "$foo->bar" };

            var php = _generator.Generate(new Accessor(new Identifier("foo"), AccessorType.Pointer, new Identifier("bar", true)));

            Assert.AreEqual("$foo->bar", php);
        }

        [TestMethod]
        public void TestGenerateMethodCall()
        {
            _methodCallGenerator.Results = new[] { "foobar()" };

            var php = _generator.Generate(new MethodCall("foobar"));

            Assert.AreEqual("foobar()", php);
        }
    }
}