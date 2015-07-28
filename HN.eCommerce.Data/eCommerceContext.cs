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
        public DbSet<ResourceMaster> ResourceMasterSet { get; set; }
        public DbSet<CultureCountryCode> CultureCountryCodeSet { get; set; }
        public DbSet<Account> AccountSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Product>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
            modelBuilder.Entity<ResourceMaster>().HasKey<int>(e => e.ResourceId).Ignore(e => e.EntityId);
            modelBuilder.Entity<CultureCountryCode>().HasKey<int>(e => e.Id).Ignore(e => e.EntityId);
            modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
        }
    }
}