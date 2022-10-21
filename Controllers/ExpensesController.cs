using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using workspace.Context;
using workspace.Models;
using workspace.DTO;
using AutoMapper;

namespace workspace.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExpensesController : ControllerBase
  {
    private readonly ILogger<ExpensesController> _logger;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ExpensesController(AppDbContext context, IMapper mapper, ILogger<ExpensesController> logger)
    {
      _logger = logger;
      _context = context;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var expenses = await _context.Expenses.AsNoTracking().ToListAsync();
      List<ReadExpenses> expensesView = _mapper.Map<List<ReadExpenses>>(expenses);
      return Ok(expensesView);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      var expenses = await _context.Expenses.FirstOrDefaultAsync(expenses => expenses.Id == id);
      if (expenses == null)
      {
        return NotFound();
      }
      ReadExpenses readExpenses = _mapper.Map<ReadExpenses>(expenses);
      return Ok(readExpenses);
    }
    [HttpPost]
    public async Task<IActionResult> CreateExpenses([FromBody] CreateExpense newExpense)
    {
      try
      {
        Expenses expense = _mapper.Map<Expenses>(newExpense);
        await _context.Expenses.AddAsync(expense);
        await _context.SaveChangesAsync();
        return Ok(expense);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        return BadRequest(e.Message);
      }

    }
  }
}
