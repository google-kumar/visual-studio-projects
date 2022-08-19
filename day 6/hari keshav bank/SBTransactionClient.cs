using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBAccount
{

    internal class SBTransactionClassClient
    {
      public static void Main()
        {
            SBTransactionClass sB = new SBTransactionClass();
            SBTransactionClass sB1 = new SBTransactionClass();
            SBTransactionClass sB2 = new SBTransactionClass();
            SBTransactionClass sB3 = new SBTransactionClass(3, 8878788, 500);
            SBTransactionClass sB4 = new SBTransactionClass(4,7845785,700,new DateOnly(2022,08,22),75000);
            sB2.TId = -4;
            sB2.Tno = -9999999999;
            sB2.Tamt = -790;
            sB3.tdate = new DateOnly(2015 , 07 , 23);
            sB3.Nbal = 50000;
            sB.ShowTransactionDetails(); //default class arguments using blank constructor
            sB1.GetTransactionDetails(); //read's class variables using inbuit function.
            sB1.ShowTransactionDetails(); 
            sB2.ShowTransactionDetails(); //default class arguments using constructor and set commands
            sB3.ShowTransactionDetails(); //class arguments using parameterised constructor and get commands
            sB4.ShowTransactionDetails(); //class arguments completely using parameterised constructor 
        }
    }
}
