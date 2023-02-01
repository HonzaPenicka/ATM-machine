using System;

public class cardHolder
{
    String firstName;

    String lastName;

    String cardNumber;

    int pin;

    double cashBalance { get; set; }


    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double cashBalance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.cashBalance = cashBalance;
    }

    public String GetCardNum()
    {
        return cardNumber;
    }

    public int GetPIN()
    {
        return pin;
    }

    public String GetFirstName()
    {
        return firstName;
    }

    public String GetLastName()
    {
        return lastName;
    }

    public double GetCashBal()
    {
        return cashBalance;
    }

    public String SetCardNum(String newCardNum)
    {
        return newCardNum;
    }

    public int SetPIN(int newPin)
    {
        return newPin;
    }

    public String SetFirstName(String newFirstName)
    {
        return newFirstName;
    }

    public String SetLastName(String newLastName)
    {
        return newLastName;
    }

    public double SetCashBal(double newSetCashBal)
    {
        return newSetCashBal;
    }

    public static void Main(string[]args)
    {
        void printOptions()
        {
            Console.WriteLine("Select one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("2. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.SetCashBal(deposit);
            Console.WriteLine("Thank you for yout cash. Your new balance is: " + currentUser.GetCashBal());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdraw = double.Parse(Console.ReadLine());
            //Check if user has enought money on bankaccount
            if (currentUser.GetCashBal() > withdraw)
            {
                Console.WriteLine("Insufficient cash-balance...");
            }
            else
            {
                currentUser.SetCashBal(currentUser.GetCashBal() - withdraw);
                Console.WriteLine("Withdraw your money. Thank you.");
            }
        }

        void balance(cardHolder currentHolder)
        {
            Console.WriteLine("Your current balance is: " + currentHolder.GetCashBal());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1000 1000 1000 1000", 1111, "Jonah", "Obr", 3219.93));
        cardHolders.Add(new cardHolder("2345 1237 2345 1000", 9090, "Emil", "Holub", 89.99));
        cardHolders.Add(new cardHolder("9878 2322 8888 9878", 9922, "Jonah", "Obr", -902.22));
        cardHolders.Add(new cardHolder("7777 2231 6767 1567", 3678, "Frank", "Oneil", 23.98));
        cardHolders.Add(new cardHolder("8900 7733 3333 2890", 8902, "Luis", "Bun", 190.09));
        cardHolders.Add(new cardHolder("0902 8902 2398 9022", 2239, "Steve", "Ming", 20983.34));

        //Prompt user
        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card.");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //Check against our "db"
                currentUser = cardHolders.FirstOrDefault(c => c.cardNumber == debitCardNum);
                if(currentUser != null) { break; }
                else
                {
                    Console.WriteLine("Card is not recognized. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Card is not recognized. Please try again.");
            }
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //Check against our "db"
                if (currentUser.GetPIN() == userPin) { break; }
                else
                {
                    Console.WriteLine("Incorrect PIN. Please try again.");
                }
            }
            catch
            {
                Console.WriteLine("Incorrect PIN. Please try again.");
            }
        }
        Console.WriteLine("Welcome " + currentUser.GetFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you and have a nice day!");
    }
}