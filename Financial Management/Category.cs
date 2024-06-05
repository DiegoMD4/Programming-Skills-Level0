
namespace Level_0.Financial_Management
{
    class Category : Financial
    {
        public string CategoryName { get; set; }
        public double Expenses { get; set; } = 0;
        public static double TotalExpenses { get; set; } = 0;
        public Category(string Categoryname)
        {
            this.CategoryName = Categoryname;
        }

        public static void ListCategories()
        {
            string returnExpenses()
            {
                if (TotalExpenses > 0)
                {
                    return $"Your Total Expenses: ${TotalExpenses}";
                }
                return null;
            }

            string[] Categories = { "Medical", "Household", "Leisure", "Savings", "Education",  "Go Back"};
            string Message = $"Select a category to input your expenses. {returnExpenses()}";
            switch (ShowMenu(Categories, ConsoleColor.Yellow, Message))
            {
                case 0:
                    CategoriesList[0].OpenCategory();
                    break;
                case 1:
                    CategoriesList[1].OpenCategory();
                    break;
                case 2:
                    CategoriesList[2].OpenCategory();
                    break;
                case 3:
                    CategoriesList[3].OpenCategory();
                    break;
                case 4:
                    CategoriesList[4].OpenCategory();
                    break;
                case 5:
                    FinancialMenu();
                    break;
                default:
                    break;
            }

        }

        public void OpenCategory()
        {
            Console.CursorVisible = true;
            Console.Write($"How much do you spend in {CategoryName}: $");
            double input = Convert.ToDouble(Console.ReadLine());
            
            TotalExpenses = TotalExpenses + input;

            Expenses += input;
            Console.WriteLine($"Accumulated by the time in {CategoryName}: ${Expenses}");
            
            Console.ReadKey();
            ListCategories();
        }
    }
}
