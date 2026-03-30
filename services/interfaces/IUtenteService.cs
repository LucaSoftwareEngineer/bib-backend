using models.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface IUtenteService
    {
        public Task<RegisterUtenteResponse> RegisterUtente(RegisterUtenteRequest request);
        public Task<LoginResponse> LoginUtente(LoginRequest request, string jwtKey);
    }
}
