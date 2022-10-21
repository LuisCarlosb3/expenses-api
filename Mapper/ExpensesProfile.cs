using AutoMapper;
using workspace.DTO;
using workspace.Models;

namespace workspace.ExpensesProfile
{

  public class ExpensesProfile : Profile
  {
    public ExpensesProfile()
    {
      CreateMap<CreateExpense, Expenses>();
      CreateMap<Expenses, ReadExpenses>();
    }
  }
}

