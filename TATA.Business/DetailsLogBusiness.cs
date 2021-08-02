using AutoMapper;
using System.Collections.Generic;
using TATA.Data.Interface;
using TATA.Data.Models;
using TATA.Infraestructure.DTO;

namespace TATA.Business
{
    public  class DetailsLogBusiness
    {
        #region Member
        private readonly IDefaultRepository<DetailsLog> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public DetailsLogBusiness(IDefaultRepository<DetailsLog> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public List<DetailsLogDTO> GetAll()
        {
            List<DetailsLogDTO> model = null;
            var items = _repository.GetAll();
            if (items != null)
                model = _mapper.Map<List<DetailsLogDTO>>(items);
            return model;
        }
        #endregion
    }
}
