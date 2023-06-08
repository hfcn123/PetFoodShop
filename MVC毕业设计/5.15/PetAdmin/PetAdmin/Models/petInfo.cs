namespace PetAdmin.Models
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

        [Display(Name = "编号")]
        [Key]
        public int Cid { get; set; }
        [Display(Name = "商品图片")]
        [Required]
        [StringLength(200)]
        public string Cphoto { get; set; }
        [Display(Name = "商品名称")]
        [Required]
        [StringLength(200)]
        [MaxLength(10, ErrorMessage = "商品名称最多10个字")]
        public string Cname { get; set; }
        [Display(Name = "商品单价")]
        [Required]
        public double Cprice { get; set; }
        [Display(Name = "商品描述")]
        [Required]
        [StringLength(100)]
        [MaxLength(50, ErrorMessage = "商品名称最多50个字")]
        public string CDescription { get; set; }
        [Display(Name = "商品评价")]
        [StringLength(200)]
        [MaxLength(50, ErrorMessage = "商品名称最多50个字")]
        public string CReviews { get; set; }
        [Display(Name = "商品标签")]
        [StringLength(100)]
        public string CTags { get; set; }
        [Display(Name = "商品收藏")]
        public int? ISHeart { get; set; }
        [Display(Name = "商品状态")]
        public int? Ctype { get; set; }
        [Display(Name = "商品种类")]
        public int? PetID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        public virtual pettype pettype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<single_product> single_product { get; set; }
    }
}
