using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_25_Word_Rectangle
{
    /* A container for a group of words of the same length. */
    public class WordGroup
    {
        private Dictionary<string, bool> lookup = new Dictionary<string, bool>();
        private IList<string> group = new List<string>();

        public WordGroup()
        {

        }

        public bool ContainsWord(string s)
        {
            return lookup.ContainsKey(s);
        }

        public void AddWord(string s)
        {
            group.Add(s);
            lookup[s] = true;
        }

        public int Length()
        {
            return group.Count;
        }

        public string GetWord(int i)
        {
            return group[i];
        }

        public IList<string> GetWords()
        {
            return group;
        }

        public static WordGroup[] CreateWordGroups(string[] list)
        {
            WordGroup[] groupList;
            int maxWordLength = 0;
            // Find out the length of the longest word
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Length > maxWordLength)
                {
                    maxWordLength = list[i].Length;
                }
            }

            /* Group the words in the dictionary into lists of words of 
             * same length.groupList[i] will contain a list of words, each 
             * of length (i+1). */
            groupList = new WordGroup[maxWordLength];
            for (int i = 0; i < list.Length; i++)
            {
                /* We do wordLength - 1 instead of just wordLength since this is used as
                 * an index and no words are of length 0 */
                int wordLength = list[i].Length - 1;
                if (groupList[wordLength] == null)
                {
                    groupList[wordLength] = new WordGroup();
                }
                groupList[wordLength].AddWord(list[i]);
            }
            return groupList;
        }
    }
}
