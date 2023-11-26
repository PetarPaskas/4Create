using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Enums
{
    public enum EventTrigger : byte
    {
        Create = 1,
        Update = 2,
        Delete = 3,
        Get = 4
    }
}
