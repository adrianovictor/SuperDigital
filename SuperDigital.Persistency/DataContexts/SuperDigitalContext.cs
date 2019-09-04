using Microsoft.EntityFrameworkCore;
using SuperDigital.Domain.Model.Accounts;
using SuperDigital.Persistency.Mappings.Accounts;

namespace SuperDigital.Persistency.DataContexts
{
    public class SuperDigitalContext : BaseContext<SuperDigitalContext>
    {
        public SuperDigitalContext(DbContextOptions<SuperDigitalContext> options)
            : base(options)
        {
        }

        public DbSet<AccountHolder> AccountHolders { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Withdrawal> Withdrawals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Deposit> Deposits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new AccountHolderMap(modelBuilder.Entity<AccountHolder>().ToTable("AccountHolder", "accounts"));
            new TransferMap(modelBuilder.Entity<Transfer>().ToTable("Transfer", "accounts"));
            new WithdrawalMap(modelBuilder.Entity<Withdrawal>().ToTable("Withdrawal", "accounts"));
            new PaymentMap(modelBuilder.Entity<Payment>().ToTable("Payment", "accounts"));
            new DepositMap(modelBuilder.Entity<Deposit>().ToTable("Deposit", "accounts"));
        }
    }
}
