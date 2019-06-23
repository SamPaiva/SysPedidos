using SysPedidos.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysPedidos.Api.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public long PedidoId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPedido { get; set; }

        public string Descricao { get; set; }

        public string Cliente { get; set; }
    }
}
