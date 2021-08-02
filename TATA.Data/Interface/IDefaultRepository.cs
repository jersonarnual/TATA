using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TATA.Data.Models;

namespace TATA.Data.Interface
{
    public interface IDefaultRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
    }
}
