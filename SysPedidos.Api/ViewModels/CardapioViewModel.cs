using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysPedidos.Api.ViewModels
{
    public class CardapioViewModel
    {
        [Key]
        public long CardapioId { get; set; }

        [Required(ErrorMessage = "Por favor Preencha o campo")]
        public string ItemCardapio { get; set; }

        [Required(ErrorMessage = "Por favor preencha o campo")]
        public string DescItem { get; set; }
    }
}
