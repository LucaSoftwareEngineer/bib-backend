using System;
using System.Collections.Generic;
using System.Text;

namespace models.dto
{
    public class AddNoleggioRequest
    {
        public int UtenteId { get; set; }
        public int LibroId { get; set; }
        public DateTime DataNoleggio { get; set; }
        public DateTime DataRestituzione { get; set; }
    }
}
