using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Models
{
    public class tPaciente
    {
        [Key]
        [DisplayName]
        public int IDPACIENTE { get; set; }

        [Required(ErrorMessage ="Informe o nome do Paciente")]
        [StringLength(80,ErrorMessage ="O nome deve conter ate 80 caracteres")]
        [MinLength(5,ErrorMessage ="O nome deve conter pelo menos 5 caracteres")]
        [DisplayName("Nome Completo")]
        public string PACIENTENOME { get; set; } = string.Empty;

    }
}
