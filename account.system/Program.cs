namespace account.system
{
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public virtual bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class SavingsAccount : Account
    {
        public SavingsAccount(string Name = "Unnamed Account", double Balance = 0.0, double interestrata = 0) : base(Name, Balance)
        {
            this.interestrata = interestrata;
        }

        double interestrata { get; set; }

    }
    public class CheckingAccount : Account
    {
        public CheckingAccount(string Name = "Unnamed Account", double Balance = 0.0, double fee = 1.50) : base(Name, Balance)
        {
            this.fee = fee;
        }

        public override bool Withdraw(double amount)
        {
            if (amount > 0 && Balance - amount - fee >= 0)
            {
                Balance -= amount + fee;
                return true;
            }
            else
            {
                return false;
            }
        }
        public double fee { get; set; } = 1.50;
    }
    public class TrustAccount : Account
    {
        public TrustAccount(string Name = "Unnamed Account", double Balance = 0.0d, double interestrata =0) : base(Name, Balance)
        {
            
        }
        public override bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else if (amount >= 5000)
            {
                Balance += amount + 50;
                return true;
            }
            else if (amount > 0)
            {
                Balance += amount;
            }
            return true;
        }
        public override bool Withdraw(double amount)
        {
            if (amount < 0)
            {
                return false;
            }
            else if (amount >= (0.2 * Balance))
            {
                return false;
            }
            else if (nwithraw >= 3)
            {
                return false;
            }
            else if (Balance - amount >= 0)
            {
                Balance -= amount;
                nwithraw++;
                return true;
            }
            return true;
        }
        int nwithraw { get; set; }
    }
    public static class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Accounts
            List<Account> accountss = new List<Account>();
            {
                accountss.Add(new Account("Larry"));
                accountss.Add(new Account("Moe", 2000));
                accountss.Add(new Account("Curly", 5000));
                // Savings
                accountss.Add(new SavingsAccount());
                accountss.Add(new SavingsAccount("Superman"));
                accountss.Add(new SavingsAccount("Batman", 2000));
                accountss.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));
                // Checking
                accountss.Add(new CheckingAccount());
                accountss.Add(new CheckingAccount("Larry2"));
                accountss.Add(new CheckingAccount("Moe2", 2000));
                accountss.Add(new CheckingAccount("Curly2", 5000));

                // Trust
                accountss.Add(new TrustAccount());
                accountss.Add(new TrustAccount("Superman2"));
                accountss.Add(new TrustAccount("Batman2", 2000));
                accountss.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));
            }
            AccountUtil.Deposit(accountss, 1000);
            AccountUtil.Withdraw(accountss, 2000);
        }
    }
}
