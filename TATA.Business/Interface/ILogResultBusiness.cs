using System.Collections.Generic;
using TATA.Infraestructure.DTO;

namespace TATA.Business.Interface
{
    public interface ILogResultBusiness
    {
        bool Insert(LogResultDTO entity);
        List<LogResultDTO> GetAll();
        List<DetailsLogDTO> GetDuplicates(LogResultDTO model);
    }
}
