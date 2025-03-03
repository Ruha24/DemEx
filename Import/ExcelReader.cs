using ClosedXML.Excel;
using DemExam.Import;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ExcelReader
{
    public List<ProductType> ReadProductTypes(string filePath)
    {
        var productTypes = new List<ProductType>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                productTypes.Add(new ProductType
                {
                    Name = row.Cell(1).GetString(),
                    Koef = row.Cell(2).GetDouble()
                });
            }
        }
        return productTypes;
    }

    public List<Product> ReadProducts(string filePath)
    {
        var products = new List<Product>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                products.Add(new Product
                {
                    Type = row.Cell(1).GetString(),
                    Name = row.Cell(2).GetString(),
                    Article = row.Cell(3).GetString(),
                    Amount = row.Cell(4).GetDouble()
                });
            }
        }
        return products;
    }

    public List<PartnerType> ReadPartnerTypes(string filePath)
    {
        var partnerTypes = new List<PartnerType>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                partnerTypes.Add(new PartnerType
                {
                    Name = row.Cell(1).GetString()
                });
            }
        }
        return partnerTypes;
    }

    public List<Partner> ReadPartners(string filePath)
    {
        var partners = new List<Partner>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                partners.Add(new Partner
                {
                    Type = row.Cell(1).GetString(),
                    Name = row.Cell(2).GetString(),
                    Director = row.Cell(3).GetString(),
                    Email = row.Cell(4).GetString(),
                    Phone = row.Cell(5).GetString(),
                    Address = row.Cell(6).GetString(),
                    Inn = row.Cell(7).GetValue<long>(),
                    Rating = row.Cell(8).GetValue<int>()
                });
            }
        }
        return partners;
    }

    public List<PartnerProduct> ReadPartnerProducts(string filePath)
    {
        var partnerProducts = new List<PartnerProduct>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                partnerProducts.Add(new PartnerProduct
                {
                    ProductName = row.Cell(1).GetString(),
                    PartnerName = row.Cell(2).GetString(),
                    Amount = row.Cell(3).GetValue<int>(),
                    DateSale = row.Cell(4).GetDateTime()
                });
            }
        }
        return partnerProducts;
    }

    public List<Material> ReadMaterials(string filePath)
    {
        var materials = new List<Material>();
        using (var workbook = new XLWorkbook(filePath))
        {
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RowsUsed();

            foreach (var row in rows.Skip(1))
            {
                materials.Add(new Material
                {
                    Name = row.Cell(1).GetString(),
                    Defect = row.Cell(2).GetDouble()
                });
            }
        }
        return materials;
    }
}
