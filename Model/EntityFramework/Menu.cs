namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [CustomMaxLength(50)]
        public string Text { get; set; }

        [CustomMaxLength(250)]
        public string Link { get; set; }

        public int? DisplayOrder { get; set; }

        [CustomMaxLength(50)]
        public string Target { get; set; }

        public bool Status { get; set; }

        public int? TypeID { get; set; }
    }
}