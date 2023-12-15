using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Models
{
    internal class PratoPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        //Parte associativa
        public int IdPrato { get; set; }
        public Prato Prato { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public string Notas { get; set; }
        public string Adicionais { get; set; }
        public decimal Valor { get; set; }
    }
}
