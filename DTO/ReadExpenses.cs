using System.ComponentModel.DataAnnotations;
using workspace.Models;

namespace workspace.DTO
{
  public class ReadExpenses
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public double Value { get; set; }
    public ExpensesType Type { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}