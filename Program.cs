namespace GA_ClassInstancesMethods_Hafsa
{
    //Hafsa Mohamed
    //01/19/24
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of 5 grades ranging between 0 and 100
            List<int> willGrades = new List<int> { 85, 92, 78, 90, 88 };

            // Create a new instance of the Student class with the name "Will" and the grades list
            Student willStudent = new Student("Will", willGrades);

            //call our addgrade instance
            willStudent.AddGrade(78); //success
            willStudent.AddGrade(200); //fails
            willStudent.AddGrade(-130); //fails

            //call our display instance
            willStudent.DisplayAllGrades();

            //call our getgrade instance
            willStudent.GetGrade();

            //call our displaystudent info instance
            willStudent.DisplayStudentInfo();

            List<Student> randomStudents = GenerateRandomStudents();

            //add your student to this list
            randomStudents.Add(willStudent);

            //loop and display all the info
            foreach (Student student in randomStudents)
            {
                student.DisplayStudentInfo();
            }

        }//main


        //new method to generate random students and grades
        static List<Student> GenerateRandomStudents()
        {
            List<Student> students = new List<Student>();
            Random random = new Random(); 

            for (int i = 1; i <= 5; i++)
            {
                Student student = new Student($"Student{i}");

                for (int j = 0; j < 5; j++)
                {
                    student.ExamScores.Add(random.Next(0, 101));
                }

                students.Add(student);
            }

            return students;

        }//list students

    }//class

}//namespace