namespace PetAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cartinfo")]
    public partial class cartinfo
    {
        [Key]
        public int cartid { get; set; }

        [Required]
        [StringLength(200)]
        public string cartname { get; set; }

        [Required]
        [StringLength(200)]
        public string cartphoto { get; set; }

        public double cartprice { get; set; }

        public int cartcount { get; set; }

        public int? cid { get; set; }

        public int? useid { get; set; }

        public virtual petInfo petInfo { get; set; }

        public virtual Userr Userr { get; set; }
    }
}
