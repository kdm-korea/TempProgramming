using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*  Given an array of positive integers, find the smallest positive integer that cannot be created by adding elements in the array.
 
    정렬된 양수(positive integer) 배열이 주어지면, 배열 원소들의 합으로 만들수 없는 가장 작은 양수를 구하시오.
    단, 시간복잡도는 O(n) 이여야 합니다.

    input: [1, 2, 3, 8]     output: 7
    
    // 1 = 1            // 2 = 2        // 3 = 3
    // 4 = 1 + 3        // 5 = 2 + 3    // 6 = 1 + 2 + 3
    // 7 = 불가능
*/

namespace PositivveIntergerSum
{
    class Program
    {
        static void Main(string[] args) {
            int value = 1;
            int[] input = new int[] { 1, 2, 3, 8 };

            Array.Sort(input);

            while (true) {
                if (!IsExceptValueZero(input, value)) {
                    break;
                }
                value++;
            }
            Console.WriteLine($"Don't make this number {value}");
        }

        private static bool IsExceptValueZero(int[] array, int value) {

            for (int idx = array.Length - 1; idx >= 0; idx--) {
                if (value >= array[idx]) {
                    value -= array[idx];
                }
            }
            return (value == 0) ? true : false;
        }
    }
}
