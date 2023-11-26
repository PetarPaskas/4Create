using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Create.Domain.Models
{
    public class EntityBase
    {
        /// <summary>
        /// UTC Date when an entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
