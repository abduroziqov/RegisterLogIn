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

        public void Options()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-------Available operations-------\n");
            Console.WriteLine("1.Sign in          2.Login in \n");

            try
            {
                Console.Write("Choose operation number : ");
                int operationNumber = int.Parse(Console.ReadLine());

                switch (operationNumber)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        Login();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write("Enter operation number in correct format !");
                Options();
            }
        }

        public void CreateUser()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
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
                }
                else
                {
                    File.Create(path1).Close();
                    using (StreamWriter sw = new StreamWriter(path1))
                    {
                        sw.WriteLine("User Name : " + userName);
                        sw.WriteLine("Full Name : " + fullName);
                        sw.WriteLine("Phone Number  : " + phoneNumber);
                        sw.WriteLine("Password : " + password);
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
            finally
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User created successfully!");
                Console.ForegroundColor = ConsoleColor.Green;
                IsContinue();
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

        public static void Login()
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

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No such account exists");
                Login();
                Thread.Sleep(1000);
            }
        }
        public void IsContinue()
        {
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
    }
}


