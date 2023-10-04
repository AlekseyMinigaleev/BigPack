using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BigPack.Db
{
    public partial class BigPackDbContext : DbContext
    {
        public BigPackDbContext()
            : base("name=BigPackDbContext")
        {
        }

        public virtual DbSet<AgentModel> Agents { get; set; }
        public virtual DbSet<AgentPriorityHistoryModel> AgentPriorityHistorys { get; set; }
        public virtual DbSet<AgentTypeModel> AgentTypes { get; set; }
        public virtual DbSet<MaterialModel> Materials { get; set; }
        public virtual DbSet<MaterialCountHistory> MaterialCountHistorys { get; set; }
        public virtual DbSet<MaterialTypeModel> MaterialTypes { get; set; }
        public virtual DbSet<ProductModel> Products { get; set; }
        public virtual DbSet<ProductCostHistoryModel> ProductCostHistorys { get; set; }
        public virtual DbSet<ProductMaterialModel> ProductMaterials { get; set; }
        public virtual DbSet<ProductSaleModel> ProductSales { get; set; }
        public virtual DbSet<ProductTypeModel> ProductTypes { get; set; }
        public virtual DbSet<ShopModel> Shops { get; set; }
        public virtual DbSet<SupplierModel> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentModel>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<AgentModel>()
                .Property(e => e.KPP)
                .IsUnicode(false);

            modelBuilder.Entity<AgentModel>()
                .HasMany(e => e.AgentPriorityHistory)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AgentModel>()
                .HasMany(e => e.ProductSale)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AgentModel>()
                .HasMany(e => e.Shop)
                .WithRequired(e => e.Agent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AgentTypeModel>()
                .HasMany(e => e.Agent)
                .WithRequired(e => e.AgentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialModel>()
                .Property(e => e.Cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(e => e.MaterialCountHistories)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(e => e.ProductMaterials)
                .WithRequired(e => e.Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaterialModel>()
                .HasMany(e => e.Suppliers)
                .WithMany(e => e.Materials)
                .Map(m => m.ToTable("MaterialSupplier").MapLeftKey("MaterialID").MapRightKey("SupplierID"));

            modelBuilder.Entity<MaterialTypeModel>()
                .HasMany(e => e.Materials)
                .WithRequired(e => e.MaterialType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .Property(e => e.MinCostForAgent)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.ProductCostHistory)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.ProductMaterial)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductModel>()
                .HasMany(e => e.ProductSale)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCostHistoryModel>()
                .Property(e => e.CostValue)
                .HasPrecision(10, 2);
        }
    }
}
