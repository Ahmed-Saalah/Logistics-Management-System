using LogisticsManagementSystem.Models;

namespace LogisticsManagementSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LogisticsManagementContext _context;
        private IShipmentRepository _shipments;
        private IPaymentRepository _payments;

        public UnitOfWork(LogisticsManagementContext context)
        {
            _context = context;
        }

        public IShipmentRepository Shipments => _shipments ??= new ShipmentRepository(_context);
        public IPaymentRepository Payments => _payments ??= new PaymentRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
