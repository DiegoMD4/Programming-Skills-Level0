using Level_0.Mainthread;

namespace Level_0.University_Enrollment
{
    class University:Program
    {

        public string [] UniversityCampus { get; set; } = {"London" , "Manchester" , "Liverpool"};
        public string [] Programs { get; set; } = {"Computer Science" , "Medicine" , "Marketing" , "Arts"};

        static List <Students> students = new List<Students>();

        public static void UniversityMain()
        {            
            Menu();
        }


        public static void Menu()
        {
            string Message = $"Welcome to Oxford University, what do you want to do?: ";
            string[] options = { "Login", "Register", "Display" , "Exit" };

            switch (ShowMenu(options, ConsoleColor.Green, Message))
            {
                case 0: Login(1);
                    break;
                case 1: Register();
                    break;
                case 2: DisplayUsers();
                    break;
                default:
                    break;
            }

        }


        public static void Login(int strikes)
        {
            Console.CursorVisible = true;
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            
            Students findedStudent = students.Find(element => element.Username == username && element.Password == password);

            if (strikes < 3)
            {
                if (findedStudent != null)
                {
                    Students.StudentsMain();
                    
                }
                else
                {
                    Console.WriteLine($"Wrong username or password tried again... number of tries: {3-strikes} \n");
                    Login(++strikes);
                }
            }
            Console.Beep();
            Console.CursorVisible = false;
            Console.WriteLine("Tried to log in 3 times without success. The system is now blocked for 10 seconds.");
            Thread.Sleep(10000);
            Console.Beep();

            Menu();
        }

        public static void Register()
        {
            Console.WriteLine("Create an username: ");
            string username = Console.ReadLine();
            Console.WriteLine($"Create your password {username} :");
            string password = Console.ReadLine();

            Students registeredStudent = new Students();
            registeredStudent.Username = $"@{username}";
            registeredStudent.Password = password;

            students.Add( registeredStudent );

            Console.WriteLine("successfully registered");

            Menu();

        }

        public static void DisplayUsers()
        {
            if (students.Count > 0)
            {
                foreach (var element in students)
                {
                    Console.WriteLine($": {element.Username}");
                }

            }
            else
            {
                Console.WriteLine("No users to display");

            }
        }
    }
}
