using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter16
{
    public class Q16_08_English_Int : Question
    {
        public override void Run()
        {
            var value = 832787436;
            var engInt = ConvertIntToEnglish(value);
            Console.WriteLine($"{832787436} in English is \n{engInt}");
        }

        public string ConvertIntToEnglish(int number)
        {
            var smalls = new string[] {"Zero", "One","Two","Three","Four","Five","Six","Seven","Eight","Nine", "Ten", "Eleven","Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
            var bigs = new string[] {"","Thousand","Million","Billion" };
            var hundred = "Hundred";
            var negative = "Negative ";

            if (number == 0) return smalls[0];
            if (number < 0) return negative + ConvertIntToEnglish(number * -1);

            var parts = new List<string>();
            int chunkCount = 0;
            while (number > 0)
            {
                if (number % 1000 != 0)
                {
                    var chunk = ConvertChunk(number % 1000) + " " + bigs[chunkCount];
                    parts.Insert(0, chunk);
                }
                number /= 1000;
                chunkCount++;
            }

            return ListToString(parts);

            string ConvertChunk(int num)
            {
                var smallParts = new List<string>();
                if (num >= 100)
                {
                    smallParts.Add(smalls[num / 100]);
                    smallParts.Add(hundred);
                    num %= 100;
                }

                if (num >= 10 && num <=19)
                {
                    smallParts.Add(smalls[num]);
                }
                else if (num >= 20)
                {
                    smallParts.Add(tens[num / 10]);
                    num %= 10;
                }

                // Convert one place
                if (num >=1 && num <=9)
                {
                    smallParts.Add(smalls[num]);
                }

                return ListToString(smallParts);
            }

            string ListToString(List<string> smallParts)
            {
                var sb = new StringBuilder();
                while(smallParts.Count > 1)
                {
                    var item = smallParts[0];
                    sb.Append(item);
                    sb.Append(" ");
                    smallParts.Remove(item);
                }
                sb.Append(smallParts[0]);
                return sb.ToString();
            }
        }


    }
}
