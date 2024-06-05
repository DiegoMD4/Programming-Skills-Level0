
namespace Level_0.Online_Shipping
{
    class Users:Shipping
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Direction { get; set; }

        public double Founds = 2000;

        public List<Packages> SentPackages = new List<Packages> { };
        public List<Packages> ReceivedPackages = new List<Packages> { };

        public Users(string Name, string Email, string Direction, string Password) {
            this.Name = Name;
            this.Email = Email;
            this.Direction = Direction;
            this.Password = Password;
        }


        public void UsersMain(Users CurrentUser)
        {
            string[] options = { "Sent package", "Display Sent ", "Received Packages","Log Out" };
            string Message = $"Logged In correctly: {Name}, select an option:";

            switch (ShowMenu(options, ConsoleColor.DarkMagenta, Message))
            {
                case 0: SendPackage(CurrentUser);
                    break;
                case 1: DisplaySent();
                    UsersMain(CurrentUser);
                    break;
                case 2: DisplayReceived();
                    UsersMain(CurrentUser);
                    break;
                case 3:
                    OnlineShippingLogginMenu();
                    break;
                default:
                    break;
            }
        }

        public void SendPackage(Users CurrentUser)
        {
            Console.CursorVisible = true;

            Console.Write("Who do you want to send a package to? ");
            string ?RecipientName = Console.ReadLine();
            Users RecipientUser  =  UsersList.Find(x => x.Name == RecipientName);

            if (RecipientUser != null) {
                Console.WriteLine($"You are going to send a package to:" +
                    $" {RecipientUser.Name} to the direction: {RecipientUser.Direction}");
                Console.Write("Is this OK? ");
                string ?selection = Console.ReadLine();

                if(selection == null || selection == "no")
                {
                    UsersMain(CurrentUser);
                }
                else
                {
                    Packages packages = new Packages();
                    packages.PackageMain(CurrentUser, RecipientUser, packages);
                }
                
            }
            else
            {
                Console.WriteLine("Not found, please try again");
                Console.ReadKey();
                UsersMain(CurrentUser);
            }
        }
        

        public double CalculateCost(double weigth)
        {
            Founds = Founds - (weigth * 2);

            return weigth * 2;
        }

        public bool DisplaySent()
        {
            if (SentPackages.Count > 0)
            {
                foreach (var sentpackage in SentPackages)
                {
                    Console.WriteLine($"Tracking ID: {sentpackage.TrackingId}");
                    Console.WriteLine($"Object: {sentpackage.PackageObject}");
                    Console.WriteLine($"Description: {sentpackage.Description}");
                    Console.WriteLine($"Recipient: {sentpackage.Recipient}");
                    Console.WriteLine($"Direcction: {sentpackage.PackageDirection}");
                    Console.WriteLine($"Weigth: {sentpackage.Weigth} kg");
                    Console.WriteLine($"Cost: ${sentpackage.TotalCost}");
                }
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("You have not sent any package at the moment");
                Console.ReadKey();
                return false;

            }
            
            
        }
        public bool DisplayReceived()
        {
            if (ReceivedPackages.Count > 0)
            {
                foreach (var receivedpackage in ReceivedPackages)
                {
                    Console.WriteLine($"Tracking ID: {receivedpackage.TrackingId}");
                    Console.WriteLine($"Object: {receivedpackage.PackageObject}");
                    Console.WriteLine($"Description: {receivedpackage.Description}");
                    Console.WriteLine($"Sender: {receivedpackage.Sender}");
                    Console.WriteLine($"Weigth: {receivedpackage.Weigth} kg");
                }
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.WriteLine("You have not received any packages");
                Console.ReadKey();
                return false;

            }
            
            
        }

    }
}
