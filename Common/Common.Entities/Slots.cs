using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Slot : DeletableEntity
    {
        public Slot()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public int ProjectId { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int? IsActive { get; set; }
        public string Description { get; set; }
        public int TaskTypeId { get; set; }
        public int? TrainingId { get; set; }

        public virtual Project Project { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual Training Training { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
