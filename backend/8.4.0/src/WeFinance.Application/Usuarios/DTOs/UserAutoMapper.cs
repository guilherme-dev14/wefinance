using System;
using AutoMapper;
using WeFinance.Usuarios.DTOs;
using System.Security.Cryptography;
using System.Text;
using WeFinance.Models;
namespace WeFinance.Usuarios.DTOs
{
    public class UserAutoMapper : Profile
    {
        public UserAutoMapper()
        {
            CreateMap<RegisterDTO, User>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(x => HashPassword(x.Password)))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => DateTime.UtcNow));

            CreateMap<User, RegisterDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash));

            CreateMap<LoginDTO, User>()
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore());

            CreateMap<User, LoginDTO>()
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.Username))
                .ForMember(x => x.Password, opt => opt.Ignore());
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}