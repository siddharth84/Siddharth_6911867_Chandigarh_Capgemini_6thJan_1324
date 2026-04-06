using AutoMapper;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.DTOs;
using System.Linq;

namespace HealthcareManagementSystem.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<RegisterDTO, User>();

            CreateMap<Patient, PatientDTO>();
            CreateMap<CreatePatientDTO, Patient>();

            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Specializations, opt => opt.MapFrom(src => src.DoctorSpecializations.Select(ds => ds.Specialization.Name).ToList()));
            CreateMap<CreateDoctorDTO, Doctor>();

            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));
            CreateMap<CreateAppointmentDTO, Appointment>();

            CreateMap<Prescription, PrescriptionDTO>();
            CreateMap<CreatePrescriptionDTO, Prescription>();

            CreateMap<Medicine, MedicineDTO>();
            CreateMap<CreateMedicineDTO, Medicine>();
        }
    }
}
