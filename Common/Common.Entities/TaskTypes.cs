using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class TaskType : DeletableEntity
    {
        public TaskType()
        {
            Slots = new HashSet<Slot>();
            TaskTypeCapacities = new HashSet<TaskTypeCapacity>();
        }

        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Slot> Slots { get; set; }
        public virtual ICollection<TaskTypeCapacity> TaskTypeCapacities { get; set; }
    }
}
