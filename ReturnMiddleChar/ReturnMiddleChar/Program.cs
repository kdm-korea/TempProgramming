using System;
/* 단어 s의 가운데 글자를 반환하는 함수, solution을 만들어 보세요. 
 * 단어의 길이가 짝수라면 가운데 두글자를 반환하면 됩니다.
 * 
 * 제한사항
 * s는 길이가 1 이상, 100이하인 스트링입니다.
 * 
 * 입출력 예
 * "abcde" => c
 * "qwer" => we
 */

namespace ReturnMiddleChar
{
    class Program
    {
        static void Main(string[] args) {
            Console.WriteLine(Solution("abcde"));
            Console.WriteLine(Solution("qwer"));
        }

        private static string Solution(string s) {
            string val = String.Empty;

            if (s.Length % 2 != 1) {
                val += s[s.Length / 2 - 1].ToString();
            }
            val += s[(s.Length / 2)].ToString();
            return val;
        }
    }
}
