using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Person : DeletableEntity
    {
        public Person()
        {
            Assignments = new HashSet<Assignment>();
            PersonAvails = new HashSet<PersonAvail>();
            PersonCapacities = new HashSet<PersonCapacity>();
            PersonTrainings = new HashSet<PersonTraining>();
            ProjectPersons = new HashSet<ProjectPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int? SecurityLevel { get; set; }
        public string Aspnetuserid { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<PersonAvail> PersonAvails { get; set; }
        public virtual ICollection<PersonCapacity> PersonCapacities { get; set; }
        public virtual ICollection<PersonTraining> PersonTrainings { get; set; }
        public virtual ICollection<ProjectPerson> ProjectPersons { get; set; }

    }
}
