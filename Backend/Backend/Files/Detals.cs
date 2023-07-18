
namespace Backend.Files

{

    public class Customer
    {
        public int CId { get; set; }
        public string? CName { get; set; }
        public string? Mobile { get; set; }



    }

    public class Bill
    {
        public int InvoiceNo { get; set;}
        public int QTY { get; set;}
        public float TotalPrice { get; set;}



    }

    public class Goods
    {
        public int Gid { get; set; }
        public String? GName { get; set;}
        public float GPrice { get; set;}


    }


}
