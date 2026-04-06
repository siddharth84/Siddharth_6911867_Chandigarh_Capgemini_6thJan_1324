using System.Collections.Generic;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DoctorSpecialization> DoctorSpecializations { get; set; }
    }
}
