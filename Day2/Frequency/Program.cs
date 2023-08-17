using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class CharacterFrequencyCounter
{
    public Dictionary<char, int> CountCharacterFrequency(string input)
    {
        Dictionary<char, int> frequencyDict = new Dictionary<char, int>();

        // Remove punctuation marks and convert the string to lowercase
        string cleanedInput = Regex.Replace(input, @"[\p{P}-[.]]+", "").ToLower();

        // Count the frequency of each character
        foreach (char character in cleanedInput)
        {
            if (char.IsLetter(character))
            {
                if (frequencyDict.ContainsKey(character))
                {
                    frequencyDict[character]++;
                }
                else
                {
                    frequencyDict[character] = 1;
                }
            }
        }

        return frequencyDict;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        CharacterFrequencyCounter counter = new CharacterFrequencyCounter();
        Dictionary<char, int> frequencyDict = counter.CountCharacterFrequency(input);

        Console.WriteLine("Character Frequencies:");
        foreach (var kvp in frequencyDict)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

