namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductViewModel
    {
        public int ID { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public decimal? Price { get; set; }

        public string CategoryName { get; set; }

        public string CategoryMetaTitle { get; set; }

        public string MetaTitle { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Description { get; set; }
    }
}
