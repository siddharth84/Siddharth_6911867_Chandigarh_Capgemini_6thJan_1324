using AutoMapper;
using HealthcareManagementSystem.Core.DTOs;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.API.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IRepository<Appointment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentsAsync()
        {
            var appointments = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AppointmentDTO>>(appointments);
        }

        public async Task<AppointmentDTO> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<AppointmentDTO> CreateAppointmentAsync(CreateAppointmentDTO appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.Status = "Pending"; // Default status
            await _repository.AddAsync(appointment);
            await _repository.SaveChangesAsync();
            return _mapper.Map<AppointmentDTO>(appointment);
        }

        public async Task<bool> UpdateAppointmentStatusAsync(int id, UpdateAppointmentStatusDTO statusDto)
        {
            var existingAppointment = await _repository.GetByIdAsync(id);
            if (existingAppointment == null) return false;

            existingAppointment.Status = statusDto.Status;
            _repository.Update(existingAppointment);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            var appointment = await _repository.GetByIdAsync(id);
            if (appointment == null) return false;

            _repository.Remove(appointment);
            return await _repository.SaveChangesAsync();
        }
    }
}
