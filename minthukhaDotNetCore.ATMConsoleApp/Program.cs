public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double blance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double blance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.blance = blance;
    }

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public double getBlance()
    {
        return blance;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBlance(double newBlance)
    {
        blance = newBlance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options!");
            Console.WriteLine("1 Deposit");
            Console.WriteLine("2 Withdraw");
            Console.WriteLine("3 Show Balance");
            Console.WriteLine("4 Exit");
        }

        void deposite(cardHolder curentUser)
        {
            Console.WriteLine("How much woudl you like to deposite?");
            double deposite = Double.Parse(Console.ReadLine()!);
            curentUser.setBlance(deposite);
            Console.WriteLine("Thanks you for your deposite.Your balance is " + curentUser.getBlance());
        }

        void withdrawal(cardHolder curentUser)
        {
            Console.WriteLine("How much woudl you like to withdrawal?");
            double withdrawal = Double.Parse(Console.ReadLine()!);

            if (curentUser.getBlance() < withdrawal)
            {
                Console.WriteLine("Balance is not enough for withdrawal....!");
            }
            else
            {
                curentUser.setBlance(curentUser.getBlance() - withdrawal);
                Console.WriteLine("Withdrawal finish.Thanks you...");
            }
        }

        void balance(cardHolder curentUser)
        {
            Console.WriteLine("Curent blance: " + curentUser.getBlance());
        }

        List<cardHolder> chrdHolders = new List<cardHolder>();
        chrdHolders.Add(new cardHolder("82886284443243", 1312, "James", "Hannry", 233.21));
        chrdHolders.Add(new cardHolder("42876284443243", 1371, "Thomas", "Libo", 753.23));
        chrdHolders.Add(new cardHolder("62876284443243", 1371, "Lie", "Stan", 353.41));
        chrdHolders.Add(new cardHolder("32846284443243", 6311, "Harn", "yanm", 753.54));
        chrdHolders.Add(new cardHolder("32746284443243", 4311, "James", "Jon", 533.82));

        Console.WriteLine("Welcome to ATM");
        Console.WriteLine("Please insert your debit card no. :");

        string debitCardNum = "";
        cardHolder currnetUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine()!;
                currnetUser = chrdHolders.FirstOrDefault(a => a.cardNum == debitCardNum)!;
                if (currnetUser != null)
                { break; }
                else { Console.WriteLine("Card is not recognized.Please try again!"); }
            }
            catch
            {
                Console.WriteLine("Card is not recognized.Please try again!");
            }
        }

        Console.WriteLine("Please enter your pin:");
        int usesrPin = 0;
        int maxAttempts = 3;
        int incorrectAttempts = 0;

        while (true)
        {
            try
            {
                usesrPin = int.Parse(Console.ReadLine()!);
                if (currnetUser.getPin() == usesrPin) { break; }
                incorrectAttempts++;
                Console.WriteLine($"Wrong pin. {maxAttempts - incorrectAttempts} attempts remaining. Please try again!");
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a numeric pin.");
            }
            if (incorrectAttempts == maxAttempts)
            {
                Console.WriteLine("Too many incorrect attempts. Your account is locked.");
                return;
            }
        }

        Console.WriteLine("Welcome" + currnetUser.getFirstName());
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine()!);
            }
            catch { }
            if (option == 1) { deposite(currnetUser); }
            else if (option == 2) { withdrawal(currnetUser); }
            else if (option == 3) { balance(currnetUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thanks you.Have a nice day");
    }
}