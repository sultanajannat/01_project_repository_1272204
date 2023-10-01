using _01_project_repository_1272204.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_project_repository_1272204.Repositories
{
    public class ProductRepo : IRepository
    {
        //interface implementation
        public void DeleteInfo(int productId)
        {
            Product product=ProductDB.ProductList.FirstOrDefault(x => x.ProductId == productId); 
            ProductDB.ProductList.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductDB.ProductList;   
        }

        public void InsertInfo(Product product)
        {
            ProductDB.ProductList.Add(product); 
        }

        public Product ProductGetById(int ProductId)
        {
            Product product = ProductDB.ProductList.FirstOrDefault(x => x.ProductId == ProductId);
            return product; 

        }

        public void UpdateInfo(Product product)
        {
            Product _product = ProductDB.ProductList.FirstOrDefault(x => x.ProductId == product.ProductId);
            if(product.ProductName!=null)
            {
                _product.ProductName= product.ProductName;  
            }
            if(product.Quantity !=0)
            {
                _product.Quantity= product.Quantity;    
            }
            if(product.ProductCategory !=null)
            {
                _product.ProductCategory= product.ProductCategory;
            }
            if(product.Price !=0)
            {
                _product.Price= product.Price;  
            }

        }
    }
}
