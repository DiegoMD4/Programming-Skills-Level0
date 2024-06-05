using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_0.University_Enrollment
{
    class Programs
    {
        public string ProgramName { get; set; }
        public int Capacity = 5;

        private List<Students> EnrolledStudents = new List<Students>();


        public Programs(string ProgramName) { 
            this.ProgramName = ProgramName;
        }

        public bool IsAvailable()
        {
            if(EnrolledStudents.Count < 1)
            {
                return true;
            }

            return false;
        }

        public string EnrollStudent(Students ActualStudent)
        {
            Console.CursorVisible = true;

            if (IsAvailable() == false)
            {
                Console.WriteLine($"{ProgramName} is at full capacity, please choose another one.");
                Console.ReadKey();
                ActualStudent.ChooseProgram(ActualStudent);

            }

            Console.WriteLine($"{ProgramName} is available, {1 - EnrolledStudents.Count} spaces left");
            EnrolledStudents.Add(ActualStudent);
            Console.WriteLine($"{ActualStudent.FirstName} {ActualStudent.LastName} you were incsripted in the program correctly");

            return ProgramName;

        }


    }
}
