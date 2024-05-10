using Level_0.Mainthread;

namespace Level_0.University_Enrollment
{
    class University:Program
    {

        
        static List <Students> StudentsList = new List<Students>();

        public static Programs ComputerScience = new("Computer Science");
        public static Programs Medicine = new("Medicine");
        public static Programs Marketing = new("Marketing");
        public static Programs Arts = new("Arts");

        public static Campus London = new("London", 1);
        public static Campus Manchester = new("Manchester", 3);
        public static Campus Liverpool = new("Liverpool", 3);

        public static Programs[] UniversityPrograms = {ComputerScience, Medicine, Marketing, Arts};
        public static Campus[] UniversityCampus = {London, Manchester, Liverpool};

        

    public static void UniversityMain()
        {
            UniversityMenu();
        }


        public static void UniversityMenu()
        {
            string Message = $"Welcome to Oxford University, what do you want to do?: ";
            string[] options = { "Login", "Register", "Display elements","Exit" };

            switch (ShowMenu(options, ConsoleColor.Green, Message))
            {
                case 0: Login(1);
                    break;
                case 1: CreateUser();
                    break;
                case 2:
                    DisplayUsers();
                    break;
                default:
                    break;
            }

        }


        public static void Login(int strikes)
        {
            if (strikes < 3)
            {
                Console.CursorVisible = true;
                Console.WriteLine("Username:");
                string username = Console.ReadLine();
                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                Students findedStudent = StudentsList.Find(student => student.Username == username && student.Password == password);
                
                if (findedStudent != null)
                {
                    findedStudent.StudentsMain(findedStudent);
                }
                else
                {
                    Console.WriteLine($"Wrong username or password tried again... number of tries: {3 - strikes} \n");
                    Login(++strikes);
                }
            }
            else
            {
                Console.Beep();
                Console.CursorVisible = false;
                Console.WriteLine("Tried to log in 3 times without success. The system is now blocked for 10 seconds.");
                Thread.Sleep(3000); //10000 = 10s
                UniversityMenu();
            }
        }


        public static void CreateUser()
        {
            Console.WriteLine("Create an username: ");
            string? username = Console.ReadLine();
            Console.WriteLine($"Create your password, {username} :");
            string? password = Console.ReadLine();

            Students student = new(username, password);
            StudentsList.Add(student);

            UniversityMenu();

        }

        public static void DisplayUsers()
        {
            if (StudentsList.Count > 0)
            {
                foreach (var element in StudentsList)
                {
                    Console.WriteLine($"Name: {element.FirstName} / Program: {element.ChosenProgram} / Campus: {element.ChosenCampus}");
                }
                Console.ReadKey();
                UniversityMenu();

            }
            else
            {
                Console.WriteLine("No users to display, press ANY KEY to go to the menu");
                Console.ReadKey();
                UniversityMenu();

            }
        }
    }
}
