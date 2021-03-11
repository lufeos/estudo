using System;

namespace ProAgil.Domain
{
    public class Lote
    {
        public int id { get; set; }

        public string nome { get; set; }

        public decimal Preco { get; set; }

        public DateTime? dataInicial { get; set; }

        public DateTime? dataFinal { get; set; }

        public int quantidade { get; set; }

        public int eventoId { get; set; }

        public Evento evento { get; set; }
    }
}