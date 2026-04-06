using HealthcareManagementSystem.Core.DTOs;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.MVC.Services
{
    public interface IApiService
    {
        Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto);
        void SetBearerToken(string token);
    }
}
