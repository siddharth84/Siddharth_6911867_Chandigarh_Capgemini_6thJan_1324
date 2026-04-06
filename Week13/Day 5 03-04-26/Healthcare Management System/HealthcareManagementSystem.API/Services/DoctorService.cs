using AutoMapper;
using HealthcareManagementSystem.Core.DTOs;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IRepository<Doctor> _repository;
        private readonly IMapper _mapper;

        public DoctorService(IRepository<Doctor> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<DoctorDTO> CreateDoctorAsync(CreateDoctorDTO doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _repository.AddAsync(doctor);
            await _repository.SaveChangesAsync();
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task<bool> UpdateDoctorAsync(int id, CreateDoctorDTO doctorDto)
        {
            var existingDoctor = await _repository.GetByIdAsync(id);
            if (existingDoctor == null) return false;

            _mapper.Map(doctorDto, existingDoctor);
            _repository.Update(existingDoctor);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _repository.GetByIdAsync(id);
            if (doctor == null) return false;

            _repository.Remove(doctor);
            return await _repository.SaveChangesAsync();
        }
    }
}
