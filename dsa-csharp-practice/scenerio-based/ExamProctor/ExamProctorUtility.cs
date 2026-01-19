using System;
namespace ExamProctor
{
class ExamProctorUtility : IExamProctor
{
    private CustomStack navigationStack = new CustomStack(50);
    private CustomDictionary studentAnswers = new CustomDictionary(50);
    private CustomDictionary correctAnswers = new CustomDictionary(10);

    public ExamProctorUtility()
    {
        // correct answers
        correctAnswers.Add(1, "A");
        correctAnswers.Add(2, "B");
        correctAnswers.Add(3, "C");
        correctAnswers.Add(4, "D");
    }

    public void VisitQuestion()
    {
        Console.Write("Enter Question ID: ");
        int qid = int.Parse(Console.ReadLine());
        navigationStack.Push(qid);
        Console.WriteLine("Visited Question " + qid);
    }

    public void AnswerQuestion()
    {
        Console.Write("Enter Question ID: ");
        int qid = int.Parse(Console.ReadLine());

        Console.Write("Enter Answer (A/B/C/D): ");
        string ans = Console.ReadLine().ToUpper();

        studentAnswers.Add(qid, ans);
        Console.WriteLine("Answer saved.");
    }

    public void ReviewLastQuestion()
    {
        int? last = navigationStack.Peek();

        if (last == null)
            Console.WriteLine("No question visited yet.");
        else
            Console.WriteLine("Last visited question: " + last);
    }

    public void SubmitExam()
    {
        int score = CalculateScore();
        Console.WriteLine("Exam Submitted.");
        Console.WriteLine("Final Score: " + score);
    }

    // 🔹 SCORING FUNCTION
    private int CalculateScore()
    {
        int score = 0;

        for (int i = 0; i < studentAnswers.Count(); i++)
        {
            int qid = studentAnswers.GetKeyAt(i);
            string ans = studentAnswers.GetValueAt(i);

            if (correctAnswers.ContainsKey(qid) &&
                correctAnswers.Get(qid) == ans)
            {
                score++;
            }
        }

        return score;
    }
}
}
