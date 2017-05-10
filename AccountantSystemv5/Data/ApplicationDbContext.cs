using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;

namespace AccountantSystemv5.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //C 8 vs 9
        //SaleOrder vs Inventory 
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        //Sale vs Inventory
        public DbSet<Sale> Sales { get; set; }

        //PurchaseOrder VS Inventory
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        //Purchase vs Inventory
        public DbSet<Purchase> Purchases { get; set; }


        // C10
        //WorkSchedule vs LaborType vs Labor Acquistion 
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<LaborType> LaborTypes { get; set; }
        public DbSet<LaborAcquisition> LaborAcquistions { get; set; }
        // WorkSchedule vs Employee 
        public DbSet<Employee> Employees { get; set; }






        protected override void OnModelCreating(ModelBuilder modeBuilder)
        {
            base.OnModelCreating(modeBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //1-1 CD-FLACD
            modeBuilder.Entity<FulfillmentLACD>()
                .HasOne(p => p.CashDisbursement)
                .WithOne(i => i.FulfillmentLACD)
                .HasForeignKey<CashDisbursement>(b => b.InventoryReceiptID);

            //1-1 CD-FSSCD
            modeBuilder.Entity<FulfillmentSSCD>()
                .HasOne(p => p.CashDisbursement)
                .WithOne(i => i.FulfillmentSSCD)
                .HasForeignKey<CashDisbursement>(b => b.InventoryReceiptID);

            //1-1 CR-SS
            modeBuilder.Entity<StockSubscription>()
                .HasOne(p => p.CashReceipt)
                .WithOne(i => i.StockSubscription)
                .HasForeignKey<CashReceipt>(b => b.InvoiceID);

            //1-1 CR-LA
            modeBuilder.Entity<LoanAgreement>()
                .HasOne(p => p.CashReceipt)
                .WithOne(i => i.LoanAgreement)
                .HasForeignKey<CashReceipt>(b => b.InvoiceID);

            //1-1 CD-employee_1
            modeBuilder.Entity<Employee_1>()
              .HasOne(p => p.CashDisBursement)
              .WithOne(i => i.Employee_1)
              .HasForeignKey<CashDisbursement>(b => b.VendorID);

            //Dat  > 
            //C8 vs 9
            // SaleOrder vs Inventory 
            modeBuilder.Entity<ReservationSaleOrderInventory>()
            .HasKey(t => new { t.SaleOrderID, t.InventoryID });

            modeBuilder.Entity<ReservationSaleOrderInventory>()
                .HasOne(pt => pt.SaleOrder)
                .WithMany(p => p.ReservationSaleOrderInventories)
                .HasForeignKey(pt => pt.SaleOrderID);

            modeBuilder.Entity<ReservationSaleOrderInventory>()
                .HasOne(pt => pt.Inventory)
                .WithMany(t => t.ReservationSaleOrderInventories)
                .HasForeignKey(pt => pt.InventoryID);

            //Sale vs Inventory
            modeBuilder.Entity<OutflowSaleInventory>()
            .HasKey(t => new { t.InvoiceID, t.InventoryID });

            modeBuilder.Entity<OutflowSaleInventory>()
                .HasOne(pt => pt.Sale)
                .WithMany(p => p.OutflowSaleInventories)
                .HasForeignKey(pt => pt.InvoiceID);

            modeBuilder.Entity<OutflowSaleInventory>()
                .HasOne(pt => pt.Inventory)
                .WithMany(t => t.OutflowSaleInventories)
                .HasForeignKey(pt => pt.InventoryID);

            //PurchaseOrder VS Inventory
            modeBuilder.Entity<ReservationPurchaseOrderInventory>()
            .HasKey(t => new { t.PurchaseOrderID, t.InventoryID });

            modeBuilder.Entity<ReservationPurchaseOrderInventory>()
                .HasOne(pt => pt.PurchaseOrder)
                .WithMany(p => p.ReservationPurchaseOrderInventories)
                .HasForeignKey(pt => pt.PurchaseOrderID);

            modeBuilder.Entity<ReservationPurchaseOrderInventory>()
                .HasOne(pt => pt.Inventory)
                .WithMany(t => t.ReservationPurchaseOrderInventories)
                .HasForeignKey(pt => pt.InventoryID);

            //Purchase vs Inventory
            modeBuilder.Entity<InflowPurchaseInventory>()
            .HasKey(t => new { t.InventoryReceiptID, t.InventoryID });

            modeBuilder.Entity<InflowPurchaseInventory>()
                .HasOne(pt => pt.Purchase)
                .WithMany(p => p.InflowPurchaseInventories)
                .HasForeignKey(pt => pt.InventoryReceiptID);

            modeBuilder.Entity<InflowPurchaseInventory>()
                .HasOne(pt => pt.Inventory)
                .WithMany(t => t.InflowPurchaseInventories)
                .HasForeignKey(pt => pt.InventoryID);

            // C10
            //Work Schedule vs LaborType
            modeBuilder.Entity<ReservationWSLT>()
            .HasKey(t => new { t.ScheduleID, t.LaborTypeID });

            modeBuilder.Entity<ReservationWSLT>()
                .HasOne(pt => pt.WorkSchedule)
                .WithMany(p => p.ReservationWSLTs)
                .HasForeignKey(pt => pt.ScheduleID);

            modeBuilder.Entity<ReservationWSLT>()
                .HasOne(pt => pt.LaborType)
                .WithMany(t => t.ReservationWSLTs)
                .HasForeignKey(pt => pt.LaborTypeID);

            //Work Schedule vs Labor Acquistion

            modeBuilder.Entity<FulfillmentWSLA>()
            .HasKey(t => new { t.ScheduleID, t.TimeCardID });

            modeBuilder.Entity<FulfillmentWSLA>()
                .HasOne(pt => pt.WorkSchedule)
                .WithMany(p => p.FulfillmentWSLAs)
                .HasForeignKey(pt => pt.ScheduleID);

            modeBuilder.Entity<FulfillmentWSLA>()
                .HasOne(pt => pt.LaborAcquisition)
                .WithMany(t => t.FulfillmentWSLAs)
                .HasForeignKey(pt => pt.TimeCardID);

            // labor type vs labor acquistion
            modeBuilder.Entity<InflowLALT>()
            .HasKey(t => new { t.TimeCardID, t.LaborTypeID });

            modeBuilder.Entity<InflowLALT>()
                .HasOne(pt => pt.LaborAcquisition)
                .WithMany(p => p.InflowLALTs)
                .HasForeignKey(pt => pt.TimeCardID);

            modeBuilder.Entity<InflowLALT>()
                .HasOne(pt => pt.LaborType)
                .WithMany(t => t.InflowLALTs)
                .HasForeignKey(pt => pt.LaborTypeID);

            // Work Schedule vs Employee
            modeBuilder.Entity<ExternalPartWSE>()
            .HasKey(t => new { t.ScheduleID, t.EmployeeID });

            modeBuilder.Entity<ExternalPartWSE>()
                .HasOne(pt => pt.Schedule)
                .WithMany(p => p.ExternalPartWSEs)
                .HasForeignKey(pt => pt.ScheduleID);

            modeBuilder.Entity<ExternalPartWSE>()
                .HasOne(pt => pt.Employee)
                .WithMany(t => t.ExternalPartWSEs)
                .HasForeignKey(pt => pt.EmployeeID);



            //Dat < 


        }
    }
}
