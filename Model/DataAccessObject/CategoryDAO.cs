using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Model.DataAccessObject
{
    public class CategoryDAO
    {
        public IEnumerable<Category> ListAllByPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = DataAccess.Db.Categories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MetaTitle.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Category> ListAll()
        {
            return DataAccess.Db.Categories.Where(x => x.Status).ToList();
        }
    }
}