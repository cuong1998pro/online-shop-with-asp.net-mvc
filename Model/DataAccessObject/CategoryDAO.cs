using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public int Insert(Category newCategory)
        {
            DataAccess.Db.Categories.Add(newCategory);
            return DataAccess.Db.SaveChanges();
        }

        public int Update(Category edited)
        {
            var category = DataAccess.Db.Categories.Find(edited.ID);
            var createdDate = category.CreatedDate.ToString();
            var createdBy = category.CreatedBy.ToString();

            DataAccess.Db.Entry(category).CurrentValues.SetValues(edited);
            category.CreatedDate = DateTime.Parse(createdDate);
            category.CreatedBy = createdBy;
            category.ModifiedDate = DateTime.Now;
            category.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();
            return DataAccess.Db.SaveChanges();
        }
    }
}