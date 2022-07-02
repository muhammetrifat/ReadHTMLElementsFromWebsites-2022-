using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class TrendyolDB : DbContext
    {
        public TrendyolDB()
               : base(@"data source=DESKTOP-H56L443\SQLEXPRESS;initial catalog=TrendyolDB;persist security info=True;user id=sa;password=1234;MultipleActiveResultSets=True;")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TabMenu> TabMenus { get; set; }
        public DbSet<MenuHeader> MenuHeaders { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCampaign> ProductCampaigns { get; set; }
        public DbSet<ProgramLog> ProgramLogs { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
