namespace LogisticsManagementSystem.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IShipmentRepository Shipments { get; }
        IPaymentRepository Payments { get; }
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
