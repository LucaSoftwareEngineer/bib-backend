using System;
using System.Collections.Generic;
using System.Text;

namespace models.dto
{
    public class AddLibroRequest
    {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public DateTime DataPubblicazione { get; set; }
        public string ISBN { get; set; }
    }
}
