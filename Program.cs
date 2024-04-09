using Level_0.Banking_System;

namespace Level_0.Mainthread
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int SelectedOption = 0;

            string[] MenuOptions = { "Banking system", "Currency converter", "University enrollment", "Online shipment", "Finance management", "Exit" };

            do
            {
                Console.Clear();
                Console.WriteLine("Select a program to start (UP or Down then press ENTER): ");

                for (int item = 0; item < MenuOptions.Length; item++)
                {
                    if (item == SelectedOption)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"- {MenuOptions[item]}");

                    // Reset colors
                    Console.ResetColor();
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    SelectedOption = (SelectedOption == 0) ? MenuOptions.Length - 1 : SelectedOption - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    SelectedOption = (SelectedOption == MenuOptions.Length - 1) ? 0 : SelectedOption + 1;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            switch (SelectedOption)
            {
                case 0:
                    Console.WriteLine("Bank system is not created yet ");
                    Bank.BankMain();
                    break;
                case 1:
                    Console.WriteLine("Currency converter is not created yet");
                    break;
                case 2:
                    Console.WriteLine("University enrollment is not created yet");
                    break;
                case 3:
                    Console.WriteLine("Online shipment is not created yet");
                    break;
                case 4:
                    Console.WriteLine("Finance management is not created yet");
                    break;
                case 5:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Select an option");
                    break;
            }
        }
    }

}
