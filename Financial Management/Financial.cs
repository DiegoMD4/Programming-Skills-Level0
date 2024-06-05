using Level_0.Mainthread;

namespace Level_0.Financial_Management
{
    class Financial:Program
    {
        public static double Income { get; set; } = 0;

        public List<Category> Categories = new List<Category>();
        
        public static Category Medical = new("Medicals");
        public static Category Household = new("Households");
        public static Category Leisure = new("Leisure");
        public static Category Saving = new("Saving");
        public static Category Education = new("Education");

        public static Category[] CategoriesList = { Medical, Household, Leisure, Saving, Education }; 
        public static void FinancialMain()
        {
            FinancialMenu();
           
        }

        public static void FinancialMenu()
        {
            string returnIncome()
            {
                if (Income > 0) {
                    return $"Your Total income: ${Income}";
                }
                return "";
            }
            

            string[] options = { "Enter income", "List Categories", "Evaluate financial situation", "Exit system" };
            string Message = $"Welcome to financial management system. Please select an option. {returnIncome()}";


            switch (ShowMenu(options, ConsoleColor.Yellow, Message))
            {
                case 0:InputIncome();
                    break;
                case 1:
                    OpenCategoriesList();
                    break;
                case 2:
                    EvaluateFinances();
                    break;
                case 3:
                    ProgramMenu();
                    break;
                default:Console.WriteLine("Not valid option");
                    break;
            }

            
        }

        public static void InputIncome()
        {
            Console.CursorVisible = true;
            Console.Write("Input your total income: ");
            Income = Convert.ToDouble(Console.ReadLine());

            FinancialMenu();
        }

        public static void OpenCategoriesList()
        {
            if(Income == 0)
            {
                Console.WriteLine("Should input an income first");
                Console.ReadKey();
                FinancialMenu();
            }
            else
            {
                Category.ListCategories();
            }
        }


        public static void EvaluateFinances()
        {
            if(Income < Category.TotalExpenses)
            {
                Console.WriteLine("Your financial situation is critical, need to spend less money");
                
            }else if(Income > Category.TotalExpenses)
            {
                Console.WriteLine("You are doing great. The expenses are lower than your income.");
            }
            else 
            {
                Console.WriteLine($"Both expenses and your income are equal, try to spend less " +
                    $"in {MostSpent().CategoryName}");
            }
            Console.ReadKey();
            FinancialMenu();
        }

        public static Category MostSpent()
        {
            double maxExpend = 0;
            int index = 0;
            for (int i = 0; i < CategoriesList.Length; i++)
            {
                for (int j = 1; j < CategoriesList.Length; j++)
                {
                    if (CategoriesList[i].Expenses > maxExpend)
                    {
                        maxExpend = CategoriesList[i].Expenses;
                        index = i;
                    }
                }
                Console.WriteLine($"{CategoriesList[i].CategoryName}: ${CategoriesList[i].Expenses}");
            }

            if(maxExpend == 0)
            {
                Console.Write("Not expenses were recorded");
                Console.ReadKey();
                FinancialMenu();
            }

            return CategoriesList[index];
        }
        

    }

     
}
