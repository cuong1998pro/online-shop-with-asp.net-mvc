using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class FooterDAO
    {
        private OnlineShopDbContext db = DataAccess.Db;

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.ID == "footer" && x.Status == true);
        }
    }
}