namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SystemConfig")]
    public partial class SystemConfig
    {
        [CustomMaxLength(50)]
        public string ID { get; set; }

        [CustomMaxLength(50)]
        public string Name { get; set; }

        [CustomMaxLength(50)]
        public string Type { get; set; }

        [CustomMaxLength(50)]
        public string Value { get; set; }

        public bool Status { get; set; }
    }
}
