using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Generator_Test
{
    abstract class GeneratorStub<T>
    {
        public string[] Results { get; set; }
        private int index = 0;

        public string Generate(T obj){
            return this.Results[index++];
        }
    }
}
