using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_StringCompress
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "aaabbcccdde";
            string result = Compress(str);
            Console.WriteLine(result);
            result = Decompress(result);
            Console.WriteLine("\n" + result);
        }

        public static string Compress(string inputStr)
        {
            StringBuilder newStr = new StringBuilder();
            short repeatCount = 1;
            char lastChr = default(char);
            foreach (char c in inputStr)
            {
                if (c == lastChr)
                {
                    repeatCount++;
                }
                else
                {
                    if (repeatCount > 1)
                    {
                        newStr.Append(repeatCount);
                        repeatCount = 1;
                    }
                    newStr.Append(c);
                    lastChr = c;
                }
            }
            return newStr.ToString();
        }

        public static string Decompress(string inputStr)
        {
            StringBuilder newStr = new StringBuilder();
            int i = 0;
            int n = inputStr.Length;

            while (i < n)
            {
                char currentChar = inputStr[i];

                if (i + 1 < n && char.IsDigit(inputStr[i + 1]))
                {
                    int repeat = 0;
                    int j = i + 1;

                    while (j < n && char.IsDigit(inputStr[j]))
                    {
                        repeat = repeat * 10 + (inputStr[j] - '0');
                        j++;
                    }

                    newStr.Append(currentChar, repeat);
                    i = j;
                }
                else
                {
                    newStr.Append(currentChar);
                    i++;
                }
            }

            return newStr.ToString();
        }

    }
}
