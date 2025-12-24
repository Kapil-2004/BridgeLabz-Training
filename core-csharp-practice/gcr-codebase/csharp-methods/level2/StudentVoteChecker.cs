using System;

class StudentVoteChecker
{
    public static bool CanStudentVote(int age)
    {
        if (age < 0)
            return false;

        if (age >= 18)
            return true;

        return false;
    }

    static void Main()
    {
        int[] ages = new int[10];

        for (int i = 0; i < ages.Length; i++)
        {
            ages[i] = Convert.ToInt32(Console.ReadLine());
            bool result = CanStudentVote(ages[i]);
            Console.WriteLine(result);
        }
    }
}
