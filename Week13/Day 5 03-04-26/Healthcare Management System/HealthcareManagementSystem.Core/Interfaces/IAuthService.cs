using HealthcareManagementSystem.Core.DTOs;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto);
    }
}
