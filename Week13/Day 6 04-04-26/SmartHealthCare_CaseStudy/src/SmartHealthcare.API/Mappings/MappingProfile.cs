using AutoMapper;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDTO>();

        CreateMap<Department, DepartmentDTO>();
        CreateMap<CreateDepartmentDTO, Department>();

        CreateMap<Doctor, DoctorDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.DoctorId))
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.User != null ? s.User.FullName : string.Empty))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.User != null ? s.User.Email : string.Empty))
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Department != null ? s.Department.DepartmentName : string.Empty))
            .ForMember(d => d.YearsOfExperience, opt => opt.MapFrom(s => s.ExperienceYears));
        CreateMap<CreateDoctorDTO, Doctor>()
            .ForMember(d => d.ExperienceYears, opt => opt.MapFrom(s => s.YearsOfExperience));

        CreateMap<Patient, PatientDTO>()
            .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.User != null ? s.User.FullName : string.Empty));
        CreateMap<CreatePatientDTO, Patient>();

        CreateMap<Appointment, AppointmentDTO>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AppointmentId))
            .ForMember(d => d.PatientName, opt => opt.MapFrom(s => s.Patient != null && s.Patient.User != null ? s.Patient.User.FullName : string.Empty))
            .ForMember(d => d.DoctorName, opt => opt.MapFrom(s => s.Doctor != null && s.Doctor.User != null ? s.Doctor.User.FullName : string.Empty))
            .ForMember(d => d.DepartmentName, opt => opt.MapFrom(s => s.Doctor != null && s.Doctor.Department != null ? s.Doctor.Department.DepartmentName : string.Empty))
            .ForMember(d => d.HasPrescription, opt => opt.MapFrom(s => s.Prescription != null))
            .ForMember(d => d.HasBill, opt => opt.MapFrom(s => s.Bill != null));
        CreateMap<CreateAppointmentDTO, Appointment>();

        CreateMap<Prescription, PrescriptionDTO>()
            .ForMember(d => d.Medicines, opt => opt.MapFrom(s => s.Medicines));
        CreateMap<CreatePrescriptionDTO, Prescription>();

        CreateMap<Medicine, MedicineDTO>();
        CreateMap<CreateMedicineDTO, Medicine>();
        
        CreateMap<Bill, BillDTO>();
        CreateMap<CreateBillDTO, Bill>();
    }
}
