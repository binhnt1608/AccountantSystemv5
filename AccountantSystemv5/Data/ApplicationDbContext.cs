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
        }
    }
}
