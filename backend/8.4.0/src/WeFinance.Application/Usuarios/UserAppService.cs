using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using WeFinance.Models;
using WeFinance.Usuarios.DTOs;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WeFinance.Usuarios.AppService
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppService : ApplicationService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IRepository<User, long> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpPost("register")]
        public async Task<RegisterDTO> RegisterUser(RegisterDTO input)
        {
            input.Password = HashPassword(input.Password);
            var user = _mapper.Map<User>(input);
            await _userRepository.InsertAsync(user);
            return input; 
        }

        [HttpPost("login")]
        public async Task<User> Login(LoginDTO input)
        {
            var user = await _userRepository.FirstOrDefaultAsync(u => u.Username == input.Username);

            if (user == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            if (!VerifyPassword(input.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Senha incorreta.");

            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == storedHash;
        }
    }
}