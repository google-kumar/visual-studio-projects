using BankRepositary;
using BankLibrary;
using System.Data.SqlClient;



namespace Bank_Test
{
    

    
    [TestFixture]
    public class Tests
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static BankRepositary.BankRepositary obj;

        SBAccount sBAccount = new SBAccount();
        SBTransaction sBTransaction = new SBTransaction();

        [SetUp]
        public void Setup()
        {
            obj = new BankRepositary.BankRepositary();
        }

        [Test]
        public void Test_NewAccount()
        {

            int previous = BankRepositary.BankRepositary.Count_SBAccounts();

            obj.NewAccount_UnitTest(sBAccount);

            int now = BankRepositary.BankRepositary.Count_SBAccounts();
            Assert.AreEqual(previous+1, now); 
        }

        [Test]
        public void Test_GetAllAccounts()
        {
            List<SBAccount> SBAccounts_client = new List<SBAccount>();
            SBAccounts_client =obj.GetAllAccounts();
            List<SBAccount> SBAccounts_temp = new List<SBAccount>();
            SBAccounts_temp = null;
            SBAccounts_temp =obj.sql_GetAllAccounts();
            Assert.AreEqual(SBAccounts_temp.Count , SBAccounts_client.Count);
        }

        [Test]
        public void Test_GetTransactions()
        {
            int Flag = 0;
            List<SBTransaction> SBTransactions_client = new List<SBTransaction>();
            SBTransactions_client= obj.GetTransactions(5555555555);
            List<SBTransaction> SBTransactions_client1 = new List<SBTransaction>();
            List<SBTransaction> SBTransactions_client2 = new List<SBTransaction>();
            SBTransactions_client1 = obj.sql_GetTransactions();

            if (SBTransactions_client1 != null)
            {
                foreach (SBTransaction item in SBTransactions_client1)
                {
                    if (item.accountnumber == 5555555555)
                    {
                        SBTransactions_client2.Add(item);
                        Flag= 1;
                    }
                }
                if (Flag == 0)
                    SBTransactions_client2 = null;
            }
            Assert.AreEqual(SBTransactions_client,SBTransactions_client2);
            Assert.AreEqual(BankRepositary.BankRepositary.Count_SBTransactions(),BankRepositary.BankRepositary.Count_deposits()+BankRepositary.BankRepositary.Count_withdrawals());
        }

        [Test]
        public void Test_GetAccountDetails()
        {
           
            int Flag = 0;
            List<SBAccount> SBAccounts_temp = new List<SBAccount>();
            
            SBAccounts_temp =obj.sql_GetAllAccounts();

            foreach (SBAccount item in SBAccounts_temp)
            {
                if (item.accountnumber == 5555545555)
                {
                    Flag = 1;
                }
            }
            Assert.AreEqual(Flag,0);
            
            SBAccount sbi = obj.GetAccountDetails(9999999999);
            Assert.AreEqual(sbi, null);
        }

        [Test]
        public void Test_WithdrawAmount()
        {
            List<SBTransaction> SBTransactions_client1 = new List<SBTransaction>();
            List<SBTransaction> SBTransactions_client2 = new List<SBTransaction>();
            SBTransactions_client1 = obj.sql_GetTransactions();
            obj.WithdrawAmount(1000000002,500);
            SBTransactions_client2=obj.sql_GetTransactions();
            Assert.AreEqual(SBTransactions_client1.Count, SBTransactions_client2.Count);

            //BankRepositary.BankRepositary.Count_withdrawals=BankRepositary.cou
        }

        [Test]
        public void Test_DepositAmount()
        {
            List<SBTransaction> SBTransactions_client1 = new List<SBTransaction>();
            List<SBTransaction> SBTransactions_client2 = new List<SBTransaction>();
            SBTransactions_client1 = obj.sql_GetTransactions();
            obj.DepositAmount(1000000003, 500);
            SBTransactions_client2 = obj.sql_GetTransactions();
            Assert.AreEqual(SBTransactions_client1.Count, SBTransactions_client2.Count);
        }


        public static SqlConnection getcon()
        {
            con = new SqlConnection("Data Source=.;Initial Catalog=eurofins;Integrated Security=true");
            con.Open();
            return con;
        }
    }
}