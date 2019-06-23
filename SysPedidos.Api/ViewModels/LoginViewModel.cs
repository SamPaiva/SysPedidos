using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SysPedidos.Api.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public long? LoginId { get; set; }

        [Required(ErrorMessage = "Por favor Preencha o campo Login")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Por favor Preencha o campo Senha")]
        public string Senha { get; set; }
    }
}
