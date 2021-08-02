using Microsoft.EntityFrameworkCore;
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
        #endregion
    }
}
