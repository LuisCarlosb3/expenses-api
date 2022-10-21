using System.ComponentModel.DataAnnotations;
using workspace.Models;

namespace workspace.DTO
{
  public class CreateExpense
  {
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(200, ErrorMessage = "Este campo deve conter até 240 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter pelo menos 3 caracteres")]

    public string Description { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [DataType("DateTime")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [ValueRangeAttribute(ErrorMessage = "O valor precisa ser diferente de 0")]
    public double Value { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [DataType("ExpensesType")]
    public ExpensesType Type { get; set; }
  }
}