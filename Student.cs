using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA_ClassInstancesMethods_Hafsa
{
    public class Student
    {
        //properties
        public string Name
        {
            get; set; 
        }
        public List<int> ExamScores
        {
            get; private set;
        }

        //constructor to initialize the student with a name and a list of exam scores
        public Student(string name)
        {
            Name = name;
            ExamScores = new List<int>();
        }

        //constructor that takes a name and a list of grades
        public Student(string name, List<int> examScores)
        {
            Name = name;
            ExamScores = examScores;
        }

        public void AddGrade(int grade)
        {
            //only grades between 0 and 100 can be entered
            if (grade >= 0 && grade <= 100)
            {
                //add grade to examscores
                ExamScores.Add(grade);

                //displays the grade that was entered
                Console.WriteLine($"Added grade {grade} for {Name}");
            }
            else
            {
                //displays that the grade wasnt entered and why
                Console.WriteLine($"Invalid grade: {grade}. Grade must be between 0 and 100.");
            }

        }

        //get letter grade takes a number grade and coverts it to a letter grade
        private char GetLetterGrade(int score)
        {
            //anything above 90 is A, between 80-89 is a b etc...
            if (score >= 90)
            {
                return 'A';
            }
            else if (score >= 80)
            {
                return 'B';
            }
            else if (score >= 70)
            {
                return 'C';
            }
            else if (score >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        //a method that displays all grades
        public void DisplayAllGrades()
        {
            //this will display the students name 
            //because we are accessing a local property we can just say name
            //it always refers to the name for the related instanced data
            Console.WriteLine($"Grades for {Name}");

            //loop thru our examscores
            for (int i = 0; i < ExamScores.Count; i++)
            {
                

                //we call our getlettergrade() method to get the approppriate grade
                char letterGrade = GetLetterGrade(ExamScores[i]);

                //now we format a string to display the result
                Console.WriteLine($"Exam {i + 1}: {letterGrade} ({ExamScores[i]})");

                //ex: exam 1: A 93
            }
        }

        //method to calculate the average score of all exams 
        public double CaluclateAverageScore()
        {
            //1a. validation condition - if there are no grades in our list this code returns 0
            if (ExamScores.Count == 0)
            {
                return 0;
            }

            //1b. sum all grades - this is the standard code to sum up all numbers in a lsit of int
            int totalScore = 0;
            foreach (int score in ExamScores)
            {
                totalScore += score;
            }

            //1c. rerturn average grade - the equation to get the average is
            //to divide the sum of the numbers by the numberofelements. we cast
            //totalscore with (double) to ensure a decinal will be retured 
            return (double)totalScore / ExamScores.Count;
        }

        //method to get the overall letter grade based on the average score
        public char GetGrade()
        {
            //1a. calculate the average score - we call the method to get the studetns overall grade
            double averageScore = CaluclateAverageScore();

            //1b. covert the avrage score to the nearest whole number - using math.round we convert our double which will have decimals to a whole number rounded apropriately
            int roundedAverageScore = (int)Math.Round(averageScore);

            //1c. get the letter grade based on the rounded average score - we call our getlettergrade method to return out letter grade
            return GetLetterGrade(roundedAverageScore);
        }

        //method to display basic student info
        public void DisplayStudentInfo()
        {
            //calculate the average score 
            double averageScore = CaluclateAverageScore();

            //get the overall letter grade
            char grade = GetGrade();

            //display the students name
            Console.WriteLine($"Student Name: {Name}");

            //display the average score with 2 decimal plaves
            Console.WriteLine($"Average Score: {averageScore:F2}");

            //display the overall grade letter
            Console.WriteLine($"Grade: {grade}");

        }


    }//class


}//namespace
