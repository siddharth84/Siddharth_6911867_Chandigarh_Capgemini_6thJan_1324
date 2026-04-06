using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
    {
        var departments = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
    }

    public async Task<DepartmentDTO?> GetDepartmentByIdAsync(int id)
    {
        var dept = await _repository.GetByIdAsync(id);
        return dept == null ? null : _mapper.Map<DepartmentDTO>(dept);
    }

    public async Task<DepartmentDTO> CreateDepartmentAsync(CreateDepartmentDTO dto)
    {
        var dept = _mapper.Map<Department>(dto);
        await _repository.AddAsync(dept);
        await _repository.SaveAsync();
        return _mapper.Map<DepartmentDTO>(dept);
    }

    public async Task<bool> UpdateDepartmentAsync(int id, CreateDepartmentDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.DepartmentName = dto.DepartmentName;
        existing.Description = dto.Description;

        _repository.Update(existing);
        await _repository.SaveAsync();
        return true;
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        _repository.Delete(existing);
        await _repository.SaveAsync();
        return true;
    }
}
