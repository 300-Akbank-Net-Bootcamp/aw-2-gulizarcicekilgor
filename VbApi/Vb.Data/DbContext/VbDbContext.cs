using Microsoft.EntityFrameworkCore;
using Vb.Data.Entity;

namespace Vb.Data;

public class VbDbContext : DbContext
{//kurucu methot
    public VbDbContext(DbContextOptions<VbDbContext> options): base(options)
    {
    
    }   
    
    // dbset eklemek zorunda değiliz. s takısıyla eklenir.
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountTransaction> AccountTransactions { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<EftTransaction> EftTransactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {  //modellerin nasıl oluşacağını kurallarunı oluşturduk.
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new AccountTransactionConfiguration());
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new EftTransactionConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
}