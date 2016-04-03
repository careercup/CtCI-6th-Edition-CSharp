
using ctci.Contracts;
using Chapter01;
using Introduction;
using System;

namespace ctci
{
    class Program
    {
        static void Main(string[] args)
        {
            var chapters = new[]
            {
                // Intro
                new IQuestion[] { new CompareBinaryToHex(), new SwapMinMax(), },

                // Chapters
                new IQuestion[] { new Q1_01_Is_Unique(),  new Q1_02_Check_Permutation(), new Q1_03_URLify(), new Q1_04_Palindrome_Permutation(), new Q1_05_One_Away_A(), new Q1_06_String_Compression(), new Q1_07_Rotate_Matrix(), new Q1_08_Zero_Matrix(), new Q1_09_String_Rotation(),},
              
            };

            foreach (var chapter in chapters)
            {
                foreach (IQuestion q in chapter)
                {
                    Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
                    Console.WriteLine(string.Format("// Executing: {0}", q.GetType().ToString()));
                    Console.WriteLine("// ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ----");

                    q.Run();
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter to continue..");
                Console.ReadLine();
            }

            Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
            Console.WriteLine("Press [Enter] to quit");
            Console.ReadLine();
        }
    }
}