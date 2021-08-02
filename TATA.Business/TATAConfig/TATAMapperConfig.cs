using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATA.Business.TATAConfig
{
    public class TATAMapperConfig<T> : Profile where T : class
    {
        public TATAMapperConfig()
        {
            CreateMap<T, T>();
        }
    }
}
