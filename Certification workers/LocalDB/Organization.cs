using System;
using System.Collections.Generic;

namespace Certification_workers.LocalDB
{
    public partial class Organization
    {
        public Organization()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string OrganizationName { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
