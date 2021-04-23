using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Assignment : DeletableEntity
    {
        public int SlotId { get; set; }
        public int PersonId { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual Person Person { get; set; }
        public virtual Slot Slot { get; set; }
    }
}
