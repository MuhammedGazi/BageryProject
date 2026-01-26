using Bagery.Business.DTOs.AuthDTOs;
using Bagery.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagery.Business.Services.IAuthServices
{
    public interface IAuthServices
    {
        Task<IResult> RegisterAsync(RegisterDto dto);
        Task<IResult> LoginAsync(LoginDto dto);
        Task<IResult> LogoutAsync();
    }
}
