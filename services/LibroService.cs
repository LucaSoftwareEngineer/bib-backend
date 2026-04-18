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

        public async Task DeleteLibro(int id)
        {
            try
            {
                var libro = _appDbContext.Libri.Find(id);
                _appDbContext.Libri.Remove(libro);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex) { 
                throw new Exception("Errore durante la cancellazione del libro: " + ex.Message);
            }
        }

        public async Task<LibroResponse> EditLibro(EditLibroRequest request)
        {
            var libro = _appDbContext.Libri.Find(request.LibroId);

            if (libro == null)            {
                throw new Exception("Libro non trovato");
            }

            libro.Titolo = request.Titolo;
            libro.Autore = request.Autore;
            libro.Genere = request.Genere;
            libro.DataPubblicazione = request.DataPubblicazione;
            libro.ISBN = request.ISBN;
            
            await _appDbContext.SaveChangesAsync();

            return new LibroResponse()
            {
                LibroId = libro.LibroId,
                Titolo = libro.Titolo,
                Autore = libro.Autore,
                Genere = libro.Genere,
                DataPubblicazione = libro.DataPubblicazione,
                ISBN = libro.ISBN,
                Disponibile = libro.Noleggi.FirstOrDefault() == null ? true : false
            };
        }

        public Task<List<LibroResponse>> GetAllLibro()
        {
            var libri = _appDbContext.Libri.Select(l => new LibroResponse
            {
                LibroId = l.LibroId,
                Titolo = l.Titolo,
                Autore = l.Autore,
                Genere = l.Genere,
                DataPubblicazione = l.DataPubblicazione,
                ISBN = l.ISBN,
                Disponibile = l.Noleggi.FirstOrDefault() == null ? true : false
            }).ToList();

            return Task.FromResult(libri);
        }

        public Task<LibroResponse?> GetLibroByTitolo(string titolo)
        {
            var libro = _appDbContext.Libri.Where(l => l.Titolo == titolo).Select(l => new LibroResponse
            {
                LibroId = l.LibroId,
                Titolo = l.Titolo,
                Autore = l.Autore,
                Genere = l.Genere,
                DataPubblicazione = l.DataPubblicazione,
                ISBN = l.ISBN,
                Disponibile = l.Noleggi.FirstOrDefault() == null ? true : false
            }).FirstOrDefault();

            return Task.FromResult(libro);
        }
    }
}