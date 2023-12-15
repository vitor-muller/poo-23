using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Models
{
    internal class Pedido
    {
        public int Id { get; set; }
        public int Mesa { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime HoraPedido { get; set; }
        public string TipoPagamento { get; set; }
        public string Status { get; set; }
        public ICollection<PratoPedido> PratoPedidos { get; set; } = new List<PratoPedido>();
    }
}
