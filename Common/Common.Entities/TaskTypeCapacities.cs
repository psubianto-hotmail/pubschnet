using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class TaskTypeCapacity : DeletableEntity
    {
        public int TaskTypeId { get; set; }
        public int CapacityId { get; set; }

        public virtual Capacity Capacity { get; set; }
        public virtual TaskType TaskType { get; set; }
    }
}
