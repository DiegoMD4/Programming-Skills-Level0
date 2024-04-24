using Level_0.Mainthread;


namespace Level_0.Currency_Converter
{
    class Currency : Program
    {
        static string[] currencyToConvert = new string[2];
        static string[] currencyTypes = { "CLP", "ARG", "USD", "EUR", "TRY", "GBP" };
        static double[] CLP = { 1, 0.91, 0.00104374, 0.0009828, 0.03313, 0.0008425 };
        static double[] ARG = { 1.0989, 1, 0.001147, 0.00108, 0.0363, 0.000924 };
        static double[] USD = { 957.82, 873.69, 1, 0.9429, 31.75, 0.8083 };
        static double[] EUR = { 1017.63, 927.19, 1.0607, 1, 33.62, 0.8563 };
        static double[] TRY = { 30.12, 27.44, 0.0313, 0.0295, 1, 0.0254 };
        static double[] GBP = { 1186.1, 1081.4, 1.2396, 1.1683, 39.3, 1 };

        public static void CurrencyMain()
        {
            string[] CurrencyMenu = { "Convert your currency", "Exit"};
            switch (ShowMenu(CurrencyMenu, ConsoleColor.Blue))
            {

                case 0:Console.Clear();
                    ChooseCurrency();
                    break;
                //case 1:
                //    Console.WriteLine("Vera la comision que va a ganar:");
                //    Environment.Exit(0);
                //    break;
                 default: Console.WriteLine("EXIT");
                    ProgramMenu();
                    break;
            }
        }


        public static void ChooseCurrency()
        {
            Console.WriteLine("Available currencys");

            for (int i = 0; i < currencyTypes.Length-1; i++)
            {
                Console.WriteLine($"-{currencyTypes[i]}");
            }

            Console.WriteLine("Choose your currency: ");
            currencyToConvert[0] = Console.ReadLine();
            Console.WriteLine("Now choose the currency you want to convert for:");
            currencyToConvert[1] = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"These currencys you are going to convert: {currencyToConvert[0]} to {currencyToConvert[1]}" +
                $" ... yes / no?");
            var option = Console.ReadLine();
            if(option == "no")
            {
                CurrencyMain();
            }

            Convertion(currencyToConvert[0], currencyToConvert[1]);
        }

        static void Convertion(string firstCurrency, string secondCurrency)
        {
            switch (firstCurrency)
            {
                case "CLP": Console.WriteLine($"Converting CLP to:  {secondCurrency}");
                    chileanPesosTo(secondCurrency);
                    Console.ReadKey();
                    break;
                case "ARG": Console.WriteLine($"Converting ARG to:  {secondCurrency}");
                    argentinianPesosTo(secondCurrency);
                    Console.ReadKey();
                    break;
                case "USD": Console.WriteLine($"Converting USD to:  {secondCurrency}");
                    usDollarsTo(secondCurrency);
                    Console.ReadKey();
                    break;
                case "EUR": Console.WriteLine($"Converting EUR to:  {secondCurrency}");
                    euroTo(secondCurrency);
                    Console.ReadKey();
                    break;
                case "TRY": Console.WriteLine($"Converting TRY to:  {secondCurrency}");
                    turkishTo(secondCurrency);
                    Console.ReadKey();
                    break;
                case"GBP": Console.WriteLine($"Converting GBP to:  {secondCurrency}");
                    britishPoundTo(secondCurrency);
                    Console.ReadKey();
                    break;
                default: Console.WriteLine("Unavailable currency or you it write wrong, please try again...");
                    Console.ReadKey();
                    Convertion(firstCurrency, secondCurrency);
                    break;
            }
            Console.WriteLine("do you want still operating... yes/no? ");
            var option = Console.ReadLine();
            if (option == "yes")
            {
                CurrencyMain();
            }
            else
            {
                Environment.Exit(0);
            }
        }


        static void chileanPesosTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }
                
            }

            newValue = currentValue * CLP[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }
        static void argentinianPesosTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }
                
            }

            newValue = currentValue * ARG[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }
        static void usDollarsTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }

            }

            newValue = currentValue * USD[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }

        static void euroTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }

            }

            newValue = currentValue * EUR[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }

        static void turkishTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }

            }

            newValue = currentValue * TRY[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }

        static void britishPoundTo(string secondCurrency)
        {
            Console.WriteLine("Set the amount you want to convert: ");
            double currentValue = Convert.ToDouble(Console.ReadLine());
            double newValue;
            string newCurrencyType = "CLP";
            int position = 0;
            for (int i = 0; i < currencyTypes.Length; i++)
            {
                if (secondCurrency == currencyTypes[i])
                {
                    position = i;
                    newCurrencyType = currencyTypes[i];
                }

            }

            newValue = currentValue * GBP[position];

            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType} ");
        }
    }

}  