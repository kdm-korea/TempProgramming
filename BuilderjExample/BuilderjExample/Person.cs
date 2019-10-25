using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderjExample
{
    class Person
    {
        private string name;
        private int age;
        private string address;

        public Person() {}

        public Person Name(string name) {
            this.name = name;
            return this;
        }

        public Person Age(int age) {
            this.age = age;
            return this;
        }

        public Person Address(string address) {
            this.address = address;
            return this;
        }

        public Person Build() {
            return this;
        }
    }
}
