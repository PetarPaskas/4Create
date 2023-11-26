using _4Create.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models.CQRS
{
    public class HandlerResult<T>
    {
        public HandlerStatus Status { get; set; }
        public T Body { get; set; }
        public string Message { get; set; }
    }
}
