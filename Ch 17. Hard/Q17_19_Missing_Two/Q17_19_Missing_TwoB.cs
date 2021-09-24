using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_19_Missing_Two
{
    // 第一部份: 找出少掉的數字
    // 使用相加的方式，可以大幅漸慢溢位的時間，但數字太大還是會發生
    public class Q17_19_Missing_TwoB : Question
    {
        public static int MissingOneB(int[] array)
        {
            int max_value = array.Length + 1;
            int remainder = max_value * (max_value + 1) / 2;

            for (int i = 0; i < array.Length; i++)
            {
                remainder -= array[i];
            }
            return remainder;
        }

        public override void Run()
        {
            int max = 100;
            int x = 8;
            int len = max - 1;
            int count = 0;
            int[] array = new int[len];
            for (int i = 1; i <= max; i++)
            {
                if (i != x)
                {
                    array[count] = i;
                    count++;
                }
            }
            Console.WriteLine(x);
            int solution = MissingOneB(array);

            Console.WriteLine(solution);
        }
    }
}
