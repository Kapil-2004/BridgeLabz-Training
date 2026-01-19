using System;

namespace ExamProctor
{
    interface IExamProctor
    {
        void VisitQuestion();
        void AnswerQuestion();
        void ReviewLastQuestion();
        void SubmitExam();
    }
}