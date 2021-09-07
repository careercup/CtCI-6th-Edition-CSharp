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
using Ch_06._Math_and_Logic_Puzzles.Q6_01_Find_Heavy_bottle;
using Ch_06._Math_and_Logic_Puzzles.Q6_07_The_Apocalypse;
using Ch_06._Math_and_Logic_Puzzles.Q6_08_Egg_Drop;
using Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips;
using Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards;
using Ch_07._Object_Oriented_Design.Q7_04_Parking_Lot;
using Ch_07._Object_Oriented_Design.Q7_06_Jigsaw;
using Ch_07._Object_Oriented_Design.Q7_08_Othello;
using Ch_07._Object_Oriented_Design.Q7_09_Circular_Array;
using Ch_07._Object_Oriented_Design.Q7_10_Minesweeper;
using Ch_07._Object_Oriented_Design.Q7_11_File_System;
using Ch_07._Object_Oriented_Design.Q7_12_Hash_Table;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_01_Triple_Step;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_02_Robot_in_a_Grid;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_03_Magic_Index;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_04_Power_Set;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_05_Recursive_Multiply;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_06_Towers_of_Hanoi;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_07_Permutations_Without_Dups;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_08_Permutations_With_Dups;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_09_Parens;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_10_Paint_Fill;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_11_Coins;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_12_Eight_Queens;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_13_Stack_of_Boxes;
using Ch_08._Recursion_and_Dynamic_Programming.Q8_14_Boolean_Evaluation;
using Ch_09._Scalability_and_Memory_Limits.Q9_02_Social_Network;
using Ch_09._Scalability_and_Memory_Limits.Q9_05_Cache;
using Ch_10._Sorting_and_Searching.Q10_04_Sorted_Search_No_Size;
using Ch_10._Sorting_and_Searching.Q10_07_Missing_Int;
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
                new Question[]
                {
                    new Q6_01_Find_Heavy_bottle(),
                    //new Q6_07_The_Apocalypse(),
                    new Q6_08_Egg_Drop(),
                    new Q6_10_Test_StripsA(),
                    new Q6_10_Test_StripsB(),
                    new Q6_10_Test_StripsC(),
                },
                new Question[]
                {
                    new Q7_01_Deck_of_Cards(),
                    new Q7_04_Parking_Lot(),
                    new Q7_06_Jigsaw(),
                    new Q7_08_Othello(),
                    new Q7_09_Circular_Array(),
                    //new Q7_10_Minesweeper(),
                    new Q7_11_File_System(),
                    new Q7_12_Hash_Table(),
                },
                new Question[]
                {
                    new Q8_01_Triple_StepA(),
                    new Q8_01_Triple_StepB(),
                    new Q8_02_Robot_in_a_GridA(),
                    new Q8_02_Robot_in_a_GridB(),
                    new Q8_03_Magic_IndexA(),
                    new Q8_03_Magic_IndexB(),
                    new Q8_04_Power_SetA(),
                    new Q8_04_Power_SetB(),
                    new Q8_05_Recursive_MultiplyC(),
                    new Q8_05_Recursive_MultiplyD(),
                    new Q8_06_Towers_of_Hanoi(),
                    new Q8_07_Permutations_Without_DupsA(),
                    new Q8_07_Permutations_Without_DupsB(),
                    new Q8_07_Permutations_Without_DupsC(),
                    new Q8_08_Permutations_With_Dups(),
                    new Q8_09_ParensA(),
                    new Q8_09_ParensB(),
                    new Q8_10_Paint_Fill(),
                    new Q8_11_CoinsB(),
                    new Q8_12_Eight_Queens(),
                    new Q8_13_Stack_of_BoxesB(),
                    new Q8_13_Stack_of_BoxesC(),
                    new Q8_14_Boolean_EvaluationA(),
                    new Q8_14_Boolean_EvaluationB(),
                },
                new Question[]
                {
                    new Q9_02_Social_NetworkA(),
                    new Q9_02_Social_NetworkB(),
                    new Q9_05_Cache(),
                },

                new Question[] {
                    new Q10_01_Sorted_Merge(),
                    new Q10_02_Group_Anagrams(),
                    new Q10_03_Search_in_Rotated_Array(),
                    new Q10_04_Sorted_Search_No_Size(),
                    new Q10_05_Sparse_Search(),
                    new Q10_07_Missing_IntA(),
                    new Q10_07_Missing_IntB(),
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