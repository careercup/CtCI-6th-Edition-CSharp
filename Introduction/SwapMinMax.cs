﻿using ctci.Contracts;
using ctci.Library;
using System;

namespace Introduction
{
    public class SwapMinMax : Question
    {
        private int GetMinIndex(int[] array)
        {
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        private int GetMaxIndex(int[] array)
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        private void Swap(int[] array, int m, int n)
        {
            int temp = array[m];
            array[m] = array[n];
            array[n] = temp;
        }

        private void SwapMinMaxBetter(int[] array)
        {
            int minIndex = GetMinIndex(array);
            int maxIndex = GetMaxIndex(array);
            Swap(array, minIndex, maxIndex);
        }

        private void DoSwapMinMax(int[] array)
        {
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[minIndex])
                {
                    minIndex = i;
                }
            }

            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            int temp = array[minIndex];
            array[minIndex] = array[maxIndex];
            array[maxIndex] = temp;
        }

        public override void Run()
        {
            int[] array = AssortedMethods.RandomArray(10, -10, 10);
            Console.WriteLine(AssortedMethods.ArrayToString(array));
            SwapMinMaxBetter(array);
            Console.WriteLine(AssortedMethods.ArrayToString(array));
        }
    }
}