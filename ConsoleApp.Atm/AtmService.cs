namespace ConsoleApp.MiniAtm;

public class AtmService
{
    private readonly Dictionary<string, UserAccountDto> accounts;

    public AtmService(Dictionary<string, UserAccountDto> accounts)
    {
        this.accounts = accounts;
    }

    public UserAccountDto Login(string cardNumber, int pin)
    {
        if (!accounts.ContainsKey(cardNumber))
        {
            return null;
        }

        UserAccountDto user = accounts[cardNumber];
        if (user.VerifyPin(pin))
        {
            return new UserAccountDto(user.Name, user.CardNumber, user.Pin, user.Balance);
        }
        else
        {
            return null;
        }
    }

    // Implement other ATM functionalities like withdrawal (placeholder for now)
    public void WithdrawCash(string cardNumber, decimal amount)
    {
        Console.WriteLine("Withdrawal functionality not yet implemented.");
    }

    public static void CreateInitialAccount(Dictionary<string, UserAccountDto> accounts)
    {
        Console.WriteLine("No accounts found. Please create an initial account.");

        Console.WriteLine("Enter your card number: ");
        string cardNumber = Console.ReadLine()!;

        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine()!;

        Console.WriteLine("Enter your PIN (4 digits): ");
        int pin = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your initial balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

        accounts.Add(cardNumber, new UserAccountDto(name, cardNumber, pin, balance));
        Console.WriteLine("Initial account created successfully!");
    }

    public void Login()
    {
        bool isLoggedIn = false;
        string currentCardNumber = "";

        while (!isLoggedIn)
        {
            Console.WriteLine("Enter your card number: ");
            string enteredCardNumber = Console.ReadLine()!;
            Console.WriteLine("Enter your pin: ");

            UserAccountDto userDto = Login(enteredCardNumber, Convert.ToInt32(Console.ReadLine()));

            if (userDto != null)
            {
                currentCardNumber = userDto.CardNumber;
                isLoggedIn = true;
                AtmMenu(currentCardNumber, userDto); // Pass UserAccountDto to AtmMenu
            }
            else
            {
                Console.WriteLine("Invalid card number or PIN. Please try again.");
            }
        }
    }

    public void AtmMenu(string currentCardNumber, UserAccountDto userAccount)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nATM Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Cash");
            Console.WriteLine("3. Deposit Cash");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"\nYour current balance is: ${userAccount.Balance}");
                    break;
                case 2:
                    Console.WriteLine("Enter amount to withdraw: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    if (userAccount.WithdrawCash(withdrawAmount))
                    {
                        Console.WriteLine($"\n${withdrawAmount} has been dispensed.");
                    }
                    else
                    {
                        Console.WriteLine("Withdrawal failed. Please check your balance and try again.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter amount to deposit: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    if (userAccount.DepositCash(depositAmount))
                    {
                        Console.WriteLine($"\n${depositAmount} has been dispensed.");
                    }
                    else
                    {
                        Console.WriteLine("Deposit failed. Please try again.");
                    }
                    break;
                case 4:
                    isRunning = false;
                    Console.WriteLine("\nThank you for using our ATM. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}