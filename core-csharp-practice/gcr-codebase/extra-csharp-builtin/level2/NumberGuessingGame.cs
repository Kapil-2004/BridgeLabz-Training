using System;

class NumberGuessingGame
{
    static void Main()
    {
        Console.WriteLine("Think of a number between 1 and 100.");
        Console.WriteLine("Respond with: high, low, or correct");

        int low = 1, high = 100;
        bool guessed = false;

        while (!guessed)
        {
            int guess = GenerateGuess(low, high);
            Console.WriteLine("Computer guess: " + guess);

            string feedback = GetUserFeedback();

            guessed = UpdateRange(ref low, ref high, guess, feedback);
        }

        Console.WriteLine("🎉 The computer guessed your number!");
    }

    // Generates a random guess within the range
    static int GenerateGuess(int low, int high)
    {
        Random rand = new Random();
        return rand.Next(low, high + 1);
    }

    // Gets feedback from the user
    static string GetUserFeedback()
    {
        Console.Write("Is the guess high, low, or correct? ");
        return Console.ReadLine().ToLower();
    }

    // Updates guessing range based on feedback
    static bool UpdateRange(ref int low, ref int high, int guess, string feedback)
    {
        if (feedback == "high")
            high = guess - 1;
        else if (feedback == "low")
            low = guess + 1;
        else if (feedback == "correct")
            return true;
        else
            Console.WriteLine("Invalid input! Please enter high, low, or correct.");

        return false;
    }
}
