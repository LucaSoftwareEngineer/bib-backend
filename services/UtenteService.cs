using data;
using models;
using models.dto;
using services.interfaces;

namespace services
{
    public class UtenteService : IUtenteService
    {

        private readonly AppDbContext _appDbContext;
        private readonly TokenService _tokenService;

        public UtenteService(AppDbContext appDbContext, TokenService tokenService)
        {
            this._appDbContext = appDbContext;
            this._tokenService = tokenService;
        }

        public async Task<RegisterUtenteResponse> RegisterUtente(RegisterUtenteRequest request)
        {
            Utente utente = new Utente
            {
                Nome = request.Nome,
                Cognome = request.Cognome,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                dataNascita = request.dataNascita,
                luogoNascita = request.luogoNascita
            };

            _appDbContext.Utenti.Add(utente);
            await _appDbContext.SaveChangesAsync();

            return new RegisterUtenteResponse(utente.UtenteId);

        }

        public async Task<LoginResponse> LoginUtente(LoginRequest request, string jwtKey)
        {
            var utente = _appDbContext.Utenti.Where(u => u.Email == request.Email).FirstOrDefault();

            if (utente == null || BCrypt.Net.BCrypt.Verify(request.Password, utente.Password) == false)
            {
                throw new Exception("Email o password errati");
            }

            return new LoginResponse
            {
                token = _tokenService.GenerateToken(utente, jwtKey)
            };

        }
    }
}
