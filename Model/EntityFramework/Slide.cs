namespace Model.EntityFramework
{
    using Model.Content;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int ID { get; set; }

        [CustomMaxLength(250)]
        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        [CustomMaxLength(250)]
        public string Link { get; set; }

        [CustomMaxLength(50)]
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        [CustomMaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [CustomMaxLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}