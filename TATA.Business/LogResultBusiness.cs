
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TATA.Business.Interface;
using TATA.Data.Interface;
using TATA.Data.Models;
using TATA.Infraestructure.DTO;

namespace TATA.Business
{
    public class LogResultBusiness : ILogResultBusiness
    {
        #region Member
        private readonly IDefaultRepository<LogResult> _repository;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public LogResultBusiness(IDefaultRepository<LogResult> repository,
                                 IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public List<LogResultDTO> GetAll()
        {
            List<LogResultDTO> model = null;
            var items = _repository.GetAll();
            if (items != null)
                model = _mapper.Map<List<LogResultDTO>>(items);
            return model;
        }
        public List<DetailsLogDTO> GetDuplicates(LogResultDTO model)
        {
            List<DetailsLogDTO> listDetailsLogDTO = new List<DetailsLogDTO>();
            if (model != null)
            {
                string[] VectorSentence = model.Sentence.Split();
                foreach (var grouping in VectorSentence.GroupBy(t => t).Where(t => t.Count() != 1 && !string.IsNullOrEmpty(t.Key.ToString())))
                {
                    listDetailsLogDTO.Add(new DetailsLogDTO()
                    {
                        Word = grouping.Key,
                        Quantity = grouping.Count()
                    });
                } 
            }
            return listDetailsLogDTO;
        }
        #endregion

    }
}
