﻿using System;

/*어떤 문장의 각 알파벳을 일정한 거리만큼 밀어서 다른 알파벳으로 바꾸는 암호화 방식을 시저 암호라고 합니다.
 * 예를 들어 AB는 1만큼 밀면 BC가 되고, 3만큼 밀면 DE가 됩니다. 
 * z는 1만큼 밀면 a가 됩니다. 
 * 문자열 s와 거리 n을 입력받아 s를 n만큼 민 암호문을 만드는 함수, solution을 완성해 보세요.
 * 
 * 제한 조건
 * 공백은 아무리 밀어도 공백입니다.
 * s는 알파벳 소문자, 대문자, 공백으로만 이루어져 있습니다.
 * s의 길이는 8000이하입니다.
 * n은 1 이상, 25이하인 자연수입니다.
 * 
 * 입출력 결과
 * "AB", 1    => "BC"
 * "z", 1     => "a"
 * "a B z", 4 => "e F d"
*/
namespace ASCIIDecryption
{
    class Program
    {
        public static readonly int a = 65;
        public static readonly int z = 90;
        public static readonly int A = 97;
        public static readonly int Z = 122;

        static void Main(string[] args) {
            Console.WriteLine(Solution("z", 1).ToString());
        }

        private static string Solution(string s, int n) {
            string answer = string.Empty;
            int[] ascii = new int[s.Length];

            for (int idx = 0; idx < s.Length; idx++) {
                ascii[idx] = Convert.ToInt32(s[idx]);

                if (ascii[idx] >= a && ascii[idx] <= z) {
                    ascii[idx] = ascii[idx] + n;

                    if (ascii[idx] > z) {
                        ascii[idx] = (ascii[idx] % z) + a - 1;
                    }
                }
                else if (ascii[idx] >= A && ascii[idx] <= Z) {
                    ascii[idx] = ascii[idx] + n;

                    if (ascii[idx] > Z) {
                        ascii[idx] = (ascii[idx] % Z) + A - 1;
                    }
                }
                else { }

                answer += (char)ascii[idx];
            }
            return answer;
        }
    }
}
