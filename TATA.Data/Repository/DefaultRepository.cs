using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TATA.Data.Context;
using TATA.Data.Interface;
using TATA.Data.Models;

namespace TATA.Data.Repository
{
    public class DefaultRepository<T> : IDefaultRepository<T> where T : BaseEntity
    {
        #region Members 
        private TATAContext _context;
        private readonly DbSet<T> table;
        #endregion

        #region Ctor
        public DefaultRepository(TATAContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        #endregion

        #region Methods
        public IEnumerable<T> GetAll()
        {
            return table.AsQueryable();
        }
        public bool Insert(T entity)
        {
            try
            {
                if (string.IsNullOrEmpty(entity.Id.ToString()) || entity.Id == Guid.Empty)
                    entity.Id = Guid.NewGuid();
                entity.CreateTime = DateTime.Now;
                table.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
