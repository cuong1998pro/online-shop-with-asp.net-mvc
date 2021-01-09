using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<ProductViewModel> ListAllByCategoryByID(int id, ref int totalRecord, int pageIndex = 1, int pageSize = 10)
        {
            var products = db.Products.Where(x => x.CategoryID == id).OrderBy(x => x.CreatedDate);
            totalRecord = products.Count();
            var model = from a in db.Products
                        join b in db.ProductCategories
                        on a.CategoryID equals b.ID
                        where a.CategoryID == id
                        select new ProductViewModel()
                        {
                            CategoryMetaTitle = b.MetaTitle,
                            CategoryName = b.Name,
                            ID = (int)a.ID,
                            Images = a.Image,
                            Name = a.Name,
                            MetaTitle = a.MetaTitle,
                            Price = a.Price
                        };
            return model.ToList();
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