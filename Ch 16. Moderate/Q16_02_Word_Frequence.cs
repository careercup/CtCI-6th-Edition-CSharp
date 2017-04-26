using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter16
{
    public class Q16_02_Word_Frequence : Question
    {
        public override void Run()
        {
            var book = AssortedMethods.GetLongTextBlob();
            var wordFrequence = GetWordFrequency(book);
            Console.WriteLine("Word\t\t Frequence");
            foreach (var word in wordFrequence.Keys)
                Console.WriteLine($"Word :{word}\t Count:{wordFrequence[word]}");
        }

        public IDictionary<string, int> GetWordFrequency(string book)
        {
            var words = book.ToLower().Split(' ');
            var dict = new Dictionary<string, int>();
            foreach (var word in words)
                if (dict.ContainsKey(word))
                    dict[word]++;
                else
                    dict[word] = 1;
            return dict;
        }
    }
}
