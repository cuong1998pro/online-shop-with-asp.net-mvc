namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tag")]
    public partial class Tag
    {
        [CustomMaxLength(50)]
        public string ID { get; set; }

        [CustomMaxLength(50)]
        public string Name { get; set; }
    }
}