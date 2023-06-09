﻿namespace Customer.Insfrastructure.Persistence;

public class CustomerDbContext : BaseDbContext, ICustomerDbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options,
                             IOptions<DataBaseSetting> dataBaseSettings,
                             IDomainMediator mediator,
                             IIntegrationEventMapper eventMapper,
                             IDbContextConfig dbContextConfig) : base(options, dataBaseSettings, mediator, eventMapper, dbContextConfig)
    {
    }

    public DbSet<CustomerEntity> Customer { get; set; }
    public DbSet<CustomerOrderEntity> CustomerOrder { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CustomerMap(TenantId));
        modelBuilder.ApplyConfiguration(new CustomerOrderMap(TenantId));
    }

}
