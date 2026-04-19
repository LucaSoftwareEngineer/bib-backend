using System;
using System.Collections.Generic;
using System.Text;

namespace models.dto
{
    public class LoginResponse
    {
        public String token { get; set; }
        public String Email { get; set; }
        public int UtenteId { get; set; }
        public int Noleggi { get; set; }
        public string Ruolo { get; set; }
    }
}
