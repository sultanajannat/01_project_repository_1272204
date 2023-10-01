using _01_project_repository_1272204.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _01_project_repository_1272204.Repositories
{
    public interface IRepository
    {
        IEnumerable<Product> GetAll();

       Product ProductGetById(int ProductId);

        void InsertInfo(Product product);

        void UpdateInfo(Product product);   

        void DeleteInfo(int productId);   
    }
}
