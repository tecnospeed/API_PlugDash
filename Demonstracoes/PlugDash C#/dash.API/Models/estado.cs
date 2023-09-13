﻿using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Dynamic;

namespace dashAPI.Models
{
    public class estado
    {
        [Key]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo Sigla deve ter 2 caracteres")]
        public string Sigla {get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 200 caracteres")]
        public string Nome { get; set; }
    }

}
