namespace ChongWu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orderinfo")]
    public partial class orderinfo
    {
        [Key]
        public int ordid { get; set; }

        public int ordhao { get; set; }

        [Required]
        [StringLength(100)]
        public string ordName { get; set; }

        public int ordcount { get; set; }

        public double ordprice { get; set; }

        public double ordcprice { get; set; }

        public int? usid { get; set; }

        public virtual Userr Userr { get; set; }
    }
}
