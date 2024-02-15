using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeboScrob.Domain.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDisabled { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
