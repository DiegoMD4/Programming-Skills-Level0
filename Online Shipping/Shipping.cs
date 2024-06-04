using Level_0.Mainthread;

namespace Level_0.Online_Shipping
{
    class Shipping:Program
    {
        public static List<Users> UsersList = new List<Users>();
        
        
        
        public static void ShippingMain()
        {
            Users user1 = new Users("Luigi", "Luigi@gmail.com", "New York, US", "Animosity23");
            Users user2 = new Users("Mario", "Mario@gmail.com", "Milan, Italy", "Password1234");
            UsersList.AddRange(new List<Users> {user1, user2});
            OnlineShippingLogginMenu();
        }


        public static void OnlineShippingLogginMenu()
        {
            string[] options = { "Log In", "Exit system" };
            string Message = "Welcome to Online Shipping system. Log in to send a package";

            switch (ShowMenu(options, ConsoleColor.DarkMagenta, Message) )
            {
                case 0:
                    Console.WriteLine($"System total users: {UsersList.Count}");
                    LogIn(0);
                    break;
                case 1:
                    ProgramMenu();
                    break;
                default:
                    break;
            }
        }

        public static void LogIn(int strikes)
        {
            Console.CursorVisible = true;
            if(strikes == 2)
            {
                Console.WriteLine("Limit of tries reached, system blocking for 3s");
                Console.Clear();
                Console.Beep();
                Console.CursorVisible = false;
                Thread.Sleep(3000);
                OnlineShippingLogginMenu();
            }
            else
            {
                Console.Write("Email: ");
                string? InputEmail = Console.ReadLine();
                Console.Write("Password: ");
                string? InputPassword = Console.ReadLine();
                Users UserExist = UsersList.Find(x => x.Email == InputEmail && x.Password == InputPassword);
                if (UserExist == null)
                {
                    Console.WriteLine("Incorrect email or password. Please try again \n");
                    LogIn(++strikes);
                }
                else
                {
                    UserExist.UsersMain(UserExist);

                }
            }

            


        }
    }
}
