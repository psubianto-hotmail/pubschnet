using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class PersonTraining : DeletableEntity
    {
        public int PersonId { get; set; }
        public int? TrainingId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Training Training { get; set; }
    }
}
