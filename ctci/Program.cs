using Chapter01;
using Chapter02;
using Chapter05;
using ctci.Contracts;
using Introduction;
using System;

namespace ctci
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chapters = new[]
            {
                // Intro
                new IQuestion[] { new CompareBinaryToHex(), new SwapMinMax(), },

                // Chapters
                new IQuestion[] { new Q1_01_Is_Unique(),  new Q1_02_Check_Permutation(), new Q1_03_URLify(), new Q1_04_Palindrome_Permutation(), new Q1_05_One_Away_A(), new Q1_06_String_Compression(), new Q1_07_Rotate_Matrix(), new Q1_08_Zero_Matrix(), new Q1_09_String_Rotation(),},

                new IQuestion[] { new Q2_01_Remove_Dups(), new Q2_02_Return_Kth_To_Last(), new Q2_03_Delete_Middle_Node(), new Q2_04_Partition(), new Q2_05_Sum_Lists(), new Q2_06_Palindrome(), new Q2_07_Intersection(), new Q2_08_Loop_Detection() },

                new IQuestion[] { new Q5_01_Insertion(), new Q5_02_Binary_to_String(), new Q5_04_Next_Number(), new Q5_06_Conversion(), new Q5_06_Conversion(), new Q5_07_Pairwise_Swap(), new Q5_08_Draw_Line() },
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