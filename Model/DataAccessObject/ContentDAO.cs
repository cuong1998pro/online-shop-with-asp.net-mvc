using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Model.EntityFramework;
using X.PagedList;

namespace Model.DataAccessObject
{
    public class ContentDAO
    {
        public IEnumerable<Model.EntityFramework.Content> ListAllByPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Model.EntityFramework.Content> model = DataAccess.Db.Contents;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MetaTitle.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public IEnumerable<Model.EntityFramework.Content> ListAll()
        {
            return DataAccess.Db.Contents.Where(x => x.Status).ToList();
        }

        public Model.EntityFramework.Content GetByID(int id)
        {
            return DataAccess.Db.Contents.Find(id);
        }

        public int Insert(Model.EntityFramework.Content newContent)
        {
            newContent.CreatedDate = DateTime.Now;
            newContent.CreatedBy = HttpContext.Current.User.Identity.Name.ToString();
            DataAccess.Db.Contents.Add(newContent);

            return DataAccess.Db.SaveChanges();
        }

        public int Update(Model.EntityFramework.Content edited)
        {
            var content = DataAccess.Db.Contents.Find(edited.ID);
            var createdDate = content.CreatedDate.ToString();
            var createdBy = content.CreatedBy.ToString();

            DataAccess.Db.Entry(content).CurrentValues.SetValues(edited);
            content.CreatedDate = DateTime.Parse(createdDate);
            content.CreatedBy = createdBy;
            content.ModifiedDate = DateTime.Now;
            content.ModifiedBy = HttpContext.Current.User.Identity.Name.ToString();
            return DataAccess.Db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = DataAccess.Db.Contents.Find(id);
            DataAccess.Db.Contents.Remove(user);
            DataAccess.Db.SaveChanges();
        }
    }
}