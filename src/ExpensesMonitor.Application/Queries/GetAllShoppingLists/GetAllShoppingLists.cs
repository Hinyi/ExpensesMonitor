using ExpensesMonitor.Domain.Entities;
using ExpensesMonitor.Infrastructure.EF.Models;
using ExpensesMonitor.Shared.DTO;
using ExpensesMonitor.Shared.Queries;
using MediatR;

namespace ExpensesMonitor.Application.Queries.GetAllShoppingLists;

public record GetAllShoppingLists() : IRequest<IEnumerable<ShoppingListDto>>;
