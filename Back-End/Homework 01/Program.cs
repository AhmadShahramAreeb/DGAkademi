using System;

namespace _1st__HomeWork__CreditCard
{   
    class CreditCard
    {
        private string number;
        private string holderName;
        private string expireDate;
        private string cvv;
        

        public CreditCard()
        {


            Console.Write("  Please Enter Card Number Without Any Space: ");
            string testNumber = Console.ReadLine();
            try
            {
                CardNumberCheck(testNumber);
            }
            catch (CreditCardException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }


            Console.Write("  Please Enter Cardholder Full Name : ");
            string testholderName = Console.ReadLine();

            try
            {
                CardholderNameCheck(testholderName);
            }
            catch (CreditCardException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }

            Console.Write("  Please Enter Credit Card Expiration Date ( Example: MM/YY )  : ");
            string testExpireDate = Console.ReadLine();
            try
            {
                expireDateCheck(testExpireDate);
            }
            catch (CreditCardException exception)
            {
                Console.WriteLine(exception.Message);
                return;
            }
            
            Console.Write("  Pleas Enter the CVV : ");
            string testCvv=Console.ReadLine();
            this.cvv = testCvv;

        }

        private void expireDateCheck(string testExpireDate)
        {
            string[] separate = testExpireDate.Split('/');
            long month = Convert.ToInt64(separate[0]);
            long year = Convert.ToInt64(separate[1]);
            //Console.WriteLine(month + year);  use for testing month and year data type

            if ((year <= 21) || (month <= 07 || month>12))
            {
                throw new CreditCardException("\n  Wrong Date Entered , The Card Expiration Date at Least Should Be August of 2022 !");

            }
            else
            {
                this.expireDate = testExpireDate;
            }
        }

        private void CardholderNameCheck(string testholderName)
        {
            if (testholderName == "")
            {
                throw new CreditCardException("  Cardholder Name Can not be empty!");
            }
            else
            {
                this.holderName = testholderName;
            }
        }

        private void CardNumberCheck(string testNumber)
        {
            if (testNumber.Length != 16)
            {
                throw new CreditCardException("\n  Attention : Card Number Should be 16 digit !");
                
            }
            else
            {
                this.number = testNumber;
            }
        }
        public string getInfos()
        {
            return "  Credit Card Number: " + number + "\n  Cardholder:" + holderName +
                "\n  Expire Date:"+expireDate+"\n  CVV:"+cvv;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditcard = new CreditCard();


            Console.WriteLine("\n***********************************************************************************");

            Console.WriteLine(creditcard.getInfos());
            
        }
    }
}
