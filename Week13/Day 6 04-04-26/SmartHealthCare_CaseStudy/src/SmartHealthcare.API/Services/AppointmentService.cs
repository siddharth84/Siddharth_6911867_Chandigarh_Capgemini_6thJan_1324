using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _repo;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<PagedResult<AppointmentDTO>> GetAllAsync(int page, int pageSize)
    {
        var appointments = await _repo.GetAllWithDetailsAsync(page, pageSize);
        var totalCount = await _repo.CountAsync();
        return new PagedResult<AppointmentDTO>
        {
            Items = _mapper.Map<List<AppointmentDTO>>(appointments),
            TotalCount = totalCount,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<AppointmentDTO?> GetByIdAsync(int id)
    {
        var appointment = await _repo.GetWithDetailsAsync(id);
        return appointment == null ? null : _mapper.Map<AppointmentDTO>(appointment);
    }

    public async Task<PagedResult<AppointmentDTO>> GetByPatientIdAsync(int patientId, int page, int pageSize)
    {
        var appointments = await _repo.GetByPatientIdAsync(patientId, page, pageSize);
        var totalCount = await _repo.CountByPatientAsync(patientId);
        return new PagedResult<AppointmentDTO>
        {
            Items = _mapper.Map<List<AppointmentDTO>>(appointments),
            TotalCount = totalCount,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<PagedResult<AppointmentDTO>> GetByDoctorIdAsync(int doctorId, int page, int pageSize)
    {
        var appointments = await _repo.GetByDoctorIdAsync(doctorId, page, pageSize);
        var totalCount = await _repo.CountByDoctorAsync(doctorId);
        return new PagedResult<AppointmentDTO>
        {
            Items = _mapper.Map<List<AppointmentDTO>>(appointments),
            TotalCount = totalCount,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<PagedResult<AppointmentDTO>> GetByDateAsync(DateTime date, int page, int pageSize)
    {
        var appointments = await _repo.GetByDateAsync(date, page, pageSize);
        var totalCount = await _repo.CountByDateAsync(date);
        return new PagedResult<AppointmentDTO>
        {
            Items = _mapper.Map<List<AppointmentDTO>>(appointments),
            TotalCount = totalCount,
            PageNumber = page,
            PageSize = pageSize
        };
    }

    public async Task<AppointmentDTO> CreateAsync(int patientId, CreateAppointmentDTO dto)
    {
        var appointment = _mapper.Map<Appointment>(dto);
        appointment.PatientId = patientId;
        appointment.Status = "Booked";

        await _repo.AddAsync(appointment);
        await _repo.SaveAsync();

        var created = await _repo.GetWithDetailsAsync(appointment.AppointmentId);
        return _mapper.Map<AppointmentDTO>(created);
    }

    public async Task<bool> UpdateStatusAsync(int id, string status)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment == null) return false;

        appointment.Status = status;

        _repo.Update(appointment);
        await _repo.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var appointment = await _repo.GetByIdAsync(id);
        if (appointment == null) return false;

        _repo.Delete(appointment);
        await _repo.SaveAsync();
        return true;
    }
}
