namespace ConsoleApp.MiniAtm;

public class UserAccountDto
{
    public string Name { get; private set; }
    public int Pin { get; private set; }
    public decimal Balance { get; private set; }
    public string CardNumber { get; private set; }

    public UserAccountDto(string name, string cardNumber, int pin, decimal balance)
    {
        Name = name;
        CardNumber = cardNumber;
        Pin = pin;
        Balance = balance;
    }

    public bool VerifyPin(int enteredPin)
    {
        return Pin == enteredPin;
    }

    public bool WithdrawCash(decimal amount)
    {
        if (amount > Balance)
        {
            return false; // Insufficient funds
        }

        Balance -= amount;
        return true; // Successful withdrawal
    }

    public bool DepositCash(decimal amount)
    {
        Balance += amount;
        return true;
    }
}