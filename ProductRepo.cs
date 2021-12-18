using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
 
namespace CSHARPSQLCRUD
{
    public class ProductRepo
    {
        DbProviderFactory factory;
        string provider;
        string connectionString;
 
        public ProductRepo()
        {
            provider = ConfigurationManager.AppSettings["provider"];
            connectionString = ConfigurationManager.AppSettings["connectionString"];
            factory = DbProviderFactories.GetFactory(provider);
        }
 
 public void Add(Product product)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Insert Into Products (name, description) Values ('{product.name}', '{product.description}');";
                command.ExecuteNonQuery();
            }
        }
        public void Update(Product product)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Update Products Set name = '{product.name}', description = '{product.description}' Where Id = {product.Id};";
                command.ExecuteNonQuery();
            }
        }
 
        public void Delete(int id)
        {
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = $"Delete From Products Where Id = {id};";
                command.ExecuteNonQuery();
            }
        }
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using(var connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                var command = factory.CreateCommand();
                command.Connection = connection;
                command.CommandText = "Select * From Products;";
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Id = (int)reader["Id"],
                            name = (string)reader["name"],
                            description = (string)reader["description"]
                        });
                    }
                }
            }
 
            return products;
        }
    }
}