using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM_ConsApp
{
    public class cardHolder
    {
        String cardNum;
        String firstName;
        String lastName;
        int pin;
        double accBalance;

        //constructor
        public cardHolder(String cardNum, String firstName, String lastName, int pin, double accBalance)
        {
            this.cardNum = cardNum;
            this.firstName = firstName;
            this.lastName = lastName;
            this.pin = pin;
            this.accBalance = accBalance;
        }
        //getters
        public String getCardNum()
        {
            return cardNum;
        }
        public String getFirstName()
        {
            return firstName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public int getPin()
        {
            return pin;
        }
        public double getAccBalance()
        {
            return accBalance;
        }
        //setters
        public void setCardNum(String newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setFirstName(String newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(String newLastName)
        {
            lastName = newLastName;
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setAccBalance(double newAccBalance)
        {
            accBalance = newAccBalance;
        }

        //Main method
        static void Main(string[] args)
        {
            void displayOptions()
            {
                Console.WriteLine("Please select from the following options: ");
                Console.WriteLine("1. Show Balance");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Deposit");
                Console.WriteLine("4. Exit");
            }
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to deposit: ");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setAccBalance(currentUser.getAccBalance() + deposit);
                Console.WriteLine("Thank you for making a deposit! Your new balance is " + currentUser.getAccBalance());
            }
            void withdrawal(cardHolder currentUser)
            {
                Console.WriteLine("How much money would you like to withdraw: ");
                double withdrawal = double.Parse(Console.ReadLine());

                //check if there's enough money in account before withdrawal
                if (currentUser.getAccBalance() < withdrawal)
                {
                    Console.WriteLine("Sorry you have insufficient funds to complete this transaction :<");
                }
                else
                {
                    currentUser.setAccBalance(currentUser.getAccBalance() - withdrawal);
                    Console.WriteLine("Transaction successfully complete :-)");
                }
            }
            void accBalance(cardHolder currentUser)
            {
                Console.WriteLine("Your current balance is: " + currentUser.getAccBalance());
            }

            //object to store sample users
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("123456", "Gisa", "Katji", 1234, 2500.35));
            cardHolders.Add(new cardHolder("654321", "Jane", "Naru", 4321, 5100.75));
            cardHolders.Add(new cardHolder("112233", "Gina", "Tjiveze", 1122, 6200.21));


            // Prompt user input
            Console.WriteLine("*****Welcome to Gisa Corp Bank!*****");
            Console.WriteLine("Please insert your G-Card");
            String debitCardNum;
            cardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //Check against database
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) { break; }
                    else
                    {
                        Console.WriteLine("Sorry this card is not recognized :< Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry this card is not recognized :< Please try again");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin;

            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //Already have a user no need to Check against database
                    if (currentUser.getPin() == userPin) { break; }
                    else
                    {
                        Console.WriteLine("Sorry incorrect pin. Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Sorry incorrect pin. Please try again");
                }
            }
            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;

            do
            {
                displayOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch{ }
                if (option == 1) { accBalance(currentUser); }
                else if (option ==2) { withdrawal(currentUser); }
                else if (option == 3) { deposit(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            }
            while (option != 4);
            {
                Console.WriteLine("Thank you for visiting our atm! Have a nice day! :)");
            }
        }
    }
}
