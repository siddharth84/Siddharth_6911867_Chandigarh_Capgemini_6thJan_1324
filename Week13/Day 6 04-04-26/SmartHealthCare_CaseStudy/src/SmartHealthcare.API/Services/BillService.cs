using AutoMapper;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _repository;
    private readonly IMapper _mapper;

    public BillService(IBillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BillDTO?> GetBillByAppointmentAsync(int appointmentId)
    {
        var bill = await _repository.GetBillByAppointmentAsync(appointmentId);
        if (bill == null) return null;
        
        var dto = _mapper.Map<BillDTO>(bill);
        // TotalAmount is computed by SQL Server, but if we need a fallback:
        // dto.TotalAmount = bill.ConsultationFee + bill.MedicineCharges;
        return dto;
    }

    public async Task<BillDTO> CreateBillAsync(CreateBillDTO dto)
    {
        var bill = _mapper.Map<Bill>(dto);
        await _repository.AddAsync(bill);
        await _repository.SaveAsync();
        
        var result = _mapper.Map<BillDTO>(bill);
        return result;
    }

    public async Task<bool> UpdateBillStatusAsync(int id, UpdateBillStatusDTO dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return false;

        existing.PaymentStatus = dto.PaymentStatus;

        _repository.Update(existing);
        await _repository.SaveAsync();
        return true;
    }
}
