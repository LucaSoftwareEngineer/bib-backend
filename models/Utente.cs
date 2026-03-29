using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Utente
    {
        public int UtenteId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime dataNascita { get; set; }
        public String luogoNascita { get; set; }
        public ICollection<Noleggio> Noleggi { get; set; } = new List<Noleggio>();
    }
}
