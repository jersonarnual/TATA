using System;

namespace TATA.Infraestructure.DTO
{
    public class DetailsLogDTO
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Word { get; set; }
        public int Quantity { get; set; }
        public virtual LogResultDTO LogResultBusiness { get; set; }
    }
}
