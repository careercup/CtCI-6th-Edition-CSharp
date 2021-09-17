using Big_O;
using Ch_03._Stacks_and_Queues.Introduction;
using Ch_03._Stacks_and_Queues.Q3_01_Three_in_One;
using Ch_03._Stacks_and_Queues.Q3_02_Stack_Min;
using Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates;
using Ch_03._Stacks_and_Queues.Q3_04_Queue_via_Stacks;
using Ch_03._Stacks_and_Queues.Q3_05_Sort_Stack;
using Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter;
using Ch_04._Trees.Introduction;
using Ch_04._Trees.Q4_01_Route_Between_Nodes;
using Ch_04._Trees.Q4_07_Build_Order.DFSB;
using Ch_04._Trees.Q4_07_Build_Order.EdgeRemovalA;
using Ch_04._Trees.Q4_11_Random_Node;
using Ch_04._Trees.Q4_12_Paths_with_Sum;
using Ch_06._Math_and_Logic_Puzzles.Introduction;
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
using Ch_08._Recursion_and_Dynamic_Programming.Introduction;
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
using Ch_10._Sorting_and_Searching.Introduction;
using Ch_10._Sorting_and_Searching.Q10_04_Sorted_Search_No_Size;
using Ch_10._Sorting_and_Searching.Q10_07_Missing_Int;
using Ch_15._Threads_and_Locks.IntroductionA;
using Ch_15._Threads_and_Locks.IntroductionB;
using Ch_15._Threads_and_Locks.IntroductionLocksF;
using Ch_15._Threads_and_Locks.IntroductionSynchronizationD;
using Ch_15._Threads_and_Locks.IntroductionSynchronizedBlocksC;
using Ch_15._Threads_and_Locks.IntroductionWaitNotifyE;
using Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionA;
using Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionB;
using Ch_15._Threads_and_Locks.Q15_04_Deadlock_Free_Class;
using Ch_15._Threads_and_Locks.Q15_05_Call_In_Order;
using Ch_15._Threads_and_Locks.Q15_06_Synchronized_Methods;
using Ch_15._Threads_and_Locks.Q15_07_FizzBuzz;
using Ch_16._Moderate.Q16_02_Word_Frequencies;
using Ch_16._Moderate.Q16_03_Intersection;
using Ch_16._Moderate.Q16_04_Tic_Tac_Win;
using Ch_16._Moderate.Q16_05_Factorial_Zeros;
using Ch_16._Moderate.Q16_06_Smallest_Difference;
using Ch_16._Moderate.Q16_07_Number_Max;
using Ch_16._Moderate.Q16_08_English_Int;
using Ch_16._Moderate.Q16_09_Operations;
using Ch_16._Moderate.Q16_10_Living_People;
using Ch_16._Moderate.Q16_11_Diving_Board;
using Ch_16._Moderate.Q16_12_XML_Encoding;
using Ch_16._Moderate.Q16_13_Bisect_Squares;
using Ch_16._Moderate.Q16_14_Best_Line;
using Ch_16._Moderate.Q16_15_Master_Mind;
using Ch_16._Moderate.Q16_16_Sub_Sort;
using Ch_16._Moderate.Q16_17_Contiguous_Sequence;
using Ch_16._Moderate.Q16_18_Pattern_Matcher;
using Ch_16._Moderate.Q16_19_Pond_Sizes;
using Ch_16._Moderate.Q16_20_T9;
using Ch_16._Moderate.Q16_21_Sum_Swap;
using Ch_16._Moderate.Q16_22_Langtons_Ant;
using Ch_16._Moderate.Q16_23_Rand7_From_Rand5;
using Ch_16._Moderate.Q16_24_Pairs_With_Sum;
using Ch_16._Moderate.Q16_25_LRU_Cache;
using Ch_16._Moderate.Q16_26_Calculator;
using Chapter01;
using Chapter02;
using Chapter04;
using Chapter05;
using Chapter05.Q5_03_Flip_Bit_to_Win;
using Chapter05.Sample_Code;
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

                new Question[]
                {
                    new Example_16_Power_of_2(),
                    // new QVI_11_Print_Sorted_Strings(),
                },

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
                    new QueueTester(),
                    new StackTester(),
                    new Q3_01_Three_in_One_A(),
                    new Q3_01_Three_in_One_B(),
                    new Q3_02_Stack_Min(),
                    new Q3_03_Stack_of_Plates(),
                    new Q3_04_Queue_via_Stacks(),
                    new Q3_05_Sort_Stack(),
                    new Q3_06_Animal_Shelter()
                },

                //new Question[] {
                //    new Traversals(),
                //    new Q4_01_Route_Between_Nodes(),
                //    new Q4_02_CreateMinimalBSTfromSortedUniqueArray(),
                //    new Q4_03_List_of_Depths(),
                //    new Q4_04_CheckBalanced(),
                //    new Q4_05_Validate_BST(),
                //    new Q4_06_Successor(),
                //    new Q4_07_Build_Order_Edge_Removal_A(),
                //    new Q4_07_Build_Order_Edge_DFS_B(),
                //    new Q4_08_LowestCommonAncestorNotBST(),
                //    new Q4_09_BST_Sequence(),
                //    new Q4_10_Check_SubTree(),
                //    new Q4_11_Random_Node(),
                //    new Q4_12_Paths_with_SumA(),
                //    new Q4_12_Paths_with_SumB(),
                //    new ReplaceNodeInImmutableTree()
                //},

                new Question[] {
                    new RightShifts(),
                    new Sample_Code(),
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
                //new Question[]
                //{
                //    new PrimeNumbers(),
                //    new SieveOfEratosthenesB(),
                //    new Q6_01_Find_Heavy_bottle(),
                //    //new Q6_07_The_Apocalypse(),
                //    new Q6_08_Egg_Drop(),
                //    new Q6_10_Test_StripsA(),
                //    new Q6_10_Test_StripsB(),
                //    new Q6_10_Test_StripsC(),
                //},
                //new Question[]
                //{
                //    new Q7_01_Deck_of_Cards(),
                //    new Q7_04_Parking_Lot(),
                //    new Q7_06_Jigsaw(),
                //    new Q7_08_Othello(),
                //    new Q7_09_Circular_Array(),
                //    //new Q7_10_Minesweeper(),
                //    new Q7_11_File_System(),
                //    new Q7_12_Hash_Table(),
                //},
                //new Question[]
                //{
                //    new FibonacciA(),
                //    new FibonacciB(),
                //    new FibonacciC(),
                //    new FibonacciD(),
                //    new Q8_01_Triple_StepA(),
                //    new Q8_01_Triple_StepB(),
                //    new Q8_02_Robot_in_a_GridA(),
                //    new Q8_02_Robot_in_a_GridB(),
                //    new Q8_03_Magic_IndexA(),
                //    new Q8_03_Magic_IndexB(),
                //    new Q8_04_Power_SetA(),
                //    new Q8_04_Power_SetB(),
                //    new Q8_05_Recursive_MultiplyC(),
                //    new Q8_05_Recursive_MultiplyD(),
                //    new Q8_06_Towers_of_Hanoi(),
                //    new Q8_07_Permutations_Without_DupsA(),
                //    new Q8_07_Permutations_Without_DupsB(),
                //    new Q8_07_Permutations_Without_DupsC(),
                //    new Q8_08_Permutations_With_Dups(),
                //    new Q8_09_ParensA(),
                //    new Q8_09_ParensB(),
                //    new Q8_10_Paint_Fill(),
                //    new Q8_11_CoinsB(),
                //    new Q8_12_Eight_Queens(),
                //    new Q8_13_Stack_of_BoxesB(),
                //    new Q8_13_Stack_of_BoxesC(),
                //    new Q8_14_Boolean_EvaluationA(),
                //    new Q8_14_Boolean_EvaluationB(),
                //},
                //new Question[]
                //{
                //    new Q9_02_Social_NetworkA(),
                //    new Q9_02_Social_NetworkB(),
                //    new Q9_05_Cache(),
                //},

                //new Question[] {
                //    new BinarySearchA(),
                //    new MergeSortB(),
                //    new QuicksortC(),
                //    new Q10_01_Sorted_Merge(),
                //    new Q10_02_Group_Anagrams(),
                //    new Q10_03_Search_in_Rotated_Array(),
                //    new Q10_04_Sorted_Search_No_Size(),
                //    new Q10_05_Sparse_Search(),
                //    new Q10_07_Missing_IntA(),
                //    new Q10_07_Missing_IntB(),
                //    new Q10_08_Find_Duplicates(),
                //    new Q10_09_Sorted_Matrix_Search(),
                //    new Q10_10_Rank_from_Stream(),
                //    new Q10_11_Peaks_and_Valleys()
                //},
                //new Question[]
                //{
                //    new IntroductionA(),
                //    new IntroductionB(),
                //    new TaskExampleB(),
                //    new IntroductionSynchronizedBlocksC(),
                //    new IntroductionSynchronizationD(),
                //    new IntroductionWaitNotifyE(),
                //    new IntroductionLocksF(),
                //    new Q15_03_Dining_PhilosophersA(),
                //    new Q15_03_Dining_PhilosophersB(),
                //    new Q15_04_Deadlock_Free_Class(),
                //    new Q15_05_Call_In_Order(),
                //    new Q15_06_Synchronized_Methods(),
                //    new Q15_07_FizzBuzzA(),
                //    new Q15_07_FizzBuzzB(),
                //    new Q15_07_FizzBuzzC(),
                //},

                new Question[]
                {
                    new Q16_01_Number_Swapper(),
                    new Q16_02_Word_FrequenciesA(),
                    new Q16_02_Word_FrequenciesB(),
                    new Q16_03_Intersection(),
                    new Q16_04_Tic_Tac_WinA(),
                    new Q16_04_Tic_Tac_WinB(),
                    new Q16_04_Tic_Tac_WinC(),
                    new Q16_04_Tic_Tac_WinD(),
                    new Q16_04_Tic_Tac_WinE(),
                    new Q16_04_Tic_Tac_WinF(),
                    new Q16_04_Tic_Tac_WinG(),
                    new Q16_04_Tic_Tac_WinH(),
                    new Q16_05_Factorial_ZerosA(),
                    new Q16_05_Factorial_ZerosB(),
                    new Q16_06_Smallest_DifferenceA(),
                    new Q16_06_Smallest_DifferenceB(),
                    new Q16_06_Smallest_DifferenceC(),
                    new Q16_07_Number_Max(),
                    new Q16_08_English_IntA(),
                    new Q16_09_Operations(),
                    // new Q16_10_Living_PeopleA(),
                    new Q16_10_Living_PeopleB(),
                    new Q16_10_Living_PeopleC(),
                    new Q16_10_Living_PeopleD(),
                    new Q16_11_Diving_BoardA(),
                    new Q16_11_Diving_BoardB(),
                    new Q16_11_Diving_BoardC(),
                    new Q16_12_XML_Encoding_OO_A(),
                    new Q16_13_Bisect_Squares(),
                    new Q16_14_Best_Line(),
                    new Q16_15_Master_Mind(),
                    new Q16_16_Sub_SortA(),
                    new Q16_16_Sub_SortB(),
                    new Q16_17_Contiguous_Sequence(),
                    new Q16_18_Pattern_MatcherA(),
                    new Q16_18_Pattern_MatcherB(),
                    new Q16_18_Pattern_MatcherC(),
                    new Q16_18_Pattern_MatcherD(),
                    new Q16_19_Pond_SizesA(),
                    new Q16_19_Pond_SizesB(),
                    new Q16_20_T9A(),
                    new Q16_20_T9B(),
                    new Q16_20_T9C(),
                    new Q16_21_Sum_SwapA(),
                    new Q16_21_Sum_SwapB(),
                    new Q16_21_Sum_SwapC(),
                    new Q16_21_Sum_SwapD(),
                    new Q16_22_Langtons_Ant(),
                    //new Q16_23_Rand7_From_Rand5_A(),
                    //new Q16_23_Rand7_From_Rand5_B(),
                    new Q16_24_Pairs_With_SumA(),
                    new Q16_24_Pairs_With_SumB(),
                    new Q16_24_Pairs_With_SumC(),
                    new Q16_25_LRU_Cache(),
                    new Q16_26_CalculatorA(),
                    new Q16_26_CalculatorB(),
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