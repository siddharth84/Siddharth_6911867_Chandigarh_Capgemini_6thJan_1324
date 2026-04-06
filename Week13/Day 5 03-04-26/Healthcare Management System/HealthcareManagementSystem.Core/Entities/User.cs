namespace HealthcareManagementSystem.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } // Admin, Doctor, Patient

        // Navigation Properties
        public Patient Patient { get; set; } 
        public Doctor Doctor { get; set; } 
    }
}
