using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Location : DeletableEntity
    {
        public Location()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IsActive { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
