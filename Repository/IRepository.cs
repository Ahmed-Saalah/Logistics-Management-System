﻿namespace LogisticsManagementSystem.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> Query();
        Task UpdateAsync(T entity);
    }
}
