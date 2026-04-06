using System.Collections.Generic;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }

        public string Notes { get; set; }

        public Appointment Appointment { get; set; }

        public ICollection<Medicine> Medicines { get; set; }
    }
}
