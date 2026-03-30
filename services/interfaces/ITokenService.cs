using models;
using System;
using System.Collections.Generic;
using System.Text;

namespace services.interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(Utente utente, string jwtKey);
    }
}
