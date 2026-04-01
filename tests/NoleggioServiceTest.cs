using data;
using Microsoft.EntityFrameworkCore;
using models;
using models.dto;
using services;
using System;
using System.Collections.Generic;
using System.Text;

namespace tests
{
    public class NoleggioServiceTest
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task AddNoleggio()
        {
            var dbContext = GetDbContext();

            var utente = new Utente { UtenteId = 1, Email = "test@test.it", Password = "passwordTest", Nome = "Test", Cognome = "Test", luogoNascita = "Milano" };
            var libro = new Libro { LibroId = 1, Titolo = "Test", Autore = "Test", Genere = "Test", DataPubblicazione = DateTime.Now, ISBN = "A0101" };

            dbContext.Utenti.Add(utente);
            dbContext.Libri.Add(libro);

            var service = new NoleggioService(dbContext);

            var req = new AddNoleggioRequest();
            req.UtenteId = 1;
            req.LibroId = 1;

            AddNoleggioResponse res = await service.AddNoleggio(req);
            Assert.Equal((int) 1, res.NoleggioId);

        }

    }
}
