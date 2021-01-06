using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class ProductCategoryDAO
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status).OrderBy(x => x.DisplayOrder).ToList();
        }

        public ProductCategory ViewDetail(int id)
        {
            return DataAccess.Db.ProductCategories.Find(id);
        }
    }
}