using data;
using models;
using models.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace services
{
    public class NoleggioService : interfaces.INoleggioService
    {
        private readonly AppDbContext _appDbContext;

        public NoleggioService(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<AddNoleggioResponse> AddNoleggio(AddNoleggioRequest request)
        {
            var utente = await _appDbContext.Utenti.FindAsync(request.UtenteId);
            var libro = await _appDbContext.Libri.FindAsync(request.LibroId);

            if (utente == null || libro == null)
            {
                throw new Exception("Utente o Libro non trovato");
            }

            Noleggio noleggio = new Noleggio
            {
                Utente = utente,
                Libro = libro,
                DataNoleggio = request.DataNoleggio,
                DataRestituzione = request.DataRestituzione
            };

            _appDbContext.Noleggi.Add(noleggio);
            await _appDbContext.SaveChangesAsync();

            return new AddNoleggioResponse
            {
                NoleggioId = noleggio.NoleggioId
            };

        }
    }
}
