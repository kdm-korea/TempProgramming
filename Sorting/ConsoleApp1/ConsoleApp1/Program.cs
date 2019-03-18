using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) {
            int[] num = new int[] { 123, 10, 2 };
            //Console.WriteLine(num.Length);  //3
            solution(num);
        }

        private static string solution(int[] numbers) {
            List<char> array = new List<char>();
            string answer = "";

            for (int idx = 0; idx < numbers.Length; idx++) {
                for (int i = 0; i < numbers[idx].ToString().Length; i++) {
                    array.Add(numbers[idx].ToString()[i]);
                }
            }

            array.Sort();
            array.Reverse();

            for (int idx = 0; idx < array.Count; idx++) {
                answer += array[idx];
            }
            Console.WriteLine(answer);
            return answer;
        }
    }
}
