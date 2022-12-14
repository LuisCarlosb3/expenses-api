using System.ComponentModel.DataAnnotations;

class ValueRangeAttribute : ValidationAttribute
{
  public override bool IsValid(object value)
  {
    if (value == null)
    {
      return false;
    }
    double dbValue;
    double.TryParse(value.ToString(), out dbValue);
    return (value != null && dbValue != 0);
  }

}
namespace workspace.Models
{

  public enum ExpensesType
  {
    Earnings,
    Expenses
  }
  public class Expenses
  {
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(200, ErrorMessage = "Este campo deve conter até 240 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter pelo menos 3 caracteres")]

    public string Description { get; set; }
    [DataType("DateTime")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [ValueRangeAttribute(ErrorMessage = "O valor precisa ser diferente de 0")]
    public double Value { get; set; }
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [DataType("ExpensesType")]
    public ExpensesType Type { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Expenses()
    {
      CreatedAt = DateTime.Now;
      UpdatedAt = DateTime.Now;
    }
  }
}