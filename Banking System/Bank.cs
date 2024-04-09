using Level_0.Mainthread;

namespace Level_0.Banking_System
{
    class Bank: Program
    {

        static List<Usuario> usuarios = new List<Usuario>();
        static Usuario usuarioActual;
        public static void BankMain()
        {
            string[] BankMenu = { "Register New User", "Log In", "Display Users", "Exit to Programs menu" };

            switch (ShowMenu(BankMenu, ConsoleColor.Red))
            {
                case 0:
                    RegisterNewUser();
                    break;
                case 1:
                    Login();
                    Console.ReadKey();
                    break;
                case 2:
                    DisplayUsers();
                    Console.ReadKey();
                    break;
                case 3:
                    Program.Main();
                    break;
                default:
                    Console.WriteLine("Invalid Option try again...");
                    break;
            }
        }
            static void RegisterNewUser()
        {
            Console.WriteLine("Write an username: ");
            string? nombre = Console.ReadLine();

            Console.WriteLine("Choose your password: ");
            string? contrasena = Console.ReadLine();

            Usuario nuevoUsuario = new Usuario(nombre, contrasena);
            usuarios.Add(nuevoUsuario);

            Console.WriteLine("Succesfully registered!");
            Console.ReadKey();
            BankMain();
        }

        static void Login()
        {
            Console.Write("Username: ");
            string nombre = Console.ReadLine();

            Console.Write("Password: ");
            string contrasena = Console.ReadLine();

            Usuario usuario = usuarios.Find(u => u.Nombre == nombre && u.Contrasena == contrasena);

            if (usuario != null)
            {
                Console.WriteLine($"Welcome to your bank account: {usuario.Nombre}");
                usuarioActual = usuario;
                Usuario.UsersMenu(usuario, usuarios);
            }
            else
            {
                Console.WriteLine("Incorrect username or password try again...");
                BankMain();
            }
        }

        static void DisplayUsers()
        {
            if (usuarios.Count > 0)
            {
                foreach (var user in usuarios)
                {
                    Console.WriteLine($"User: {user.Nombre}");
                }

            }
            else
            {
                Console.WriteLine("No users to display");
                
            }
            Console.ReadKey();
            BankMain();
        }

    }
}
