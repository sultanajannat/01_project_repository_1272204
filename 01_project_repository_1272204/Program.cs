using _01_project_repository_1272204.Model;
using _01_project_repository_1272204.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_project_repository_1272204
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayProduct();
            Console.ReadKey();  
        }
        public static void DisplayProduct()
        {
            Console.WriteLine("Press (1) To Show All Products");
            Console.WriteLine("Press (2) To Insert Product Information");
            Console.WriteLine("Press (3) To Update Product Information");
            Console.WriteLine("Press(4) To Delete Product Information");

            var index=int.Parse(Console.ReadLine());

            Show(index);
        }
        public static void Show(int index)
        {
            ProductRepo productRepo= new ProductRepo();

            if(index==1)
            {
                var productList = productRepo.GetAll();
                if(productList.Count()==0)
                {
                    Console.WriteLine("=========================");
                    Console.WriteLine("No Information Found");
                    Console.WriteLine("==========================");
                    DisplayProduct();
                }
                else 
                {
                    foreach(var items in productRepo.GetAll())
                    {
                        Console.WriteLine($"Product Id is: {items.ProductId}, Product Name is:{items.ProductName}, Product Price is: {items.Price}, Product Quantity : {items.Quantity}, product Category is:{items.ProductCategory} ");

                    }
                    Console.WriteLine("=============================");
                    DisplayProduct();   
                }
            }
            else if(index==2)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Product Name:");
                string name=Console.ReadLine();

                Console.WriteLine("Product Price:");
                double price=double.Parse(Console.ReadLine());

                Console.WriteLine("Product Quantity:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Product Category:");
                string category=Console.ReadLine(); 

                int maxId=productRepo.GetAll().Any() ? productRepo.GetAll().Max(x=>x.ProductId) : 0;

                Product product = new Product
                {
                    ProductId = maxId + 1,
                    ProductName= name,  
                    Price=price,
                    Quantity=quantity,
                    ProductCategory=category    
                };
                productRepo.InsertInfo(product);
                Console.WriteLine("Data Insertes Successfully  ");
                Console.WriteLine("=============================");
                DisplayProduct();   
            }
            else if(index==3)
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Enter Product Id to Update:  ");
                int id=int.Parse(Console.ReadLine());   

                var _product=productRepo.ProductGetById(id);

                if(_product == null ) 
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("Product Id is invalid!!!");
                    Console.WriteLine("======================");
                    DisplayProduct();
                }
                else
                {
                    Console.WriteLine($"Update info for Product Id :{id}");
                    Console.WriteLine("==================================");
                    Console.WriteLine("Product Name :");
                    string name=Console.ReadLine();

                    Console.WriteLine("product Price :");
                    double price=double.Parse(Console.ReadLine());

                    Console.WriteLine("product Quantity: ");
                    int quantity=int.Parse(Console.ReadLine());

                    Console.WriteLine("Product Category");
                    string category=Console.ReadLine();
                    Product product = new Product
                    {
                        ProductId=id,
                        ProductName=name,   
                        Price=price,    
                        Quantity=quantity,  
                        ProductCategory=category    
                    };
                    productRepo.UpdateInfo(product);
                    Console.WriteLine("Data Updated Sucessfully");
                    Console.WriteLine("========================");
                    DisplayProduct();   
                }
            }
            else if(index==4) 
            {
                Console.WriteLine("===============================");
                Console.WriteLine("Enter Product Id To delete: ");
                int id=int.Parse(Console.ReadLine()) ;

                var _product =productRepo.ProductGetById(id);

                if(_product == null )
                {
                    Console.WriteLine("==============================");
                    Console.WriteLine("Product Id is Invalid");
                    Console.WriteLine("================================");
                    DisplayProduct();   
                }
                else
                {
                    productRepo.DeleteInfo(id);
                    Console.WriteLine("Data Deleted Sucessfully");
                    Console.WriteLine("===========================");
                    DisplayProduct();
                }
            }
        }
    }
}
