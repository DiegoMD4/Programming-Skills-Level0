

namespace Level_0.Online_Shipping
{
    class Packages:Shipping
    {
        public string Description { get; set; }
        public string PackageObject { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string PackageDirection { get; set; }
        public int TrackingId { get; set; }
        public double Weigth {  get; set; }
        public double TotalCost { get; set; }

        public void PackageMain(Users SenderUser, Users RecipientUser, Packages package)
        {
            if(PackageMenu(SenderUser, RecipientUser, package))
            {
                Console.Write("Do you still want operating? ");

                string ?selection = Console.ReadLine();
                if (selection == null || selection == "no")
                {
                    OnlineShippingLogginMenu();
                }
                else
                {
                    SenderUser.UsersMain(SenderUser);
                }

            }
            else
            {
                SenderUser.UsersMain(SenderUser);
            }
        }

        public bool PackageMenu(Users SenderUser, Users RecipientUser, Packages package)
        {
            Console.CursorVisible = true;
            Console.Write("What do you want to send? ");
            PackageObject = Console.ReadLine();
            Console.Write("Add a proper description to your package: ");
            Description = Console.ReadLine();

            Sender = SenderUser.Name;
            Recipient = RecipientUser.Name;
            PackageDirection = RecipientUser.Direction;

            Random rn = new Random();
            TrackingId = rn.Next(1000);

            Console.Write("Package weight (in kg- $2 per kg): ");
            Weigth = Convert.ToDouble(Console.ReadLine());
            //ASKING IF THE USER WANTS TO COMPLETE THIS OPERATION

            Console.Write("Do you want to proceed? ");
            string? selection = Console.ReadLine();

            if (selection == null || selection == "no")
            {
                return false;
            }
            else
            {
                TotalCost = SenderUser.CalculateCost(Weigth);
                SenderUser.SentPackages.Add(package);
                RecipientUser.ReceivedPackages.Add(package);
                Console.WriteLine($"Operation completed successfully, total cost: ${TotalCost}");
                Console.ReadKey();
                return true;
            }

            
        }
    }
}
