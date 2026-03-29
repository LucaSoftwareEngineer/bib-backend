using System;
using System.Collections.Generic;
using System.Text;

namespace models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public DateTime DataPubblicazione { get; set; }
        public string ISBN { get; set; }
        public ICollection<Noleggio> Noleggi { get; set; } = new List<Noleggio>();
    }
}
