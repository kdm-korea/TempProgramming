using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderjExample
{
    class Program
    {
        static void Main(string[] args) {

            List<Person> people = new List<Person>();

            Person person = new Person()
                .Address("aaa")
                .Age(12)
                .Name("fds")
                .Build();

            for (int idx = 0; idx < 30; idx++) {
                people.Add(person);
            }
        }

        public static void Example(params object[] str) {
            for (int idx = 0; idx < str.Length; idx++) {
                Console.WriteLine(str[idx]);
            }
        }
    }
}
