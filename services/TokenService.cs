using JWT.Algorithms;
using JWT.Builder;
using models;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace services
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(Utente utente, string jwtKey)
        {
            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(jwtKey)
                .AddClaim("UtenteId", utente.UtenteId)
                .AddClaim("Email", utente.Email)
                .AddClaim("Nome", utente.Nome)
                .AddClaim("Cognome", utente.Cognome)
                .AddClaim("IsAdmin", utente.IsAdmin)
                .Encode();
        }
    }
}
