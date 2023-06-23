using System;
using System.Collections.Generic;

namespace Certification_workers.LocalDB
{
    public partial class Certified
    {
        public Certified()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string TypeCertifiedName { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
