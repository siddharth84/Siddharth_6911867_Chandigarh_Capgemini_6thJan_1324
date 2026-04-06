using AutoMapper;
using HealthcareManagementSystem.Core.DTOs;
using HealthcareManagementSystem.Core.Entities;
using HealthcareManagementSystem.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareManagementSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IRepository<User> userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            var users = await _userRepository.FindAsync(u => u.Username == loginDto.Username && u.PasswordHash == loginDto.Password);
            var user = users.FirstOrDefault();
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthResponseDTO
            {
                Token = tokenHandler.WriteToken(token),
                Username = user.Username,
                Role = user.Role,
                UserId = user.Id
            };
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUsers = await _userRepository.FindAsync(u => u.Username == registerDto.Username);
            if (existingUsers.Any()) throw new Exception("Username already exists");

            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = registerDto.Password;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return await LoginAsync(new LoginDTO { Username = registerDto.Username, Password = registerDto.Password });
        }
    }
}
