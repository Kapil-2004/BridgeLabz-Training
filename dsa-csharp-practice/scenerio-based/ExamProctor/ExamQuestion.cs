using System;

namespace ExamProctor
{
    public class ExamQuestion
    {
        public string QuestionText { get; private set; }
        public string CorrectOption { get; private set; }
        public string[] Options { get; private set; }

        public ExamQuestion(string questionText, string correctOption, string[] options)
        {
            QuestionText = questionText;
            CorrectOption = correctOption;
            Options = options;
        }
    }
}