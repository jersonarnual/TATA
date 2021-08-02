using System.Collections.Generic;

namespace TATA.Data.Models
{
    public class LogResult : BaseEntity
    {
        public LogResult()
        {
            DetailsLogs = new HashSet<DetailsLog>();
        }
        public string Sentence { get; set; }
        public virtual ICollection<DetailsLog> DetailsLogs { get; set; }
    }
}
