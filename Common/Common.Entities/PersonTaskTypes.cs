using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class PersonTaskType : DeletableEntity
    {
        public int TaskTypeId { get; set; }
        public int PersonId { get; set; }
    }
}
