using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Level_0.University_Enrollment
{
    class Students: University
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }   
        public string ChosenProgram { get; set; }
        public string ChosenCampus { get; set; }
        
        public Students(string Username, string Password) { 
            this.Username = Username;
            this.Password = Password;
        }   

        public void StudentsMain(Students ActualStudent)
        {
            Console.WriteLine($"Welcome @{Username}. To complete your registration please follow the instructions");
            Console.Write("First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();

            ChooseProgram(ActualStudent);

        }

        public void ChooseProgram(Students ActualStudent)
        {
            string[] options = { "Computer Science", "Medicine", "Marketing", "Arts", "Log out"};
            string Message = "Choose one program:";

            switch (ShowMenu(options, ConsoleColor.Green, Message))
            {
                case 0:
                    ChosenProgram = UniversityPrograms[0].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    ChooseCampus(ActualStudent);

                    break;
                case 1:
                    ChosenProgram = UniversityPrograms[1].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    ChooseCampus(ActualStudent);

                    break;
                case 2:
                    ChosenProgram = UniversityPrograms[2].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    ChooseCampus(ActualStudent);

                    break;
                case 3:
                    ChosenProgram = UniversityPrograms[3].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    ChooseCampus(ActualStudent);

                    break;
                case 4:
                    UniversityMain();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again...");
                    break;
            }
            
        }

        public void ChooseCampus(Students ActualStudent)
        {
            string[] options = { "London" , "Manchester", "Liverpool", "Log out" };
            string Message = "Select a campus:";

            switch (ShowMenu(options, ConsoleColor.Green, Message))
            {
                case 0:
                    ChosenCampus = UniversityCampus[0].CampusInscription(ActualStudent);
                    Console.ReadKey();
                    break;
                case 1:
                    ChosenProgram = UniversityPrograms[1].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    break;
                case 2:
                    ChosenProgram = UniversityPrograms[2].EnrollStudent(ActualStudent);
                    Console.ReadKey();
                    break;
                case 3:
                    UniversityMain();
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again...");
                    break;
            }

            UniversityMain();
        }

    }   
}
