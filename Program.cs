﻿using Level_0.Banking_System;
using Level_0.Currency_Converter;
using Level_0.University_Enrollment;
using Level_0.Online_Shipping;
using Level_0.Financial_Management;
namespace Level_0.Mainthread
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgramMenu();
        }

        public static void ProgramMenu() {
            string Message = "Select a PROGRAM to start up (PRESS UP or Down to select one then press ENTER): ";
            string[] MenuOptions = { "Banking system", "Currency converter", "University enrollment", "Online shipment", "Finance management", "Exit" };
            switch (ShowMenu(MenuOptions, ConsoleColor.Gray, Message))
            {
                case 0:
                    Bank.BankMain();
                    break;
                case 1:
                    Currency.CurrencyMain();
                    break;
                case 2:
                    University.UniversityMain();
                    break;
                case 3:
                    Shipping.ShippingMain();
                    break;
                case 4:
                    Financial.FinancialMain();
                    break;
                case 5:
                    Console.WriteLine("Closing Program System");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Select a valid option please");
                    break;
            }
        }

        //overload of showMenu for using in clases 
        public static int ShowMenu(string [] MenuOptions, ConsoleColor Color, string Message)
        {

            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int SelectedOption = 0;

            do
            {
                Console.Clear();
                Console.WriteLine(Message);


                for (int item = 0; item < MenuOptions.Length; item++)
                {
                    if (item == SelectedOption)
                    {
                     
                        Console.BackgroundColor = Color;
                        Console.ForegroundColor = ConsoleColor.Black;
                        //Console.Write($"->");

                    }

                    Console.WriteLine($"-{MenuOptions[item]}");

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

            return SelectedOption;
        }
    }

}
