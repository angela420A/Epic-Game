namespace EpicGameLibrary.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EGContext : DbContext
    {
        public EGContext()
            : base("name=EGContext1")
        {
        }

        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Editions> Editions { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<N_Img> N_Img { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<P_Img> P_Img { get; set; }
        public virtual DbSet<Pack> Pack { get; set; }
        public virtual DbSet<Produuct> Produuct { get; set; }
        public virtual DbSet<Specifications> Specifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Editions>()
                .Property(e => e.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<N_Img>()
                .HasMany(e => e.News)
                .WithRequired(e => e.N_Img)
                .HasForeignKey(e => e.Img_List)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<P_Img>()
                .HasMany(e => e.Produuct)
                .WithRequired(e => e.P_Img)
                .HasForeignKey(e => e.Img_ListID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pack>()
                .Property(e => e.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Pack>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Pack)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .Property(e => e.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Comment)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Editions)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Follow)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Library)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Pack)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produuct>()
                .HasMany(e => e.Specifications)
                .WithRequired(e => e.Produuct)
                .WillCascadeOnDelete(false);
        }
    }
}
