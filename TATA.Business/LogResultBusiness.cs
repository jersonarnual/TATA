
using AutoMapper;
using System;
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
        public bool Insert(LogResultDTO entity)
        {
            List<DetailsLog> listDetailsLog= new List<DetailsLog>();
            var model = ConvertToModel(entity);
            
            if (entity.ListDetailsLogDTO != null)
            {
                foreach (var item in entity.ListDetailsLogDTO)
                    listDetailsLog.Add(ConvertToModel(item));
            }
            model.DetailsLogs = listDetailsLog;
            return _repository.Insert(model);
        }
        public List<LogResultDTO> GetAll()
        {
            List<LogResultDTO> model = new List<LogResultDTO>();
            var items = _repository.GetAll();
            if (items != null)
            {
                foreach (var item in items)
                    model.Add(ConvertToDTO(item));
            }
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


        #region Private methods
        private LogResult ConvertToModel(LogResultDTO model)
        {
            if (model != null)
                return new LogResult()
                {
                    UpdateBy = model.UpdateBy,
                    CreateBy = model.CreateBy,
                    Id = model.Id,
                    Sentence = model.Sentence,
                };
            return null;
        }

        private LogResultDTO ConvertToDTO(LogResult model)
        {
            if (model != null)
                return new LogResultDTO()
                {
                    UpdateBy = model.UpdateBy,
                    CreateBy = model.CreateBy,
                    UpdateTime = model.UpdateTime,
                    CreateTime = model.CreateTime,
                    Id = model.Id,
                    Sentence = model.Sentence
                };
            return null;
        }

        private DetailsLog ConvertToModel(DetailsLogDTO model)
        {
            if (model != null)
                return new DetailsLog()
                {
                    UpdateBy = model.UpdateBy,
                    CreateBy = model.CreateBy,
                    Id = model.Id ,
                    Word = model.Word,
                    Quantity = model.Quantity
                };
            return null;
        }

        #endregion

    }
}
