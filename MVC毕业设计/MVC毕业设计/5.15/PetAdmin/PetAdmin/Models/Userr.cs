namespace PetAdmin.Models
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
        [Display(Name ="用户编号")]
        public int Usid { get; set; }
        [Display(Name = "用户名")]
        [MaxLength(10,ErrorMessage ="用户名最多10个字符")]
        [Required]
        [StringLength(200)]
        public string UName { get; set; }
        [Display(Name = "用户头像")]
        [StringLength(200)]
        public string Uimg { get; set; }
        [Display(Name = "手机号")]
        [StringLength(20)]
        public string Tel { get; set; }
        [Display(Name = "邮箱")]
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Display(Name = "密码")]
        [Required]
       
        [StringLength(200)]
        public string Pwd { get; set; }
        [Display(Name = "性别")]
        [StringLength(10)]
        public string sex { get; set; }
        [Display(Name = "地址")]
        [StringLength(500)]
        public string adress { get; set; }
        [Display(Name = "优惠卷Code")]
        [StringLength(100)]
        public string vipcode { get; set; }
        [Display(Name = "在线状态")]
        public int? onlinet { get; set; }
        [Display(Name = "管理员密码")]
        public int? adminpwd { get; set; }
        [Display(Name = "是否是管理员")]
        public int? adminid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderinfo> orderinfo { get; set; }
    }
}
