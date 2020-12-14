using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Capacity : DeletableEntity
    {
        public Capacity()
        {
            PersonCapacities = new HashSet<PersonCapacity>();
            TaskTypeCapacities = new HashSet<TaskTypeCapacity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonCapacity> PersonCapacities { get; set; }
        public virtual ICollection<TaskTypeCapacity> TaskTypeCapacities { get; set; }
    }
}
