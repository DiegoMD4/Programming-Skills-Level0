using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level_0.University_Enrollment
{
    class Campus
    {
        public string CampusLocation { get; set; }
        public int Slots {  get; set; }

        public Campus(string CampusLocation, int Slots)
        {
            this.CampusLocation = CampusLocation;
            this.Slots = Slots;
        }

        private List<Students> StudentsInCampus = new List<Students>();


        public bool IsAvailable()
        {
            if (StudentsInCampus.Count < Slots)
            {
                return true;
            }

            return false;
        }

        public string CampusInscription(Students ActualStudent)
        {
            Console.CursorVisible = true;

            if (IsAvailable() == false)
            {
                Console.WriteLine($"{CampusLocation} is at full capacity, please choose another one.");
                Console.ReadKey();
                ActualStudent.ChooseProgram(ActualStudent);

            }

            Console.WriteLine($"{CampusLocation} is available, {1 - StudentsInCampus.Count} spaces left");
            StudentsInCampus.Add(ActualStudent);
            Console.WriteLine($"{ActualStudent.FirstName} {ActualStudent.LastName} you were incsripted in the Campus: {CampusLocation} correctly");

            return CampusLocation;

        }
    }
}
