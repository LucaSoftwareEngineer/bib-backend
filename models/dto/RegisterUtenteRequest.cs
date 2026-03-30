using System;
using System.Collections.Generic;
using System.Text;

namespace models.dto
{
    public class RegisterUtenteRequest
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime dataNascita { get; set; }
        public String luogoNascita { get; set; }
    }
}
