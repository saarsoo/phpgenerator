using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PHP_Generator;
using System.Collections.Generic;
using System.Linq;

namespace PHP_Generator_Test.Tests
{
    [TestClass]
    public class FileGeneratorTest
    {
        private FileGenerator generator;
        private ReferenceGeneratorStub referenceGenerator;
        private ClassGeneratorStub classGenerator;

        [TestInitialize]
        public void TestInitialize()
        {
            this.generator = new FileGenerator();
            this.generator.InjectDependency(this.referenceGenerator = new ReferenceGeneratorStub());
            this.generator.InjectDependency(this.classGenerator = new ClassGeneratorStub());
        }

        [TestMethod]
        public void TestGenerate()
        {
            string php = this.generator.Generate(new File());

            Assert.AreEqual("<?php ", php);
        }

        [TestMethod]
        public void TestGenerateNamespace()
        {
            string php = this.generator.Generate(new File(@"foo\bar"));

            Assert.AreEqual(@"<?php namespace foo\bar;", php);
        }

        [TestMethod]
        public void TestGenerateReferences()
        {
            this.referenceGenerator.Results = new[] { @"use foo\bar;", @"use bar\foo;" };

            string php = this.generator.Generate(new File(new[] { new Reference(@"foo\bar"), new Reference(@"bar\foo") }));

            Assert.AreEqual(@"<?php use foo\bar;use bar\foo;", php);
        }

        [TestMethod]
        public void TestGenerateClass()
        {
            this.classGenerator.Results = new []{ "class foo{}" };

            string php = this.generator.Generate(new File(new[] { new Class("Foo") }));

            Assert.AreEqual("<?php class foo{}", php);
        }

        [TestMethod]
        public void TestGenerateFullFile()
        {
            this.generator = this.Resolve<FileGenerator>();

            var references = new[] { new Reference(@"first\reference"), new Reference(@"second\reference") };
            var assignment = new Assignment(new Identifier("localName"), new Constant("value"));
            var block = new Block(new[] { assignment });
            var method = new Method("methodName", block);
            var @class = new Class("className", new[] { method });

            File file = new File(@"name\space", references, new[] { @class });

            string php = this.generator.Generate(file);

            Assert.AreEqual("<?php namespace name\\space;use first\\reference;use second\\reference;class className{private function methodName(){$localName=\"value\";}}", php);
        }

        private T Resolve<T>()
        {
            return (T)this.Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            string typeName = type.Name;

            if (type.IsInterface)
            {
                typeName = typeName.Substring(1);
            }

            type = Type.GetType(String.Format("PHP_Generator.{0}, PHP_Generator", typeName));

            if (instances.ContainsKey(type))
            {
                return instances[type];
            }

            object instance = Activator.CreateInstance(type);
            this.instances.Add(type, instance);

            var methods = type.GetMethods().Where(m => m.Name == "InjectDependency");

            foreach (var method in methods)
            {
                var parameter = method.GetParameters().First();

                method.Invoke(instance, new[] { this.Resolve(parameter.ParameterType) });
            }

            return instance;
        }

        private Dictionary<Type, object> instances = new Dictionary<Type, object>();
    }
}
