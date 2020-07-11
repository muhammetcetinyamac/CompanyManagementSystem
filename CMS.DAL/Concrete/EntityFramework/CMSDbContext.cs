using CMS.DAL.Concrete.EntityFramework.Mapping;
using CMS.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DAL.Concrete.EntityFramework
{
    public class CMSDbContext : DbContext
    {
        public CMSDbContext() : base("Server=CETINYAMAC\\SQLEXPRESS; database=CMSDB; uid=sa; pwd=123")
        {
            Database.SetInitializer<CMSDbContext>(new MyStrategy());
            
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Opinions> Opinions { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Petition> Petitions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<VehicleFleet> VehicleFleets { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<JobApplication> jobApplications { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));
            modelBuilder.Configurations.Add(new CategoryMapping());
            modelBuilder.Configurations.Add(new CustomersMapping());
            modelBuilder.Configurations.Add(new EmployeesMapping());
            modelBuilder.Configurations.Add(new MaterialMapping());
            modelBuilder.Configurations.Add(new OpinionsMapping());
            modelBuilder.Configurations.Add(new OrderDetailsMapping());
            modelBuilder.Configurations.Add(new OrdersMapping());
            modelBuilder.Configurations.Add(new PetitionMapping());
            modelBuilder.Configurations.Add(new ProductMapping());
            modelBuilder.Configurations.Add(new ReportMapping());
            modelBuilder.Configurations.Add(new ShippersMapping());
            modelBuilder.Configurations.Add(new SuppliersMapping());
            modelBuilder.Configurations.Add(new TaskMapping());
            modelBuilder.Configurations.Add(new VehicleFleetMapping());
            modelBuilder.Configurations.Add(new WareHouseMapping());
        }
    }
}
