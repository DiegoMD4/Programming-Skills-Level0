﻿using Level_0.Mainthread;

namespace Level_0.Banking_System
{
    class Usuario:Bank
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

        public void CheckBalance()
        {
            Console.WriteLine($"Current balance: {Saldo:C}");            
        }
        public void AddFounds()
        {
            Console.Write("How much do you want to add?:  ");
            decimal nuevoSaldo = Convert.ToDecimal(Console.ReadLine());
            Saldo += nuevoSaldo;
        }
        public void AddFounds(decimal nuevoSaldo)
        {
            Saldo += nuevoSaldo;
        }
        public void RetireFounds()
        {
            Console.Write("Amount to retire?: ");
            decimal retiroSaldo = Convert.ToDecimal(Console.ReadLine());
            Saldo -= retiroSaldo;
        }
        public static void TransferFounds(Usuario usuarioActual, List<Usuario> usuarios)
        {

            Console.Write("Wich user do you want to transfer: ");
            string nombreReceptor = Console.ReadLine();
            Usuario usuarioReceptor = usuarios.Find(u => u.Nombre == nombreReceptor);

            if (usuarioReceptor == null)
            {
                Console.WriteLine("The users you want to send does not exits. PRESS ANY BUTTON TO CONTINUE");
                Console.ReadKey();

                UsersMenu(usuarioActual, usuarios);

            }

            Console.WriteLine("Select an amount to transfer " + usuarioReceptor.Nombre);
            decimal enviarSaldo = Convert.ToDecimal(Console.ReadLine());
            usuarioReceptor.AddFounds(enviarSaldo);

            usuarioActual.Saldo -= enviarSaldo;

            Console.WriteLine($"Transfer successfully to: {usuarioReceptor.Nombre} the amount of: {enviarSaldo}");
            usuarioActual.CheckBalance();
        }

        public static void UsersMenu(Usuario usuarioActual, List<Usuario> usuarios)
        {
            string[] UserOptions = { "Check balance", "Add Founds", "Retire", "Transfer Money", "Log out" };

            switch (ShowMenu(UserOptions, ConsoleColor.Red))
            {
                case 0:
                    usuarioActual.CheckBalance();
                    Console.ReadKey();
                    UsersMenu(usuarioActual, usuarios);
                    break;
                case 1:
                    usuarioActual.AddFounds();
                    //Console.ReadKey();
                    UsersMenu(usuarioActual, usuarios);

                    break;
                case 2:
                    usuarioActual.RetireFounds();
                    //Console.ReadKey();
                    UsersMenu(usuarioActual, usuarios);

                    break;
                case 3:
                    TransferFounds(usuarioActual, usuarios);
                    Console.ReadKey();
                    UsersMenu(usuarioActual, usuarios);
                    return;
                case 4:
                    BankMain();
                    return;
                default:
                    Console.WriteLine("Non valid option please try again...");
                    break;

            }
            
        }
     }
}
