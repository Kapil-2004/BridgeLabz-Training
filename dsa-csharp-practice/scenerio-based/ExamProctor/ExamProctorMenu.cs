using System;       
using System.Net;

namespace ExamProctor
{
    public class ExamProctorMenu
    {
        private ExamProctorUtility proctor = new ExamProctorUtility();

        public void ShowMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n Exam Proctor Menu\n");
                Console.WriteLine("1. Visit Question");
                Console.WriteLine("2. Answer Question");
                Console.WriteLine("3. Review Last Question");
                Console.WriteLine("4. Submit Exam");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: 
                            proctor.VisitQuestion(); 
                            break;

                    case 2: 
                            proctor.AnswerQuestion(); 
                            break;

                    case 3: 
                            proctor.ReviewLastQuestion();
                            break;

                    case 4:
                            proctor.SubmitExam();
                            break;
                
                    default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                }
            } while (choice != 0);
        }
    }
}