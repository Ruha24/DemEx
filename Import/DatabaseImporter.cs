using DemExam.Import;
using Npgsql;
using System.Collections.Generic;

public class DatabaseImporter
{
    private readonly string _connectionString = "Host=localhost;Port=5432;Database=Partner;Username=postgres;Password=admin";

    public DatabaseImporter()
    {
    }

    public void ImportProductTypes(List<ProductType> productTypes)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var productType in productTypes)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO product_type (name, koef) VALUES (@name, @koef)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", productType.Name);
                    cmd.Parameters.AddWithValue("@koef", productType.Koef);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void ImportProducts(List<Product> products)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var product in products)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO product (product_type_id, name, article, amount) " +
                    "VALUES ((SELECT id FROM product_type WHERE name = @type), @name, @article, @amount)", conn))
                {
                    cmd.Parameters.AddWithValue("@type", product.Type);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@article", product.Article);
                    cmd.Parameters.AddWithValue("@amount", product.Amount);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void ImportPartnerTypes(List<PartnerType> partnerTypes)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var partnerType in partnerTypes)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO partner_type (name) VALUES (@name)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", partnerType.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void ImportPartners(List<Partner> partners)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var partner in partners)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO partner (partner_type, name, director, email, phone, address, inn, rating) " +
                    "VALUES ((SELECT id FROM partner_type WHERE name = @type), @name, @director, @email, @phone, @address, @inn, @rating)", conn))
                {
                    cmd.Parameters.AddWithValue("@type", partner.Type);
                    cmd.Parameters.AddWithValue("@name", partner.Name);
                    cmd.Parameters.AddWithValue("@director", partner.Director);
                    cmd.Parameters.AddWithValue("@email", partner.Email);
                    cmd.Parameters.AddWithValue("@phone", partner.Phone);
                    cmd.Parameters.AddWithValue("@address", partner.Address);
                    cmd.Parameters.AddWithValue("@inn", partner.Inn);
                    cmd.Parameters.AddWithValue("@rating", partner.Rating);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void ImportPartnerProducts(List<PartnerProduct> partnerProducts)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var partnerProduct in partnerProducts)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO partner_product (namePartner, name, amount, dateSale) " +
                    "VALUES (@namePartner, @name, @amount, @dateSale)", conn))
                {
                    cmd.Parameters.AddWithValue("@namePartner", partnerProduct.PartnerName);
                    cmd.Parameters.AddWithValue("@name", partnerProduct.ProductName);
                    cmd.Parameters.AddWithValue("@amount", partnerProduct.Amount);
                    cmd.Parameters.AddWithValue("@dateSale", partnerProduct.DateSale);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public void ImportMaterials(List<Material> materials)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            foreach (var material in materials)
            {
                using (var cmd = new NpgsqlCommand(
                    "INSERT INTO material (name, defect) VALUES (@name, @defect)", conn))
                {
                    cmd.Parameters.AddWithValue("@name", material.Name);
                    cmd.Parameters.AddWithValue("@defect", material.Defect);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}