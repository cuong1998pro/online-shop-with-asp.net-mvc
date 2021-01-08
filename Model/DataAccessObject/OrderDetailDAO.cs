using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class OrderDetailDAO
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public int Insert(OrderDetail detail)
        {
            db.OrderDetails.Add(detail);
            return db.SaveChanges();
        }
    }
}