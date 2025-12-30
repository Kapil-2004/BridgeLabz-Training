using System;

class StudentQuizGrader
{
    static string[] answer = {"A","B","B","C","A","C","D","A","A","B"};
    static void Main(string [] args)
    {
        Console.WriteLine("----------------------------------------------------------------------");
        Console.WriteLine("Quiz Grader \n");

        int correct =0;
        int i=0;
        while( i<10 )
        {
            Console.WriteLine("Enter answer for question " + (i+1) + " : ");
            string option = Console.ReadLine();

            if(string.IsNullOrEmpty(option) || option.Length != 1 || !"ABCDabcd".Contains(option))
            {
                Console.WriteLine("Invalid input. Please enter A, B, C, or D. \n");
                continue; // Prompt the user to enter the answer again for the same question
            }

            if (check(option , i))
            {
                Console.WriteLine($"\nQuestion {i+1}: Choosen option is {option.ToUpper()} and Correct option is {answer[i]}");
                Console.WriteLine("Your answer is correct \n");
                correct++;
                i++;
            }
            else
            {
                Console.WriteLine($"Question {i+1}: Choosen option is {option.ToUpper()} and Correct option is {answer[i]}");
                Console.WriteLine("Your answer is wrong \n");
                i++;
            }
        }
        Console.WriteLine("You have scored " + correct + " out of 10");
        Console.WriteLine("----------------------------------------------------------------------");

        Console.WriteLine($"Your percentage is {(correct * 10)}%");
        if(correct >= 5)
        {
            Console.WriteLine("Congratulations! You have passed the quiz.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have failed the quiz. Better luck next time!");
        }

    }

    static bool check(string option , int i)
    {
        if(string.Equals(option, answer[i], StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }

    
}