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
        [Display(Name ="�û����")]
        public int Usid { get; set; }
        [Display(Name = "�û���")]
        [MaxLength(10,ErrorMessage ="�û������10���ַ�")]
        [Required]
        [StringLength(200)]
        public string UName { get; set; }
        [Display(Name = "�û�ͷ��")]
        [StringLength(200)]
        public string Uimg { get; set; }
        [Display(Name = "�ֻ���")]
        [StringLength(20)]
        public string Tel { get; set; }
        [Display(Name = "����")]
        [Required]
        [StringLength(100)]
        public string email { get; set; }
        [Display(Name = "����")]
        [Required]
       
        [StringLength(200)]
        public string Pwd { get; set; }
        [Display(Name = "�Ա�")]
        [StringLength(10)]
        public string sex { get; set; }
        [Display(Name = "��ַ")]
        [StringLength(500)]
        public string adress { get; set; }
        [Display(Name = "�Żݾ�Code")]
        [StringLength(100)]
        public string vipcode { get; set; }
        [Display(Name = "����״̬")]
        public int? onlinet { get; set; }
        [Display(Name = "����Ա����")]
        public int? adminpwd { get; set; }
        [Display(Name = "�Ƿ��ǹ���Ա")]
        public int? adminid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cartinfo> cartinfo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderinfo> orderinfo { get; set; }
    }
}
