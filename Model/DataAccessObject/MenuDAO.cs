using Model.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace Model.DataAccessObject
{
    public class MenuDAO
    {
        private OnlineShopDbContext db = DataAccess.Db;

        public List<Menu> ListByGroupId(int groupID)
        {
            return db.Menus.Where(x => x.TypeID == groupID && x.Status).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}