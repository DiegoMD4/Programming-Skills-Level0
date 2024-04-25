using Level_0.Mainthread;


namespace Level_0.Currency_Converter
{
    class Currency : Program
    {
        
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

                case 0:
                    Console.WriteLine("Wich is your currency? :");
                    ChooseCurrency();
                    break;
                 default: Console.WriteLine("EXIT");
                    ProgramMenu();
                    break;
            }
        }


        public static void ChooseCurrency()
        {
            Console.WriteLine($"Which is your currency? :  ");
            Console.ReadKey();

            switch (ShowMenu(currencyTypes, ConsoleColor.Blue))
            {
                case 0:
                    Convertion(CLP, 0);
                    break;
                case 1:
                    Console.WriteLine($"Choose a currency to convert to:  ");
                    Console.ReadKey();
                    Convertion(ARG, 1);
                    break;
                case 2:
                    Console.WriteLine($"Choose a currency to convert to:  ");
                    Console.ReadKey();
                    Convertion(USD ,2);
                    break;
                case 3:
                    Console.WriteLine($"Choose a currency to convert to:  ");
                    Console.ReadKey();
                    Convertion(EUR, 3);

                    break;
                case 4:
                    Console.WriteLine($"Choose a currency to convert to: ");
                    Console.ReadKey();
                    Convertion(TRY, 4);

                    break;
                case 5:
                    Console.WriteLine($"Choose a currency to convert to: ");
                    Console.ReadKey();
                    Convertion(GBP, 5);

                    break;
                default:
                    Console.WriteLine("Unavailable currency or you it write wrong, please try again...");
                    Console.ReadKey();
                    break;
            }

        }

        static void Convertion(double[] convertionRates, int firstCurrency)
        {
            switch (ShowMenu(currencyTypes, ConsoleColor.Blue))
            {
                case 0:
                    ConvertingTo(convertionRates, firstCurrency, 0);
                    Console.ReadKey();
                    break;
                case 1:
                    ConvertingTo(convertionRates, firstCurrency, 1);
                    Console.ReadKey();
                    break;
                case 2:
                    ConvertingTo(convertionRates, firstCurrency, 2);
                    Console.ReadKey();
                    break;
                case 3:
                    ConvertingTo(convertionRates, firstCurrency, 3);
                    Console.ReadKey();
                    break;
                case 4: 
                    ConvertingTo(convertionRates, firstCurrency, 4);
                    Console.ReadKey();
                    break;
                case 5: 
                    ConvertingTo(convertionRates, firstCurrency, 5);
                    Console.ReadKey();
                    break;
                default: Console.WriteLine("Unavailable currency or you it write wrong, please try again...");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Do you want still operating... yes/no? ");
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


        static void ConvertingTo(double[] convertionRates, int firstValue, int secondValue)
        {
            Console.WriteLine($"Converting: {currencyTypes[firstValue]} -> {currencyTypes[secondValue]}");
            
            Console.WriteLine("Set the amount you want to convert: ");
            double newValue = Convert.ToDouble(Console.ReadLine());
            
            newValue *= convertionRates[secondValue];

            string newCurrencyType = currencyTypes[secondValue];
            Console.WriteLine($"CONVERTION DONE!: {newValue} {newCurrencyType}");
            Console.WriteLine("do you want retire your founds... yes/no? ");
            var option = Console.ReadLine();
            if (option == "yes")
            {
                commisionCharge(newValue, newCurrencyType);

            }
            else
            {
                Environment.Exit(0);
            }


        }
        

        static void commisionCharge(double value , string currencyType)
        {
            var valueAfterCommision = value - (value * 0.01);
            Console.WriteLine($"The system charges a 1% commision of convertion," +
                $" your found now is: {valueAfterCommision} {currencyType} ");
            
        }
    }

}  