using data;
using Microsoft.EntityFrameworkCore;
using models;
using models.dto;
using Moq;
using services;
using services.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace tests
{
    public class UtenteServiceTest
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
        public async Task LoginUtente()
        {
            var dbContext = GetDbContext();
            var mockTokenService = new Mock<ITokenService>();

            var passwordHash = BCrypt.Net.BCrypt.HashPassword("secret");
            var utente = new Utente { Email = "test@test.it", Password = passwordHash, Nome = "Test", Cognome = "Test", luogoNascita = "Milano" };
            dbContext.Utenti.Add(utente);

            await dbContext.SaveChangesAsync();

            mockTokenService.Setup(s => s.GenerateToken(It.IsAny<Utente>(), It.IsAny<string>())).Returns("fake-jwt-token");

            var service = new UtenteService(dbContext, mockTokenService.Object);
            var loginReq = new LoginRequest { Email = "test@test.it", Password = "secret" };

            var result = await service.LoginUtente(loginReq, "chiave-segreta-molto-lunga");

            Assert.Equal("fake-jwt-token", result.token);
        }
    }
}
