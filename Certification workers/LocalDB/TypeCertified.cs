using System;
using System.Collections.Generic;

namespace Certification_workers.LocalDB
{
    public partial class TypeCertified
    {
        public TypeCertified()
        {
            Workers = new HashSet<Worker>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
