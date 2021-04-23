using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Training : DeletableEntity
    {
        public Training()
        {
            PersonTrainings = new HashSet<PersonTraining>();
            Slots = new HashSet<Slot>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PersonTraining> PersonTrainings { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
