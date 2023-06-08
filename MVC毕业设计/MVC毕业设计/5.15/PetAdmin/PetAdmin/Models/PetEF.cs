namespace PetAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PetEF : DbContext
    {
        public PetEF()
            : base("name=PetEF")
        {
        }

        public virtual DbSet<cartinfo> cartinfo { get; set; }
        public virtual DbSet<guangaoinfo> guangaoinfo { get; set; }
        public virtual DbSet<orderinfo> orderinfo { get; set; }
        public virtual DbSet<petInfo> petInfo { get; set; }
        public virtual DbSet<pettype> pettype { get; set; }
        public virtual DbSet<single_product> single_product { get; set; }
        public virtual DbSet<Userr> Userr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cartinfo>()
                .Property(e => e.cartname)
                .IsUnicode(false);

            modelBuilder.Entity<cartinfo>()
                .Property(e => e.cartphoto)
                .IsUnicode(false);

            modelBuilder.Entity<guangaoinfo>()
                .Property(e => e.Gimg)
                .IsUnicode(false);

            modelBuilder.Entity<guangaoinfo>()
                .Property(e => e.GName)
                .IsUnicode(false);

            modelBuilder.Entity<guangaoinfo>()
                .Property(e => e.Gzhekou)
                .IsUnicode(false);

            modelBuilder.Entity<orderinfo>()
                .Property(e => e.ordName)
                .IsUnicode(false);

            modelBuilder.Entity<petInfo>()
                .Property(e => e.Cphoto)
                .IsUnicode(false);

            modelBuilder.Entity<petInfo>()
                .Property(e => e.Cname)
                .IsUnicode(false);

            modelBuilder.Entity<petInfo>()
                .Property(e => e.CDescription)
                .IsUnicode(false);

            modelBuilder.Entity<petInfo>()
                .Property(e => e.CReviews)
                .IsUnicode(false);

            modelBuilder.Entity<petInfo>()
                .Property(e => e.CTags)
                .IsUnicode(false);

            modelBuilder.Entity<pettype>()
                .Property(e => e.PetName)
                .IsUnicode(false);

            modelBuilder.Entity<single_product>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<single_product>()
                .Property(e => e.picture1)
                .IsUnicode(false);

            modelBuilder.Entity<single_product>()
                .Property(e => e.picture2)
                .IsUnicode(false);

            modelBuilder.Entity<single_product>()
                .Property(e => e.picture3)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.UName)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.Uimg)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.Pwd)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.sex)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.adress)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .Property(e => e.vipcode)
                .IsUnicode(false);

            modelBuilder.Entity<Userr>()
                .HasMany(e => e.cartinfo)
                .WithOptional(e => e.Userr)
                .HasForeignKey(e => e.useid);
        }
    }
}
