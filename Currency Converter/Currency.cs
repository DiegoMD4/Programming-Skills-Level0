using Level_0.Mainthread;


namespace Level_0.Currency_Converter
{
    class Currency : Program
    {
        public static void CurrencyMain()
        {
            string[] CurrencyMenu = { "Convertir", "Ver Comision" , "Exit"};

            switch(ShowMenu(CurrencyMenu, ConsoleColor.Blue))
            {
                case 0: Console.WriteLine("Eligió convertir la moneda");
                    Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Vera la comision que va a ganar:");
                    Environment.Exit(0);
                    break;
                 default: Console.WriteLine("EXIT");
                    Program.Main();
                    break;
            }
        }
    }

}  