using System;
using System.Collections.Generic;

namespace Trucks
{
    class Program
    {
        static void Main(string[] args) {
            Solution result = new Solution();
            int bridege_length = 2;
            int weight = 10;
            int[] truck_weights = new int[] { 7, 4, 5, 6 };

            Console.WriteLine(result.solution(bridege_length, weight, truck_weights));
        }
    }
}
