namespace ChongWu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("petInfo")]
    public partial class petInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public petInfo()
        {
            cartinfo = new HashSet<cartinfo>();
            single_product = new HashSet<single_product>();
        }

        [Key]
        public int Cid { get; set; }

        [Required]
        [StringLength(200)]
        public string Cphoto { get; set; }

        [Required]
        [StringLength(200)]
        public string Cname { get; set; }

        public double Cprice { get; set; }

        [Required]
        [StringLength(100)]
        public string CDescription { get; set; }

        [StringLength(200)]
        public string CReviews { get; set; }

        [StringLength(100)]
        public string CTags { get; set; }

        public int? ISHeart { get; set; }

        public int? Ctype { get; set; }

        public int? PetID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        public virtual pettype pettype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<single_product> single_product { get; set; }
    }
}
