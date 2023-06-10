namespace RegisterPerson
{
    internal class User
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {
        }
        public User(string fullName, string userName, string password, string phoneNumber)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public void Options()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n    -------Available operations-------\n");
            Console.WriteLine("1.Sign in          2.Login in          3.Delete user\n");

           
                Console.Write("Choose operation number : ");
                int operationNumber = int.Parse(Console.ReadLine());
                int count = 3;
            //Console.Clear();
            switch (operationNumber)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3: 
                         DeleteUser(); 
                         break;
                    default:
                    Console.Write("Enter operation number in correct format !");
                    Console.ReadKey();
                           Options();
                           break;
                } 
        }
        public void CreateUser()
        {
            try
            {
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter Full Name : ");
                string fullName = Console.ReadLine();

                Console.Write("Enter User Name : ");
                string userName = Console.ReadLine();

                Console.Write("Enter Password : ");
                string password = Console.ReadLine();

                Console.Write("Enter Phone Number : +998");
                string phoneNumber = Console.ReadLine();

                string path1 = Path.Combine($@"C:\Register\{userName + password}.txt");

                if (File.Exists(path1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This account is already registered!");
                    IsContinue();
                }
                else
                {
                    File.Create(path1).Close();
                    using (StreamWriter sw = new StreamWriter(path1))
                    {
                        sw.WriteLine($"User Name : {userName}");
                        sw.WriteLine($"Full Name : {fullName}");
                        sw.WriteLine($"Phone Number  : {phoneNumber}");
                        sw.WriteLine($"Password : {password}");
                        Console.WriteLine("\nUser created successfully!");
                        IsContinue();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter information into correct format!");
                Console.ForegroundColor = ConsoleColor.Green;
                CreateUser();
            }

            string path = Path.Combine($"C:\\Register\\{Password}.txt");

            if (Directory.Exists(path))
            {
                Console.WriteLine("This user is already available!");
                IsContinue();
            }
            else
            {
                File.Create(path);
            }
        }

        public void Login()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            string account = userName + password;

            string path = $@"C:\Register\{account}.txt";

            if (File.Exists(path))
            {
                string fileContents = File.ReadAllText(path);
                Console.WriteLine(fileContents);
                IsContinue();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such account exists");
                Thread.Sleep(300);
                IsContinue();
            }
        }
        public void IsContinue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Do you want continue ?");
            Console.WriteLine("1.Yes           2.No");
            string continueOption = Console.ReadLine();

            if (continueOption is "yes" || continueOption is "1")
            {
                Console.Clear();
                Options();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Thank you!");
            }
        }

        public void DeleteUser()
        {
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("Enter User name: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Password : ");
            string password = Console.ReadLine();

            string account = userName + password;

            string path = $@"C:\Register\{account}.txt";

            if (File.Exists(path))
            {
                Console.Clear();
                string fileContents = File.ReadAllText(path);
                Console.WriteLine(fileContents);

                File.Delete(path);
                Console.WriteLine("User deleted succesfully.");
                Thread.Sleep(500);
               
                IsContinue();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such account exists");
                Thread.Sleep(3000);
                IsContinue();
            }
        }
    }
}


