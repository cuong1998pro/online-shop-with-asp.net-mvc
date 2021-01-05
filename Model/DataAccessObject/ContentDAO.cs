using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}