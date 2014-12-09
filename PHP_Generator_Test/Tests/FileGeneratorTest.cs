using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator.Generators;
using PHP_Generator.Structures;
using PHP_Generator_Test.Stubs;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class FileGeneratorTest
    {
        private FileGenerator _generator;
        private ReferenceGeneratorStub _referenceGenerator;
        private ClassGeneratorStub _classGenerator;

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
            _generator = Resolve<FileGenerator>();

            var references = new[] { new Reference(@"first\reference"), new Reference(@"second\reference") };
            var assignment = new Assignment(new Identifier("localName"), new Constant("value"));
            var block = new Block(new[] { assignment });
            var method = new Method("methodName", block);
            var property = new Property("propertyName");
            var @class = new Class("className", new IMember[] { property, method });

            var file = new File(@"name\space", references, new[] { @class });

            var php = _generator.Generate(file);

            Assert.AreEqual("<?php namespace name\\space;use first\\reference;use second\\reference;class className{private $propertyName;private function methodName(){$localName=\"value\";}}", php);
        }

        private T Resolve<T>()
        {
            if (_types == null)
            {
                InitializeTypes<T>();
            }

            return (T)Resolve(typeof(T));
        }

        private void InitializeTypes<T>()
        {
            var assembly = Assembly.Load(new AssemblyName("PHP_Generator"));
            _types = assembly.GetTypes();
        }

        private object Resolve(Type type)
        {
            var typeName = type.Name;

            if (type.IsInterface)
            {
                typeName = typeName.Substring(1);
            }

            type = _types.FirstOrDefault(t => t.Name == typeName);

            if (type == null)
            {
                throw new Exception(String.Format("Could not resolve type {0}", typeName));
            }

            if (_instances.ContainsKey(type))
            {
                return _instances[type];
            }

            var instance = Activator.CreateInstance(type);
            _instances.Add(type, instance);

            var methods = type.GetMethods().Where(m => m.Name == "InjectDependency");

            foreach (var method in methods)
            {
                var parameter = method.GetParameters().First();

                method.Invoke(instance, new[] { Resolve(parameter.ParameterType) });
            }

            return instance;
        }

        private Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        private Type[] _types;
    }
}
