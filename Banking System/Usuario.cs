using Level_0.Mainthread;

namespace Level_0.Banking_System
{
    class Usuario
    {

        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public decimal Saldo { get; private set; }

        public Usuario(string nombre, string contrasena)
        {
            Nombre = nombre;
            Contrasena = contrasena;
            Saldo = 2000;

        }

        public void VerSaldo()
        {

            Console.WriteLine($"Saldo actual: {Saldo:C}");

        }
        public void AgregarSaldo()
        {
            Console.WriteLine("¿Cuántos fondos desea agregar?");
            decimal nuevoSaldo = Convert.ToDecimal(Console.ReadLine());
            Saldo += nuevoSaldo;
        }
        public void AgregarSaldo(decimal nuevoSaldo)
        {
            Saldo += nuevoSaldo;
        }
        public void RetirarSaldo()
        {
            Console.WriteLine("¿Cuántos fondos desea retirar?");
            decimal retiroSaldo = Convert.ToDecimal(Console.ReadLine());
            Saldo -= retiroSaldo;
        }
        public static void TransferirSaldo(Usuario usuarioActual, List<Usuario> usuarios)
        {

            Console.Write("A quien desea enviar dinero: ");
            string nombreReceptor = Console.ReadLine();
            Usuario usuarioReceptor = usuarios.Find(u => u.Nombre == nombreReceptor);

            if (usuarioReceptor == null)
            {
                Console.WriteLine("Ese usuario no existe");

            }

            Console.WriteLine("Cuanto dinero desea enviar a: " + usuarioReceptor.Nombre);
            decimal enviarSaldo = Convert.ToDecimal(Console.ReadLine());
            usuarioReceptor.AgregarSaldo(enviarSaldo);

            usuarioActual.Saldo -= enviarSaldo;

            Console.WriteLine($"Has enviado con éxito a: {usuarioReceptor.Nombre} la cantidad de: {enviarSaldo}");
            usuarioActual.VerSaldo();
        }

        public static void MostrarMenuOperaciones(Usuario usuarioActual, List<Usuario> usuarios)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("----- Menú de Operaciones -----");
                Console.WriteLine("1. Ver saldo");
                Console.WriteLine("2. Agregar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Transferir");
                Console.WriteLine("5. Cerrar sesión");
                Console.WriteLine("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        usuarioActual.VerSaldo();
                        Console.ReadKey();
                        break;
                    case "2":
                        usuarioActual.AgregarSaldo();
                        break;
                    case "3":
                        usuarioActual.RetirarSaldo();
                        break;
                    case "4":
                        TransferirSaldo(usuarioActual, usuarios);
                        return;
                    case "5":
                        Program.ShowMenu();
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;

                }
            }
        }
    }
}
