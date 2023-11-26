using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        public Task LogToDatabase(LogLevel level, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
