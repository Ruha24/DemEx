using System;

namespace DemExam.Import
{   
    public class ProductType
    {
        public string Name { get; set; }
        public double Koef { get; set; }
    }

    public class Product
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public double Amount { get; set; }
    }

    public class PartnerType
    {
        public string Name { get; set; }
    }

    public class Partner
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long Inn { get; set; }
        public int Rating { get; set; }
    }

    public class PartnerProduct
    {
        public string ProductName { get; set; }
        public string PartnerName { get; set; }
        public int Amount { get; set; }
        public DateTime DateSale { get; set; }
    }

    public class Material
    {
        public string Name { get; set; }
        public double Defect { get; set; }
    }

}
