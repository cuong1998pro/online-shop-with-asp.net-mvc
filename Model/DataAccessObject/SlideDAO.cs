using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccessObject
{
    public class SlideDAO
    {
        private OnlineShopDbContext db = new OnlineShopDbContext();

        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}