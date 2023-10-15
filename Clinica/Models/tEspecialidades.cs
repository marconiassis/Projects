using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Clinica.Models
{
    public class tEspecialidade
    {
        [Key]
        [DisplayName]
        public int idEspecialidade { get; set; }

        [Required(ErrorMessage = "Informe o nome da Especialidade")]
        [StringLength(80, ErrorMessage = "O nome deve conter ate 80 caracteres")]
        [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Especialidade")]
        public string NomeEspecialidade { get; set; } = string.Empty;

    }
}
