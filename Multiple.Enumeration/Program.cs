using System.Data;
using Bogus;
using Dapper;
using Microsoft.Data.Sqlite;
using Multiple.Enumeration;

using var connection = GetDataBaseConnection();
SeedTestDatabase(connection);

Console.WriteLine("Messing around with the IEnumerable...");
var products = GetProducts(connection);

products = products.OrderBy(x =>
{
  Console.WriteLine($"Sorting by Name: {x}");
  return x.Name;
}).ThenBy(x =>
{
  Console.WriteLine($"Sorting by Price: {x}");
  return x.Price;
}).Select(x =>
{
  Console.WriteLine($"Increasing price by 10%: {x}");
  x.Price += x.Price * 0.1;
  return x;
});

Console.WriteLine("Iterating over it...");
foreach (var product in products)
{
  Console.WriteLine($"{product.Name} - {product.Price:C}");
}

Console.WriteLine("Again...");
foreach (var product in products)
{
  Console.WriteLine($"{product.Name} - {product.Price:C}");
}

return;

IEnumerable<Product> GetProducts(IDbConnection conn)
{
  using var reader = conn.ExecuteReader("SELECT * FROM Products");
  while (reader.Read())
  {
    var fetchedProduct = new Product
    {
      Id = reader.GetInt32(0),
      Name = reader.GetString(1),
      Price = reader.GetDouble(2)
    }; 
    
    Console.WriteLine($"Fetched from DB: {fetchedProduct}");
    yield return fetchedProduct;
  }
}

IDbConnection GetDataBaseConnection()
{
  var connection = new SqliteConnection("Data Source=:memory:");
  connection.Open();
  return connection;
}

void SeedTestDatabase(IDbConnection connection1)
{
  // Create the Products table.
  connection1.Execute("""
CREATE TABLE Products (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Price REAL NOT NULL
);
""");

  var faker = new Faker<Product>()
    .RuleFor(x => x.Name, f => f.Company.CompanyName())
    .RuleFor(x => x.Price, f => f.Random.Double(10, 100));

// Seed the database with fake product data.
  foreach (var product in faker.Generate(3))
  {
    connection1.Execute("INSERT INTO Products (Name, Price) VALUES (@Name, @Price);", product);
  }
}
