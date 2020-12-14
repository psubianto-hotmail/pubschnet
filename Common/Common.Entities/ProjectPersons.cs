using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class ProjectPerson : DeletableEntity
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Project Project { get; set; }
    }
}
