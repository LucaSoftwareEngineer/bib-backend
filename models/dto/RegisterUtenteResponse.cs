using System;
using System.Collections.Generic;
using System.Text;

namespace models.dto
{
    public class RegisterUtenteResponse
    {
        public int UtenteId { get; set; }

        public RegisterUtenteResponse(int UtenteId) { 
            this.UtenteId = UtenteId;
        }

    }
}
