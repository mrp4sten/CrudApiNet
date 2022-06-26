using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CrudApiSomee.Models
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }

        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Municipalities)
                .WithRequired(e => e.Entity1)
                .HasForeignKey(e => e.entity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entity>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Entity1)
                .HasForeignKey(e => e.entity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipality>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Municipality>()
                .HasMany(e => e.Providers)
                .WithRequired(e => e.Municipality1)
                .HasForeignKey(e => e.municipality)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.location)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Provider>()
                .Property(e => e.rfc)
                .IsUnicode(false);
        }
    }
}
