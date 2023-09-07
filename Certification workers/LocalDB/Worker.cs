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
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string GroupSpeciality { get; set; } = null!;
        public string? YearCertified { get; set; }
        public string? Description { get; set; }
        public byte[]? WorkerPhoto { get; set; }
        public int IdTypeCertified { get; set; }
        public string WorkerPositionName { get; set; } = null!;

        public virtual TypeCertified IdTypeCertifiedNavigation { get; set; } = null!;
    }
}
