namespace PetAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("guangaoinfo")]
    public partial class guangaoinfo
    {
        [Key]
        public int Gid { get; set; }

        [Required]
        [StringLength(200)]
        public string Gimg { get; set; }

        [Required]
        [StringLength(200)]
        public string GName { get; set; }

        [Required]
        [StringLength(200)]
        public string Gzhekou { get; set; }

        public int Gbiaoshi { get; set; }
    }
}
