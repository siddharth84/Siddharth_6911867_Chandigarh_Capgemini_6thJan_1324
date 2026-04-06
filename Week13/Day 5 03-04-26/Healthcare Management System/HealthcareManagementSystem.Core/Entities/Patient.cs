using System;
using System.Collections.Generic;

namespace HealthcareManagementSystem.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }

        public User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
