using System.Collections.Generic;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
