using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class PersonAvail : DeletableEntity
    {
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
