# unshaped-hashtable-example
An example of using C# hash tables based around a Leet Code problem

This is a quick attempt at a solution for the Leet Code problem 383. Ransom Note:

https://leetcode.com/problems/ransom-note/description/

I've never really used hash tables in anger but this was a really good example of
how fast they can be in solving certain problems and so I thought I would write
a complete application. I wanted to get all the test cases from Leet Code but I
couldn't find how to download them.

The problem is to write a function that takes two string parameters, one is the
ransom note and the other is the magazine. You need to see if you can create the
ransom note from the magazine as if you were cutting out the letters.

The code does the following

1. Loads the test cases from file
2. Loops through all the test cases
3. Uses the CanConstruct function to test
4. CanConstruct does two things
- First build a hash table from the magazine string using char, int
    Each character of the magazine can only be represented once in the table and 
    the int reflects how many times that character appears in string
- Second loop through the ransom note and see if each character is present
in the hash table. If it is present and doesn't have a count of 0 decrement it's
count. If we loop through the whole string we can return true but if at any point
the hash table has a zero for a character (or the character doesn't exist) return
false.
5. Lastly make a note of the total run time