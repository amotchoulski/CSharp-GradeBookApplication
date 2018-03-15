using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            //return base.GetLetterGrade(averageGrade);

            char grade = 'F';
            int numberOfStudents = Students?.Count ?? -1;

            if (numberOfStudents < 5)
                grade = 'X'; //throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            else
            {
                var rank = Students?.Count(student => student.AverageGrade >= averageGrade) / numberOfStudents;

                if (rank <= 0.2)
                    grade = 'A';
                else if (rank <= 0.4)
                    grade = 'B';
                else if (rank <= 0.6)
                    grade = 'C';
                else if (rank <= 0.8)
                    grade = 'D';
            }

            return grade;
        }

        public override void CalculateStatistics()
        {
            if (Students?.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students.");
            else
            {
                base.CalculateStatistics();
            }

        }
    }
}
