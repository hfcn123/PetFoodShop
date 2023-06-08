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

        [Display(Name = "���")]
        [Key]
        public int Cid { get; set; }
        [Display(Name = "��ƷͼƬ")]
        [Required]
        [StringLength(200)]
        public string Cphoto { get; set; }
        [Display(Name = "��Ʒ����")]
        [Required]
        [StringLength(200)]
        [MaxLength(10, ErrorMessage = "��Ʒ�������10����")]
        public string Cname { get; set; }
        [Display(Name = "��Ʒ����")]
        [Required]
        public double Cprice { get; set; }
        [Display(Name = "��Ʒ����")]
        [Required]
        [StringLength(100)]
        [MaxLength(50, ErrorMessage = "��Ʒ�������50����")]
        public string CDescription { get; set; }
        [Display(Name = "��Ʒ����")]
        [StringLength(200)]
        [MaxLength(50, ErrorMessage = "��Ʒ�������50����")]
        public string CReviews { get; set; }
        [Display(Name = "��Ʒ��ǩ")]
        [StringLength(100)]
        public string CTags { get; set; }
        [Display(Name = "��Ʒ�ղ�")]
        public int? ISHeart { get; set; }
        [Display(Name = "��Ʒ״̬")]
        public int? Ctype { get; set; }
        [Display(Name = "��Ʒ����")]
        public int? PetID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        public virtual pettype pettype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<single_product> single_product { get; set; }
    }
}
