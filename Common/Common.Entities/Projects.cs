using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Project : DeletableEntity
    {
        public Project()
        {
            ProjectPersons = new HashSet<ProjectPerson>();
            Slots = new HashSet<Slot>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<ProjectPerson> ProjectPersons { get; set; }
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
