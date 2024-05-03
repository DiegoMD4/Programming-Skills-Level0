using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_0.University_Enrollment
{
    class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Campus { get; set; }  

        public static void StudentsMain(Students actualStudent, List<Students>students)
        {
            Console.WriteLine($"Hi {actualStudent.Username} please register into a program: ");
            Console.ReadKey();  
        }

    }
}
