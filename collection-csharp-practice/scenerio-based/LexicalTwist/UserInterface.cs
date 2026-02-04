using System;

public class UserInterface
{
    public void Start()
    {
        Console.WriteLine("Enter the first word");
        string word1 = Console.ReadLine();

        Console.WriteLine("Enter the second word");
        string word2 = Console.ReadLine();

        ILexicalTwist util = new LexicalTwistUtil();

        try
        {
            string output = util.ProcessWords(word1, word2);
            Console.WriteLine(output);
        }
        catch (InvalidWordException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
