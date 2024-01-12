// This is a really simple example of how Hash Tables/Dictionaries work

namespace unshaped_hashtable_example;
class Program
{
    static void Main(string[] args)
    {
        // Load the Test cases
        var testCases = LoadTestCases();

        // Note the time as we start processing
        var startTime = DateTime.Now;

        // Loop through the test cases seeing if CanConstruct works or not
        for (var i = 0; i < testCases.Count; i++) {
            var result = CanConstruct(testCases[i][0], testCases[i][1]);
            Console.WriteLine($"Test Case {i + 1} returned {result.ToString()}");
        }

        // Capture end time and display run time in Seconds and Milliseconds
        var endTime = DateTime.Now;
        Console.WriteLine($"Complete run time = {(endTime-startTime).Seconds} s {(endTime-startTime).Milliseconds} ms");
    }

    static bool CanConstruct(string ransomNote, string magazine) {
        
        // Create a Dictionary that looks like this
        // a  b  c  d  e  f
        // 1  1  3  2  1  3
        Dictionary<char, int> lettersMap = new Dictionary<char, int>();

        // Now loop through the magazine adding letters to the Dictionary
        for (var i = 0; i < magazine.Length; i++) {
            // If the Dictionary already has an entry for the letter
            // then increase it's value by one
            // If not then add it to the Dictionary with an initial value of 1
            if (lettersMap.ContainsKey(magazine[i])) {
                lettersMap[magazine[i]]++;
            } else {
                lettersMap.Add(magazine[i], 1);
            }
        }

        // Now loop through the ransomNote seeing if the values are present
        // in the Dictionary. If a letter is present then we need to decrement
        // it's value
        for (var i = 0; i < ransomNote.Length; i++) {
            if (lettersMap.ContainsKey(ransomNote[i]) && lettersMap[ransomNote[i]] != 0) {
                lettersMap[ransomNote[i]]--;
            } else {
                return false;
            }
        }
        return true;
    }

    /*  Load the test cases from file
        This is very specific to this piece of code which requires two strings
        one for the ransom note and one for the magazine
        Each test case therfore consists of two strings which are represented in the file as
        Line 1 - ransom note for Test case 1
        Line 2 - magazine for Test case 1
        and so on...
        These are handled in code as a List of a List of strings*/
    static List<List<String>> LoadTestCases() {
        // set up the return value
        var myTestCases = new List<List<string>>();

        // Open the test case file
        // TODO configure as a parameter
        var sr = new StreamReader(@"C:\Users\adrian\OneDrive\Code\C#\unshaped-hashtable-example\testcases.txt");
        // Read a line
        var line = sr.ReadLine();
        // Loop through the lines handling them as described above
        while (null != line) {
            var mycase = new List<string>();
            mycase.Add(line.ToLower());
            line = sr.ReadLine();
            mycase.Add(line.ToLower());
            myTestCases.Add(mycase);
            line = sr.ReadLine();
        }

        sr.Close();

        return myTestCases;
    }
}
