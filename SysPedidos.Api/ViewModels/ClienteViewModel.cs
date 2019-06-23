using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SysPedidos.Api.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ClienteId { get; set; }

        [Required]
        [StringLength(60)]   
        public string NomeCliente { get; set; }

        [Required]
        [StringLength(10)]
        public string Telefone { get; set; }

        [Required]
        [StringLength(250)]
        public string Endereco { get; set; }

    }
}
