using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Clinica.Models
{
    public class tFuncionarios
    {
        [Key]
        [DisplayName]
        public int IdFuncionarios { get; set; }

        [Required(ErrorMessage = "Informe o nome do Funcionario")]
        [StringLength(80, ErrorMessage = "O nome deve conter ate 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string tFuncnome { get; set; } = string.Empty;

    }
}
