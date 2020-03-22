using Business.Interfaces;
using Business.Mappers;
using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Entity.Entities;
using System.Security.Claims;
using Common;
using Common.Exceptions;

namespace Business.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepo;
        private CustomConfiguration _config;

        public UserManager(IUserRepository userRepo, CustomConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        /// <summary>
        /// Add a new user and return it.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public UserGetDto AddUser(UserAddDto userDto)
        {
            return _userRepo
                .AddUser(userDto.ToEntity())
                .ToDto();
        }


        /// <summary>
        /// Get a user by its uid.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserGetDto GetUser(Guid userId)
        {
            return _userRepo.GetUser(userId)?.ToDto();
        }

        /// <summary>
        /// Authenticate a user.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TokenGetDto Authenticate(UserAuthenticationGetDto dto)
        {
            TokenGetDto tokenDto = new TokenGetDto();

            User u = _userRepo.GetUser(dto.Mail);

            if (!u.Password.Equals(dto.Password, StringComparison.OrdinalIgnoreCase))
            {
                throw new IncorrectPasswordException();
            }

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("email", u.Mail),
                new Claim("userId", u.Id.ToString()),
                new Claim("personId", u.PersonId.ToString())
                }),
                Expires = now.AddMinutes(2000),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.JwtToken.SecretKey)), SecurityAlgorithms.HmacSha256),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            tokenDto = new TokenGetDto()
            {
                Token = tokenHandler.WriteToken(token),
                ValidTo = token.ValidTo  
            };

            return tokenDto;
        }
    }
}
