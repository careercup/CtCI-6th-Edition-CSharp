using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter16
{
    public class Boggle : Question
    {

        public override void Run()
        {
            // become, bee, seem, certain, top
            var matrix = new char[,]
                {
                    {'b','c','e','p'},
                    {'e','o','r','o'},
                    {'e','m','t','n'},
                    {'s','e','a','i'},
                };

            matrix.PrintMatrix();
            var trie = AssortedMethods.GetTrieDictionary();
            var list = Solve(matrix, trie.Root);
            Console.WriteLine("Words found");
            foreach (var word in list)
                Console.Write($"{word}, ");
            Console.WriteLine();
        }

        public IList<string> Solve(char[,] matrix, TrieNode trie)
        {
            var words = new HashSet<string>();
            var visited = new bool[matrix.Height(), matrix.Width()];
            for (var r = 0; r < matrix.Height(); r++)
                for (var c = 0; c < matrix.Width(); c++)
                {
                    Solve("", matrix, visited, r, c, trie, words);
                }
            return words.ToList();
        }

        private void Solve(string prefix, char[,] matrix, bool[,] visited, int row, int column, TrieNode trie, HashSet<string> words)
        {
            if (matrix.IsOutOfBounds(row, column)) return;
            if (visited[row, column]) return;

            if (trie.Terminates) words.Add(prefix);

            var trieChild = trie.GetChild(matrix[row, column]);
            if (trieChild == null) return;

            visited[row, column] = true;
            prefix += matrix[row, column];
            for (var dr = -1; dr <= 1; dr++)
                for(var dc = -1; dc <= 1; dc++)
                {
                    Solve(prefix, matrix, visited, row + dr, column + dc, trieChild, words);
                }
            visited[row, column] = false;
        }
    }
}
    