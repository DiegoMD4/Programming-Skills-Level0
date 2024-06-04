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
                return null;
            }
            

            string[] options = { "Enter income", "List Categories", "Exit system" };
            string Message = $"Welcome to financial management system. Please select an option. {returnIncome()}";


            switch (ShowMenu(options, ConsoleColor.Yellow, Message))
            {
                case 0:InputIncome();
                    break;
                case 1:
                    OpenCategories();
                    break;
                case 2:
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

        public static void OpenCategories()
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

        

    }

     
}
