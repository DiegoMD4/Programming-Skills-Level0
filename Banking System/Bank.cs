using Level_0.Mainthread;

namespace Level_0.Banking_System
{
    class Bank
    {

        static List<Usuario> usuarios = new List<Usuario>();
        static Usuario usuarioActual;
        public static void BankMain()
        {
            while (true)
            {
                Menu();
            }
        }

        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("----- Menú -----");
            Console.WriteLine("1. Registrar nuevo usuario");
            Console.WriteLine("2. Iniciar sesión");
            Console.WriteLine("3. Ver usuarios");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarNuevoUsuario();
                    break;
                case "2":
                    IniciarSesion();
                    Console.ReadKey();
                    break;
                case "3":
                    VerUsuarios();
                    Console.ReadKey();
                    break;
                case "4":
                    Program.ShowMenu();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
        static void RegistrarNuevoUsuario()
        {
            Console.WriteLine("Escriba un nombre de usuario: ");
            string? nombre = Console.ReadLine();

            Console.WriteLine("Escriba un nombre de contraseña: ");
            string? contrasena = Console.ReadLine();

            Usuario nuevoUsuario = new Usuario(nombre, contrasena);
            usuarios.Add(nuevoUsuario);

            Menu();
        }

        static void IniciarSesion()
        {
            Console.Write("Ingrese su nombre de usuario: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese su contraseña: ");
            string contrasena = Console.ReadLine();

            Usuario usuario = usuarios.Find(u => u.Nombre == nombre && u.Contrasena == contrasena);

            if (usuario != null)
            {
                Console.WriteLine($"Bienvenido: {usuario.Nombre}");
                usuarioActual = usuario;
                Usuario.MostrarMenuOperaciones(usuario, usuarios);
            }
            else
            {
                Console.WriteLine("Usuario o contraseña incorrectos");
            }
        }

        static void VerUsuarios()
        {
            if (usuarios.Count > 0)
            {
                foreach (var user in usuarios)
                {
                    Console.WriteLine($"Usuario: {user.Nombre}");
                }

            }
            else
            {
                Console.WriteLine("No existen usuarios registrados");
            }


        }



    }
}
