using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAccount
{

    internal class SBAccountClassClient
    {
      public static void main()
        {
            SBAccountClass sB = new SBAccountClass(); 
            SBAccountClass sB1 = new SBAccountClass(); 
            SBAccountClass sB2 = new SBAccountClass(); 
            SBAccountClass sB3 = new SBAccountClass(8878788,"KrishnaPrasad","Debit"); 
            SBAccountClass sB4 = new SBAccountClass(2045784, "Ramakrishnan", "Credit", new DateOnly(2018, 05, 04), 55000); 
            sB2.Acno = -9999999999;
            sB3.doc = new DateOnly(2015 , 07 , 23);
            sB3.Bal = 50000;
            sB.ShowAccountDetails(); //default class arguments using blank constructor
            sB1.GetAccountDetails(); //read's class variables using inbuit function.
            sB1.ShowAccountDetails(); 
            sB2.ShowAccountDetails(); //default class arguments using constructor and set commands
            sB3.ShowAccountDetails(); //class arguments using parameterised constructor and get commands
            sB4.ShowAccountDetails(); //class arguments completely using parameterised constructor 
        }
    }
}
