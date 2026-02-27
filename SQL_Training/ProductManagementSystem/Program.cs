using System;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString =
        "Server=ANURAG_BHARDWAJ\\SQLEXPRESS;Database=ProductDB;Trusted_Connection=True;TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCT MANAGEMENT SYSTEM ===");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Insert New Product");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Search Product by ID");
            Console.WriteLine("6. Search Product by Category");
            Console.WriteLine("7. Sort Products by Price");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                continue;
            }

            switch (choice)
            {
                case 1: ViewProducts(); break;
                case 2: InsertProduct(); break;
                case 3: UpdateProduct(); break;
                case 4: DeleteProduct(); break;
                case 5: SearchById(); break;
                case 6: SearchByCategory(); break;
                case 7: SortProducts(); break;
                case 8: return;
                default: Console.WriteLine("Invalid Choice"); break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    // 1. VIEW ALL PRODUCTS
    static void ViewProducts()
    {
        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand("SELECT * FROM Products1", con);

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\nID\tName\tCategory\tPrice\tQty");
        while (dr.Read())
        {
            Console.WriteLine($"{dr["ProductId"]}\t{dr["Name"]}\t{dr["Category"]}\t{dr["Price"]}\t{dr["Quantity"]}");
        }
    }

    // 2. INSERT PRODUCT
    static void InsertProduct()
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Category: ");
        string category = Console.ReadLine();

        Console.Write("Price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "INSERT INTO Products1 (Name, Category, Price, Quantity) VALUES (@n,@c,@p,@q)", con);

        cmd.Parameters.AddWithValue("@n", name);
        cmd.Parameters.AddWithValue("@c", category);
        cmd.Parameters.AddWithValue("@p", price);
        cmd.Parameters.AddWithValue("@q", qty);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Product Inserted Successfully!");
    }

    // 3. UPDATE PRODUCT
    static void UpdateProduct()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("New Price: ");
        decimal price = Convert.ToDecimal(Console.ReadLine());

        Console.Write("New Quantity: ");
        int qty = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "UPDATE Products1 SET Price=@p, Quantity=@q WHERE ProductId=@id", con);

        cmd.Parameters.AddWithValue("@p", price);
        cmd.Parameters.AddWithValue("@q", qty);
        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Product Updated!" : "Product Not Found!");
    }

    // 4. DELETE PRODUCT
    static void DeleteProduct()
    {
        Console.Write("Enter Product ID to delete: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "DELETE FROM Products1 WHERE ProductId=@id", con);

        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        int rows = cmd.ExecuteNonQuery();

        Console.WriteLine(rows > 0 ? "Product Deleted!" : "Product Not Found!");
    }

    // 5. SEARCH BY ID
    static void SearchById()
    {
        Console.Write("Enter Product ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Products1 WHERE ProductId=@id", con);

        cmd.Parameters.AddWithValue("@id", id);

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.Read())
        {
            Console.WriteLine($"Name: {dr["Name"]}");
            Console.WriteLine($"Category: {dr["Category"]}");
            Console.WriteLine($"Price: {dr["Price"]}");
            Console.WriteLine($"Quantity: {dr["Quantity"]}");
        }
        else
        {
            Console.WriteLine("Product Not Found!");
        }
    }

    // 6. SEARCH BY CATEGORY
    static void SearchByCategory()
    {
        Console.Write("Enter Category: ");
        string category = Console.ReadLine();

        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Products1 WHERE Category=@c", con);

        cmd.Parameters.AddWithValue("@c", category);

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\nID\tName\tPrice\tQty");
        while (dr.Read())
        {
            Console.WriteLine($"{dr["ProductId"]}\t{dr["Name"]}\t{dr["Price"]}\t{dr["Quantity"]}");
        }
    }

    // 7. SORT PRODUCTS
    static void SortProducts()
    {
        using SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(
            "SELECT * FROM Products1 ORDER BY Price ASC", con);

        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();

        Console.WriteLine("\nID\tName\tPrice");
        while (dr.Read())
        {
            Console.WriteLine($"{dr["ProductId"]}\t{dr["Name"]}\t{dr["Price"]}");
        }
    }
}