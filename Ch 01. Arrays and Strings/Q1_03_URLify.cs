using ctci.Contracts;
using System;
using System.Linq;

namespace Chapter01
{
    public class Q1_03_URLify : Question
    {
		// Assume string has sufficient free space at the end
		public void ReplaceSpaces(char[] str, int trueLength)
		{
			int spaceCount = 0;
			for (int i = 0; i < trueLength; i++)
			{
				if (str[i] == ' ')
				{
					spaceCount++;
				}
			}
			int index = trueLength + spaceCount * 2;
			if (trueLength < str.Length) str[trueLength] = '\0';
			for (int i = trueLength - 1; i >= 0; i--)
			{
				if (str[i] == ' ')
				{
					str[index - 1] = '0';
					str[index - 2] = '2';
					str[index - 3] = '%';
					index -= 3;
				}
				else
				{
					str[index - 1] = str[i];
					index--;
				}
			}
		}

		private int FindLastCharacter(char[] str)
		{
			for (int i = str.Length - 1; i >= 0; i--)
			{
				if (str[i] != ' ')
				{
					return i;
				}
			}
			return -1;
		}

		public override void Run()
		{
			var arr = "Mr John Smith    ".ToArray();
			int trueLength = FindLastCharacter(arr) + 1;
			ReplaceSpaces(arr, trueLength);
			Console.WriteLine("\"" + new string(arr) + "\"");
		}
	}
}