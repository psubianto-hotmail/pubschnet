using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class PersonCapacity : DeletableEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int CapacityId { get; set; }

        public virtual Capacity Capacity { get; set; }
        public virtual Person Person { get; set; }
    }
}
