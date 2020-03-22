using Dto.Dtos.AddDtos;
using Dto.Dtos.GetDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interfaces
{
    public interface IUserManager
    {
        UserGetDto GetUser(Guid userId);

        UserGetDto AddUser(UserAddDto userDto);
        TokenGetDto Authenticate(UserAuthenticationGetDto dto);
    }
}
