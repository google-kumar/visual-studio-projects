


namespace first_MVC_App.Models
{
    public class pen
    {
        public int penId { get; set; }
        public string penName { get; set; } 
        public int penPrice { get; set; }

        public static List<pen> pens = new List<pen>();

        public pen() { }

        public pen(int p, string pname, int price)
        {
            penId = p;
            penName = pname;
            penPrice = price;
        }

        public static List<pen> GetAllPens()
        {
            pens.Add(new pen(1,"apsara",30));
            pens.Add(new pen(2, "natraj", 50));
            return pens;
        }
    }
}
