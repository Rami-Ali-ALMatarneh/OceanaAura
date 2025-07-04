﻿using Microsoft.EntityFrameworkCore;
using OceanaAura.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Application.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(List<T> entities); 
        void Remove(T entity);
        void ReomveRange(List<T> entities);
        void Update(T entity);
        IQueryable<T> Query();
        Task<int> CountAsync(IQueryable<T> query);
        Task<List<T>> ToListAsync(IQueryable<T> query);

    }
}
