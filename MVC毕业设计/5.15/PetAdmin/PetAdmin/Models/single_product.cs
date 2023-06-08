namespace PetAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class single_product
    {
        public int id { get; set; }

        [Required]
        [StringLength(200)]
        public string picture { get; set; }

        [Required]
        [StringLength(200)]
        public string picture1 { get; set; }

        [Required]
        [StringLength(200)]
        public string picture2 { get; set; }

        [Required]
        [StringLength(200)]
        public string picture3 { get; set; }

        public int? Cid { get; set; }

        public int typeid { get; set; }

        public virtual petInfo petInfo { get; set; }
    }
}
