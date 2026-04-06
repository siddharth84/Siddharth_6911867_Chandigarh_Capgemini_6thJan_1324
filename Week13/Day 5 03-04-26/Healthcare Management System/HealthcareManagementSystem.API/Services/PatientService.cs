using AutoMapper;
using HealthcareManagementSystem.Core.DTOs;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IRepository<Patient> _repository;
        private readonly IMapper _mapper;

        public PatientService(IRepository<Patient> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public async Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task<PatientDTO> CreatePatientAsync(CreatePatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _repository.AddAsync(patient);
            await _repository.SaveChangesAsync();
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task<bool> UpdatePatientAsync(int id, CreatePatientDTO patientDto)
        {
            var existingPatient = await _repository.GetByIdAsync(id);
            if (existingPatient == null) return false;

            _mapper.Map(patientDto, existingPatient);
            _repository.Update(existingPatient);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _repository.GetByIdAsync(id);
            if (patient == null) return false;

            _repository.Remove(patient);
            return await _repository.SaveChangesAsync();
        }
    }
}
