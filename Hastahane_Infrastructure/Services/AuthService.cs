
using Hastahane_Core.DTOs;
using Hastahane_Domain.Entities;
using Hastahane_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Hastahane_Infrastructure.Services
{
    public class AuthService : Hastahane_Core.Inerfaces.IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterAsync(RegisterDto registerDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
                throw new Exception("Email already exists");

            var user = new User { FullName = registerDto.FullName, Email = registerDto.Email, PasswordHash = HashPassword(registerDto.Password), Role = registerDto.Role };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return "User registered successfully";
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (user == null)
                throw new Exception("Invalid credentials");

            if (!VerifyPassword(loginDto.Password, user.PasswordHash))
                throw new Exception("Invalid credentials");

            return $"Login successful - Role: {user.Role}";
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return HashPassword(password) == hash;
        }
    }
}