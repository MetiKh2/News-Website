using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCms.Domain.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey ID { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? RemoveTime { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {
    }
}

    public abstract class BaseEntityNotID
    {
      
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? RemoveDate { get; set; }
        public bool IsRemoved { get; set; } = false;
        public DateTime? UpdateDate { get; set; }

    }

