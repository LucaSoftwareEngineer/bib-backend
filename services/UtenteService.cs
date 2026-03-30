using data;
using models;
using models.dto;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace services
{
    public class UtenteService : IUtenteService
    {

        private readonly AppDbContext _appDbContext;

        public UtenteService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<RegisterUtenteResponse> RegisterUtente(RegisterUtenteRequest request)
        {
            Utente utente = new Utente
            {
                Nome = request.Nome,
                Cognome = request.Cognome,
                Email = request.Email,
                Password = request.Password,
                dataNascita = request.dataNascita,
                luogoNascita = request.luogoNascita
            };

            _appDbContext.Utenti.Add(utente);
            await _appDbContext.SaveChangesAsync();

            return new RegisterUtenteResponse(utente.UtenteId);

        }
    }
}
