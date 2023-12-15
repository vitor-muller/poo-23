using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Models
{
    internal class Prato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public string Categoria { get; set; }
        public string Ingredientes { get; set; }
        public decimal Preco { get; set; }
        public int TempoPreparo { get; set; }
        public ICollection<PratoPedido> PratoPedidos { get; set; }
    }
}
