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

        public Product ViewDetail(int id)
        {
            return db.Products.Find(id);
        }
    }
}