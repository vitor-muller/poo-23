using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Models
{
    internal class Pagamento
    {
        public int Id { get; set; }
        public int PagamentoId { get; set; }
        public int PedidoId { get; set; }
        public string MetodoPagamento { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
