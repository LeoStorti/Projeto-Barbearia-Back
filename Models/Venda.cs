using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIBarbearia.Models
{
    public class Vendas
    {
        [Key]
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public decimal TotalVenda { get; set; }

        // Relacionamento com produtos vendidos
       // public List<ItensVenda> ItensVenda { get; set; }
    }


}
