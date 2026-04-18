using data;
using models;
using models.dto;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class LibroService : ILibroService
    {
        private readonly AppDbContext _appDbContext;

        public LibroService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<AddLibroResponse> AddLibro(AddLibroRequest request)
        {
            var libro = new Libro()
            {
                Titolo = request.Titolo,
                Autore = request.Autore,
                Genere = request.Genere,
                DataPubblicazione = request.DataPubblicazione,
                ISBN = request.ISBN
            };

            await _appDbContext.Libri.AddAsync(libro);
            await _appDbContext.SaveChangesAsync();

            return new AddLibroResponse
            {
                LibroId = libro.LibroId
            };
        }
    }
}