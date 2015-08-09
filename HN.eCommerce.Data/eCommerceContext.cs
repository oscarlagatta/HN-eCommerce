using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.Serialization;
using HN.eCommerce.Business.Entities;
using Core.Common.Contracts;

namespace HN.eCommerce.Data
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext()
            : base("name=eCommerceDb")
        {
            Database.SetInitializer<eCommerceContext>(null);
        }

        public DbSet<Product> ProductSet { get; set; }
        public DbSet<Account> AccountSet { get; set; }
        public DbSet<Style> StyleSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Style>().HasKey<int>(e => e.MerretStyleID).Ignore(e => e.EntityId);
            modelBuilder.Entity<Product>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
        }
    }
}