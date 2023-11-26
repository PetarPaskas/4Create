using _4Create.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task LogToDatabase(LogLevel level, string comment);
    }
}
