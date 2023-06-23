using System;
using System.Collections.Generic;

namespace Certification_workers.LocalDB
{
    public partial class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string? FullName { get; set; }
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public int IdOrganization { get; set; }
        public string? Category { get; set; }
        public string GroupSpeciality { get; set; } = null!;
        public int IdCertified { get; set; }
        public DateTime DateCertified { get; set; }
        public string? Description { get; set; }
        public byte[]? WorkerPhoto { get; set; }

        public virtual Certified IdCertifiedNavigation { get; set; } = null!;
        public virtual Organization IdOrganizationNavigation { get; set; } = null!;
    }
}
