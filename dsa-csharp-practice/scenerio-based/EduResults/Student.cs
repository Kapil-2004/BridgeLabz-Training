using System;

namespace EduResults
{
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }

        // Constructor
        public Student(int rollNo, string name, int score)
        {
            RollNo = rollNo;
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return string.Format("Roll: {0}, Name: {1}, Score: {2}", RollNo, Name, Score);
        }
    }
}