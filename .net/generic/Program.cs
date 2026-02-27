

// .......... Generics in C# ..........


// using System;
// using GenericDemo;
// namespace GenericDemo
// {
//     class UsingGenerics<T>
//     {
//         T obj;
//         public UsingGenerics(T obj1)
//         {
//             this.obj = obj1;
//         }
//         public T Get()
//         {
//             return obj;
//         }
//         public void ShowType()
//         {
//             Console.WriteLine("Type of T is: "+typeof(T));
//         }
//     }
// }
// class TestGenerics
// {
//     public static void Main(string[] args)
//     {
//         UsingGenerics<int> objdata;
//         objdata = new UsingGenerics<int>(100);
//         objdata.ShowType();
//         UsingGenerics<string> objdatastr;
//         objdatastr= new UsingGenerics<string>("Hello");
//         objdatastr.ShowType();
//     }
// }



// ........... Product Catalog using Generics ............


// using System;
// using System.Collections.Generic;

// namespace ProductDemo
// {
//     public class Product
//     {
//         public int Id { get; set; }
//         public string Name { get; set; }
//         public string Description { get; set; }
//         public double Price { get; set; }
//         public bool IsStock { get; set; }


//         public Product(int id, string name, string description, double price, bool isStock)
//         {
//             Id = id;
//             Name = name;
//             Description = description;
//             Price = price;
//             IsStock = isStock;
//         }
//     }

//     public class ProductCatalog
//     {
//         private List<Product> products;

//         public ProductCatalog()
//         {
//             products = new List<Product>();

//             products.Add(new Product(8, "Laptop", "Electronics", 75000, true));
//             products.Add(new Product(9, "SmartPhone", "Electronics", 55000, true));
//             products.Add(new Product(10, "Desk", "Furniture", 15000, true));
//             products.Add(new Product(11, "Notebook", "Stationary", 750, true));
//         }

//         public void DisplayProducts()
//         {
//             foreach (var product in products)
//             {
//                 Console.WriteLine($"Name: {product.Name}");
//                 Console.WriteLine($"Category: {product.Description}");
//                 Console.WriteLine($"Price: {product.Price}");
//                 Console.WriteLine($"In Stock: {product.IsStock}");
//                 Console.WriteLine("----------------------");
//             }
//         }
//     }

//     class TestProduct
//     {
//         static void Main(string[] args)
//         {
//             ProductCatalog catalog = new ProductCatalog();
//             catalog.DisplayProducts();
//         }
//     }
// }




// ........... Product Catalog using Generics with CRUD operations ............




using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
namespace ProductDemo{
    public class Product{
        public int Id { get; set;}
        public string Name { get; set;}
        public string Description { get; set;}
        public double Price { get; set;}
        public bool IsStock { get; set;}
    }
    public class ProductCatalog{
        private List<Product> products;
        public ProductCatalog(){
            // products = new List<Product>{
            //     new Product{Id = 008, Name = "Laptop", Description = "Electronics", Price = 75000, IsStock = true},
            //     new Product{Id = 009, Name = "SmartPhone", Description = "Electronics", Price = 55000, IsStock = true},
            //     new Product{Id = 010, Name = "Desk", Description = "Furniture", Price = 15000, IsStock = true},
            //     new Product{Id = 011, Name = "Notebook", Description = "Stationary", Price = 750, IsStock = true}                  
            // };
            products = new List<Product>();

        }
        public void AddProduct(){
            Product product = new Product();
            Console.WriteLine("Enter Product ID : ");
            product.Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Product Name : ");
            product.Name = Console.ReadLine();

            Console.WriteLine("Enter Product Description : ");
            product.Description = Console.ReadLine();

            Console.WriteLine("Enter Product Price : ");
            product.Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Product IsStock : ");
            product.IsStock = Convert.ToBoolean(Console.ReadLine());

            products.Add(product);
        }
        public bool DeleteProduct(int id){
            var productid = products.FirstOrDefault(p => p.Id == id);
            if(productid == null){
                return false;
                products.Remove(productid);
                return true;
            }
            return true;
        }
        public void DisplayProducts(){
            foreach(var product in products){
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Description);
                Console.WriteLine(product.Price);
                Console.WriteLine("-------------------------");
            }
        }
    }
    class TestProduct{
        static void Main(string[] args){
            ProductCatalog catalog = new ProductCatalog();
            int choice;
            int id;
            do{
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("Enter your Choice!");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice){
                    case 0: Console.WriteLine("Exiting ...............");
                            break;
                    case 1: catalog.AddProduct();
                            break;
                    case 2: catalog.DisplayProducts();
                            break;
                    case 3: id = Convert.ToInt32(Console.ReadLine());
                            catalog.DeleteProduct(id);
                            break;
                    default: Console.WriteLine("Invalid Choice!");
                            break;
                }
            }while(choice != 3);
            // catalog.AddProduct();
            // catalog.DisplayProducts();
        }
    }
}