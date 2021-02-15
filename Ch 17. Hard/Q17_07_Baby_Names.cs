using ctci.Contracts;
using ctci.Library;
using System;

namespace Chapter17
{
    public class Q17_07_Baby_Names : IQuestion
    {

        public void Run()
        {
            // Input
			var names = new Dictionary<string, int>();
			
			names.Add("John", 3);
			names.Add("Jonathan", 4);
			names.Add("Johnny", 5);
			names.Add("Chris", 1);
			names.Add("Kris", 3);
			names.Add("Brian", 2);
			names.Add("Bryan", 4);
			names.Add("Carleton", 4);
			
			var synonyms = new Dictionary<string,string>();
			synonyms.Add("John","Jonathan");
			synonyms.Add("Jonathan","Johnny");
			synonyms.Add("Chris","Kris");
			synonyms.Add("Brian","Bryan");
			
			// Build connection between names
			var allNames = new Dictionary<string,string>();
			foreach (var s in synonyms) {
				string str;
				if (allNames.TryGetValue(s.Key, out str)) {
					allNames.Add(s.Value, str);
				}
				else if (allNames.TryGetValue(s.Value, out str)) {
					allNames.Add(s.Key, str);
				}
				else {
					allNames.Add(s.Key, s.Value);
					allNames.Add(s.Value, s.Value);
				}
			}
			
			// Results
			var results = new Dictionary<string,int>();
			foreach(var n in names) {
				// Find the chosen name in allNames
				string str = n.Key;
				if (allNames.TryGetValue(n.Key, out str) == false) {
					str = n.Key; // If doesn't exist just use this name
				}
				// Finllay we get the result
				int temp = 0;
				results.TryGetValue(str, out temp);
				temp += n.Value;
				results[str] = temp;
			}
			
			// Print Output
			foreach (var r in results) {
				Console.WriteLine(r.Key + " " + r.Value);
			}
			
			Console.WriteLine("Done.");
        }
    }
}