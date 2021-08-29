using Ch_03._Stacks_and_Queues.Q3_01_Three_in_One;
using Ch_03._Stacks_and_Queues.Q3_02_Stack_Min;
using Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates;
using Ch_03._Stacks_and_Queues.Q3_04_Queue_via_Stacks;
using Ch_03._Stacks_and_Queues.Q3_05_Sort_Stack;
using Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter;
using Ch_04._Trees.Q4_01_Route_Between_Nodes;
using Ch_04._Trees.Q4_07_Build_Order.DFSB;
using Ch_04._Trees.Q4_07_Build_Order.EdgeRemovalA;
using Ch_04._Trees.Q4_11_Random_Node;
using Ch_04._Trees.Q4_12_Paths_with_Sum;
using Chapter01;
using Chapter02;
using Chapter04;
using Chapter05;
using Chapter05.Q5_03_Flip_Bit_to_Win;
using Chapter10;
using Chapter16;
using ctci.Contracts;
using Introduction;
using System;

namespace ctci
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var chapters = new[]
            {
                // Intro
                new Question[] { new CompareBinaryToHex(), new SwapMinMax(), },

                // Chapters
                new Question[] {
                    new Q1_01_Is_Unique(),
                    new Q1_02_Check_Permutation(),
                    new Q1_03_URLify(),
                    new Q1_04_Palindrome_Permutation(),
                    new Q1_05_One_Away_A(),
                    new Q1_06_String_Compression(),
                    new Q1_07_Rotate_Matrix(),
                    new Q1_08_Zero_Matrix(),
                    new Q1_09_String_Rotation(),
                },

                new Question[] {
                    new Q2_01_Remove_Dups(),
                    new Q2_02_Return_Kth_To_Last(),
                    new Q2_03_Delete_Middle_Node(),
                    new Q2_04_Partition(),
                    new Q2_05_Sum_Lists(),
                    new Q2_06_Palindrome(),
                    new Q2_07_Intersection(),
                    new Q2_08_Loop_Detection()
                },

                new Question[] {
                    new Q3_01_Three_in_One_A(),
                    new Q3_01_Three_in_One_B(),
                    new Q3_02_Stack_Min(),
                    new Q3_03_Stack_of_Plates(),
                    new Q3_04_Queue_via_Stacks(),
                    new Q3_05_Sort_Stack(),
                    new Q3_06_Animal_Shelter()
                },

                new Question[] {
                    new Q4_01_Route_Between_Nodes(),
                    new Q4_02_CreateMinimalBSTfromSortedUniqueArray(),
                    new Q4_03_List_of_Depths(),
                    new Q4_04_CheckBalanced(),
                    new Q4_05_Validate_BST(),
                    new Q4_06_Successor(),
                    new Q4_07_Build_Order_Edge_Removal_A(),
                    new Q4_07_Build_Order_Edge_DFS_B(),
                    new Q4_08_LowestCommonAncestorNotBST(),
                    new Q4_09_BST_Sequence(),
                    new Q4_10_Check_SubTree(),
                    new Q4_11_Random_Node(),
                    new Q4_12_Paths_with_SumA(),
                    new Q4_12_Paths_with_SumB(),
                    new ReplaceNodeInImmutableTree()
                },

                new Question[] {
                    new Q5_01_Insertion(),
                    new Q5_02_Binary_to_String(),
                    new Q5_03_Flip_Bit_to_Win_B(),
                    new Q5_03_Flip_Bit_to_Win_D(),
                    new Q5_04_Next_Number(),
                    new Q5_06_Conversion(),
                    new Q5_06_Conversion(),
                    new Q5_07_Pairwise_Swap(),
                    new Q5_08_Draw_Line()
                },

                new Question[] {
                    new Q10_01_Sorted_Merge(),
                    new Q10_02_Group_Anagrams(),
                    new Q10_03_Search_in_Rotated_Array(),
                    new Q10_05_Sparse_Search(),
                    new Q10_08_Find_Duplicates(),
                    new Q10_09_Sorted_Matrix_Search(),
                    new Q10_10_Rank_from_Stream(),
                    new Q10_11_Peaks_and_Valleys()
                },

                new Question[]
                {
                    new Q16_01_Number_Swapper(),
                    new Q16_02_Word_Frequence(),
                    new Q16_04_Tic_Tac_Toe_Win(),
                    new Q16_06_Smallest_Difference(),
                    new Q16_08_English_Int(),
                    new Q16_19_Pond_Sizes(),
                    new Boggle()
                }

            };

            foreach (var chapter in chapters)
            {
                foreach (Question q in chapter)
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine($"// Executing: {q.Name}");
                    Console.WriteLine("// ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ---- ----");

                    q.Run();
                }
            }

            Console.WriteLine(string.Format("{0}{1}", Environment.NewLine, Environment.NewLine));
            Console.WriteLine("Press [Enter] to quit");
            Console.ReadLine();
        }
    }
}