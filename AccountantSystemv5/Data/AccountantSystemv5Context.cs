using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountantSystemv5.Models;

namespace AccountantSystemv5.Models
{
    public class AccountantSystemv5Context : DbContext
    {
        public AccountantSystemv5Context (DbContextOptions<AccountantSystemv5Context> options)
            : base(options)
        {
        }

        public DbSet<AccountantSystemv5.Models.CashAccount> CashAccount { get; set; }

        public DbSet<AccountantSystemv5.Models.CashDisbursementType> CashDisbursementType { get; set; }

        public DbSet<AccountantSystemv5.Models.CashReceiptType> CashReceiptType { get; set; }

        public DbSet<AccountantSystemv5.Models.CashReceipt> CashReceipt { get; set; }

        public DbSet<AccountantSystemv5.Models.Customer> Customer { get; set; }

        public DbSet<AccountantSystemv5.Models.EmployeeType> EmployeeType { get; set; }

        public DbSet<AccountantSystemv5.Models.Employee> Employee { get; set; }

        public DbSet<AccountantSystemv5.Models.Exemptions> Exemptions { get; set; }

        public DbSet<AccountantSystemv5.Models.FulfillmentLACD> FulfillmentLACD { get; set; }

        public DbSet<AccountantSystemv5.Models.FulfillmentSSCD> FulfillmentSSCD { get; set; }

        public DbSet<AccountantSystemv5.Models.InflowPurchaseInventory> InflowPurchaseInventory { get; set; }

        public DbSet<AccountantSystemv5.Models.InventoryComposition> InventoryComposition { get; set; }

        public DbSet<AccountantSystemv5.Models.InventoryDiameter> InventoryDiameter { get; set; }

        public DbSet<AccountantSystemv5.Models.InventoryType> InventoryType { get; set; }

        public DbSet<AccountantSystemv5.Models.Inventory> Inventory { get; set; }

        public DbSet<AccountantSystemv5.Models.LaborAcquisition> LaborAcquisition { get; set; }

        public DbSet<AccountantSystemv5.Models.LoanAgreement> LoanAgreement { get; set; }

        public DbSet<AccountantSystemv5.Models.OutflowSaleInventory> OutflowSaleInventory { get; set; }

        public DbSet<AccountantSystemv5.Models.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<AccountantSystemv5.Models.Purchase> Purchase { get; set; }

        public DbSet<AccountantSystemv5.Models.ReservationPurchaseOrderInventory> ReservationPurchaseOrderInventory { get; set; }

        public DbSet<AccountantSystemv5.Models.ReservationSaleOrderInventory> ReservationSaleOrderInventory { get; set; }

        public DbSet<AccountantSystemv5.Models.SaleOrder> SaleOrder { get; set; }

        public DbSet<AccountantSystemv5.Models.Sale> Sale { get; set; }

        public DbSet<AccountantSystemv5.Models.StockHolderCreditor> StockHolderCreditor { get; set; }

        public DbSet<AccountantSystemv5.Models.StockSubscription> StockSubscription { get; set; }

        public DbSet<AccountantSystemv5.Models.Vendor> Vendor { get; set; }

        public DbSet<AccountantSystemv5.Models.Withholding> Withholding { get; set; }

        public DbSet<AccountantSystemv5.Models.CashDisbursement> CashDisbursement { get; set; }
    }
}
