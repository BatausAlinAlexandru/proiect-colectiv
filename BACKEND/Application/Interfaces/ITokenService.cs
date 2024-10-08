using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(GenerateTokenDTO generateTokenDTO);
    }
}
