using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Certification_workers.Models
{
    public class Worker
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Patronymic { get; set; }

        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string Organization { get; set; }
        public string Category { get; set; }
        public string? Group { get; set; }
        public bool? IsCertified { get; set; }
        public string? Description { get; set; }

        public DateTime? YearAdmission { get; set; }
        public DateTime? YearEnding { get; set; }

    }
}
