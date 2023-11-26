using _4Create.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models
{
    public class Log : EntityBase
    {
        public Guid LogId { get; set; }
        public Guid TrackId { get; set; }
        public LogLevel Level { get; set; }
        public EventTrigger Event { get; set; }
        public string ResourceAttributes { get; set; }
        public string Comment { get; set; }
    }
}
