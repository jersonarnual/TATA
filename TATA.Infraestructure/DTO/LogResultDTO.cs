using System;
using System.Collections.Generic;

namespace TATA.Infraestructure.DTO
{
    public class LogResultDTO
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Sentence { get; set; }
        public virtual ICollection<DetailsLogDTO> ListDetailsLogDTO { get; set; }
    }
}
