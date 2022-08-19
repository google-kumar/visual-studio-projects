using NUnit.Framework;
using CalculatorPrj;
using Moq;

namespace CalciTest
{
    [TestFixture]
    public class Tests
    {
        public static ICalculator Iobj;
        public Emp emp;
        public static Mock<ICalculator> MockCalci;

        [SetUp]
        public void Setup()
        {
            Iobj = new Calci();
            emp = new Emp();
            MockCalci = new Mock<ICalculator>();    
        }

        [Test]
        public void TestAddMethod()
        {
            int actualres = Iobj.add(10, 2);
            int expectedres = 12;
            Assert.AreEqual(expectedres, actualres);
        }

        [Test]
        public void subTest()
        {
            int actualres = Iobj.sub(10, 2);
            int expectedres = 8;
            Assert.AreEqual(expectedres, actualres);
        }

        [Test]
        public void agePassTest()
        {
            bool actualres = Iobj.checkAge(22);
            bool expectedres = true;
            Assert.AreEqual(expectedres, actualres);
        }

        [Test]
        public void ageFailTest()
        {
            bool actualres = Iobj.checkAge(15);
            bool expectedres = false;
            Assert.AreEqual(expectedres, actualres);
        }

        [Test]
        public void empTest()
        {
            var emplis = emp.AddEmployeeData();
            int actualres = emplis.Count;
            int expectedres = 4;
            Assert.AreEqual(expectedres, actualres);
        }

        [Test]
        public void GetAllEmployeesTest()
        {
            List<Emp> actualres = emp.AddEmployeeData();
            Emp obj = new Emp();
            foreach (var item in actualres)
            {
               
                obj.eid = item.eid;
                obj.ename = item.ename;
                obj.sal = item.sal;
            }
            float expsal = 64000;
            Assert.AreEqual(expsal,obj.sal);
        }
        [Test]

        public void TestValiddadamethod()
        { 
            MockCalci.Setup(x => x.checkAge(19)).Returns(true);
            int actres = Iobj.validdata();
            int expres = 10;
            Assert.AreEqual(expres, actres);
        }

        //[Test]
        //public void ValiddataMethodTest()
        //{
        //    mockcalci.Setup(x => x.checkAge(19)).Returns(true);
        //}
    }
}