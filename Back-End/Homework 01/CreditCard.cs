using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardHomework
{
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
