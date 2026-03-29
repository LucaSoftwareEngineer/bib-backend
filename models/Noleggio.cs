using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Noleggio
    {
        public int NoleggioId { get; set; }
        public int UtenteId { get; set; }
        public int LibroId { get; set; }
        public DateTime DataNoleggio { get; set; }
        public DateTime DataRestituzione { get; set; }
        public Utente Utente { get; set; }
        public Libro Libro { get; set; }
    }
}
