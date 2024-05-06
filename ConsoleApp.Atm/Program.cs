WelcomeUser();

Dictionary<string, UserAccountDto> accounts = GetAccounts(); // Get accounts (replace with actual data loading)
if (accounts.Count == 0)
{
    SeedAccounts(accounts);
    //AtmService.CreateInitialAccount(accounts); // Create initial account if none exist
}

AtmService atmService = new AtmService(accounts);
atmService.Login();

static void WelcomeUser()
{
    Console.WriteLine("Welcome to the ATM!");
}

static Dictionary<string, UserAccountDto> GetAccounts()
{
    return new Dictionary<string, UserAccountDto>();
}

static void SeedAccounts(Dictionary<string, UserAccountDto> accounts)
{
    accounts.Add("00000000101", new UserAccountDto("John Doe", "00000000101", 1234, 1000.00m));
    accounts.Add("00000000102", new UserAccountDto("Jane Smith", "00000000102", 5678, 500.00m));
    // Add more accounts as needed
}

