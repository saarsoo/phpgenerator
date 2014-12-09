using System;
using System.Collections.Generic;
using PHP_Generator.Structures;

namespace PHP_Generator.Generators
{
    public class ArrayGenerator : IArrayGenerator, IDependency<IStatementGenerator>
    {
        private IStatementGenerator _statementGenerator;

        public string Generate(ArrayStatement array)
        {
            var values = new List<string>();

            foreach (var valuePair in array.Values)
            {
                var value = "";

                if (!(valuePair.Key is EmptyStatement))
                {
                    value += _statementGenerator.Generate(valuePair.Key) + "=>";
                }

                value += _statementGenerator.Generate(valuePair.Value);

                values.Add(value);
            }

            return String.Format("array({0})", String.Join(",", values));
        }

        public void InjectDependency(IStatementGenerator dependency)
        {
            _statementGenerator = dependency;
        }
    }
}