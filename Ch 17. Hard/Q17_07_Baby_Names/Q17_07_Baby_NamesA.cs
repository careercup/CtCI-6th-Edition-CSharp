using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_07_Baby_Names
{
    // 方案一
    // Time complexity: O(N log N)
    // 每次掃過需要 O(N) 的工作，每次掃過集合會減半
    // 需要執行 O(log N) 次
    public class Q17_07_Baby_NamesA : Question
    {
        public static IDictionary<string, int> TrulyMostPopularA(IDictionary<string, int> names, string[][] synonyms)
        {
            IDictionary<string, NameSet> groups = ConstructGroups(names);
            MergeClasses(groups, synonyms);
            return ConvertToMap(groups);
        }


        /* Read through (name, frequency) pairs and initialize a mapping
		 * of names to NameSets (equivalence classes).*/
        public static IDictionary<string, NameSet> ConstructGroups(IDictionary<string, int> names)
        {
            IDictionary<string, NameSet> groups = new Dictionary<string, NameSet>();
            foreach (var entry in names)
            {
                string name = entry.Key;
                int frequency = entry.Value;
                NameSet group = new NameSet(name, frequency);
                groups[name] = group;
            }
            return groups;
        }

        public static void MergeClasses(IDictionary<string, NameSet> groups, string[][] synonyms)
        {
            foreach (string[] entry in synonyms)
            {
                string name1 = entry[0];
                string name2 = entry[1];
                NameSet set1 = groups[name1];
                NameSet set2 = groups[name2];
                if (set1 != set2)
                {
                    /* Always merge the smaller set into the bigger one. */
                    NameSet smaller = set2.Size() < set1.Size() ? set2 : set1;
                    NameSet bigger = set2.Size() < set1.Size() ? set1 : set2;

                    /* Merge lists */
                    HashSet<string> otherNames = smaller.GetNames();
                    int frequency = smaller.GetFrequency();
                    bigger.CopyNamesWithFrequency(otherNames, frequency);

                    /* Update mapping */
                    foreach (string name in otherNames)
                    {
                        groups[name] = bigger;
                    }
                }
            }
        }

        public static IDictionary<string, int> ConvertToMap(IDictionary<string, NameSet> groups)
        {
            IDictionary<string, int> list = new Dictionary<string, int>();
            foreach (NameSet group in groups.Values)
            {
                list[group.GetRootName()] = group.GetFrequency();
            }
            return list;
        }



        public override void Run()
        {
            IDictionary<string, int> names = new Dictionary<string, int>();

            names.Add("John", 3);
            names.Add("Jonathan", 4);
            names.Add("Johnny", 5);
            names.Add("Chris", 1);
            names.Add("Kris", 3);
            names.Add("Brian", 2);
            names.Add("Bryan", 4);
            names.Add("Carleton", 4);

            string[][] synonyms ={
                new string[] {"John", "Jonathan"},
             new string[] {"Jonathan", "Johnny"},
             new string[] {"Chris", "Kris"},
             new string[] {"Brian", "Bryan"}
            };

            IDictionary<string, int> finalList = TrulyMostPopularA(names, synonyms);
            foreach (var entry in finalList)
            {
                string name = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine(name + ": " + frequency);
            }
        }
    }
}
