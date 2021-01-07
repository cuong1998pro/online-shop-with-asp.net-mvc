using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class ProductDAO
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public List<Product> ListAll()
        {
            return db.Products.Where(x => x.Status).ToList();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.Where(x => x.Status).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.Status && x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListAllByCategory(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            var products = db.Products.Where(x => x.CategoryID == id).OrderBy(x => x.CreatedDate);
            totalRecord = products.Count();
            var model = products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }

        public List<Product> ListRelatedProduct(int id)
        {
            var product = db.Products.Find(id);
            return db.Products.Where(x => x.ID != id && x.CategoryID == product.CategoryID).OrderByDescending(x => x.CreatedDate).ToList();
        }
    }
}