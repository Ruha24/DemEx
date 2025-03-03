using DemExam.Model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace DemExam.Controller
{
    public class DatabaseController
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=Partner;Username=postgres;Password=admin";

        private readonly NpgsqlConnection _connector;

        public DatabaseController() {
            _connector = new NpgsqlConnection(_connectionString);

            _connector.Open();
        }

        public List<Partner> GetAllPartners()
        {
            var partners = new List<Partner>();

            using(var command = new NpgsqlCommand("Select * from partner", _connector))
            {
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var partner = new Partner
                        {
                            Type = GetPartnerTypeById(reader.GetInt16(1)),
                            Name = reader.GetString(2),
                            Director = reader.GetString(3),
                            Email = reader.GetString(4),
                            Phone = reader.GetString(5),
                            Rating = reader.GetInt16(8)
                        };

                        partners.Add(partner);
                    }
                }
            }

            return partners;
        }

        public List<Product> GetProductPartner(string name)
        {
            List<Product> products = new List<Product>();

            using(var command = new NpgsqlCommand("Select * from partner_product where namePartner = @n", _connector))
            {
                command.Parameters.AddWithValue("@n", name);

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var product = new Product
                        {
                            Name = reader.GetString(2),
                            Count = reader.GetInt32(3),
                            DateTime = reader.GetDateTime(4)
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public void UpdatePartner(Partner partner)
        {
            using (var command = new NpgsqlCommand(
                   "UPDATE partner SET " +
                   "partner_type = @partner_type, " +
                   "director = @director, " +
                   "email = @email, " +
                   "phone = @phone, " +
                   "address = @address, " +
                   "inn = @inn, " +
                   "rating = @rating " +
                   "WHERE name = @name", _connector))
            {
                command.Parameters.AddWithValue("@partner_type", GetPartnerTypeIdByName(partner.Type));
                command.Parameters.AddWithValue("@director", partner.Director);
                command.Parameters.AddWithValue("@email", partner.Email);
                command.Parameters.AddWithValue("@phone", partner.Phone);
                command.Parameters.AddWithValue("@address", "Адрес");
                command.Parameters.AddWithValue("@inn", 1234567890);
                command.Parameters.AddWithValue("@rating", partner.Rating);
                command.Parameters.AddWithValue("@name", partner.Name);

                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        private int GetPartnerTypeIdByName(string partnerTypeName)
        {
            using (var command = new NpgsqlCommand(
                "SELECT id FROM partner_type WHERE name = @n", _connector))
            {
                command.Parameters.AddWithValue("@n", partnerTypeName);

                var result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }

            return -1;
        }

        private string GetPartnerTypeById(int partnerTypeId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("select name from partner_type where id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", partnerTypeId);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToString(result);
                    }
                }
            }

            return "";
        }


        public void AddPartner(Partner partner)
        {
            using (var command = new NpgsqlCommand(
                 "INSERT INTO partner (partner_type, name, director, email, phone, address, inn, rating) " +
                 "VALUES (@partner_type, @name, @director, @email, @phone, @address, @inn, @rating)", _connector))
            {
                command.Parameters.AddWithValue("@partner_type", GetPartnerTypeIdByName(partner.Type));
                command.Parameters.AddWithValue("@name", partner.Name);
                command.Parameters.AddWithValue("@director", partner.Director);
                command.Parameters.AddWithValue("@email", partner.Email);
                command.Parameters.AddWithValue("@phone", partner.Phone);
                command.Parameters.AddWithValue("@address", "Адрес");
                command.Parameters.AddWithValue("@inn", 1234567890);
                command.Parameters.AddWithValue("@rating", partner.Rating);

                command.ExecuteNonQuery();
            }
        }

        public List<PartnerType> GetPartnerTypes()
        {
            var partners = new List<PartnerType>();

            using(var command = new NpgsqlCommand("select * from partner_type", _connector))
            {
                using(var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var partnerType = new PartnerType
                        {
                            Name = reader.GetString(1)
                        };

                        partners.Add(partnerType);
                    }
                }
            }

            return partners;
        }

        public void AddProduct(Product product)
        {
            using (var command = new NpgsqlCommand(
                      "INSERT INTO product (product_type_id, name, article, amount) " +
                      "VALUES (@product_type_id, @name, @article, @amount)", _connector))
            {
                command.Parameters.AddWithValue("@product_type_id", 1);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@article", product.Article);
                command.Parameters.AddWithValue("@amount", product.Count);

                command.ExecuteNonQuery();
            }
        }

    }
}
