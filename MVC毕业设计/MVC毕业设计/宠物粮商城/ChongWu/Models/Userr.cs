namespace ChongWu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Userr")]
    public partial class Userr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Userr()
        {
            cartinfo = new HashSet<cartinfo>();
            orderinfo = new HashSet<orderinfo>();
        }

        [Key]
        public int Usid { get; set; }

        [Required]
        [StringLength(200)]
        public string UName { get; set; }

        [StringLength(200)]
        public string Uimg { get; set; }

        [StringLength(20)]
        public string Tel { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(200)]
        public string Pwd { get; set; }

        [StringLength(10)]
        public string sex { get; set; }

        [StringLength(500)]
        public string adress { get; set; }

        [StringLength(100)]
        public string vipcode { get; set; }

        public int? onlinet { get; set; }

        public int? adminpwd { get; set; }

        public int? adminid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderinfo> orderinfo { get; set; }
    }
}
