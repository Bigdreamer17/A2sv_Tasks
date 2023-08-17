using System;

public class PalindromeChecker
{
    public bool IsPalindrome(string input)
    {
        // Remove spaces, punctuation, and convert to lowercase
        string cleanedInput = RemoveSpacesAndPunctuation(input).ToLower();

        // Check if the cleaned input is a palindrome
        int left = 0;
        int right = cleanedInput.Length - 1;

        while (left < right)
        {
            if (cleanedInput[left] != cleanedInput[right])
            {
                return false;
            }

            left++;
            right--;
        }

        return true;
    }

    private string RemoveSpacesAndPunctuation(string input)
    {
        string cleanedInput = "";

        foreach (char character in input)
        {
            if (!char.IsWhiteSpace(character) && !char.IsPunctuation(character))
            {
                cleanedInput += character;
            }
        }

        return cleanedInput;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        PalindromeChecker checker = new PalindromeChecker();
        bool isPalindrome = checker.IsPalindrome(input);

        if (isPalindrome)
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }
}

