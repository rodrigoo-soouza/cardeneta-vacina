using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CadernetaVacinal.Models;

public class Vacina
{
    [Key]
    [Required]
    [DisplayName("Código")]
    public int VacinaId { get; set; }

    [Required(ErrorMessage = "O lote é obrigatório.")]
    [StringLength(40, ErrorMessage = "O lote deve ter no máximo 40 caracteres.")]
    public string Lote { get; set; } = string.Empty;

    [Required(ErrorMessage = "O nome da vacina é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da vacina deve ter no máximo 100 caracteres.")]
    [DisplayName("Nome da Vacina")]
    public string NomeVacina { get; set; } = string.Empty;

    [Required(ErrorMessage = "O local é obrigatório.")]
    [StringLength(100, ErrorMessage = "O local deve ter no máximo 100 caracteres.")]
    public string Local { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de vacinação é obrigatória.")]
    [DisplayName("Data da Vacinação")]
    [DataType(DataType.Date, ErrorMessage = "Data de vacinação inválida.")]
    public DateTime DataVacinação { get; set; }

    [DisplayName("Dose Única")]
    public bool Dose { get; set; }

    [Required(ErrorMessage = "O CPF do Paciente é obrigatório.")]
    [StringLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres.")]
    [DisplayName("CPF do Paciente")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Nomme do Paciente é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
    [DisplayName("Nome Completo do Paciente")]
    public string Nome { get; set; } = string.Empty;


    [Required(ErrorMessage = "A matrícula do funcionário é obrigatório.")]
    [DisplayName("Matrícula do Funcionário")]
    public int Matricula { get; set; }

    [Required(ErrorMessage = "O nome do funcionário é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome do funcionário deve ter no máximo 100 caracteres.")]
    [DisplayName("Funcionário")]
    public string Funcionario { get; set; } = string.Empty;

    [DisplayName("Usuário")]
    public string User { get; set; } = string.Empty;
}
