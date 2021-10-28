using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funcionario_ApiWeb.NET.Models
{
    public class FuncionarioModel
    {
        [Key]
        public int IdFuncionario { get; set; }

        [Required, MaxLength(128)]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; }

        [Required, Column(TypeName = "char(14)")]
        public string CPF { get; set; }

        [Required, Column(TypeName = "char(14)")]
        [Phone]
        public string Telefone { get; set; }

        public int Idade { get; set; }


        [Required, MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }


        [Required, MaxLength(128)]
        public string Cargo { get; set; }

        public decimal Salario { get; set; }

        [Required]
        public DateTime? DataCadastro { get; } = DateTime.Now;
    }
}
