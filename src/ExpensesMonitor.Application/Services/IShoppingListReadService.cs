﻿namespace ExpensesMonitor.Application.Services;

public interface IShoppingListReadService
{
    Task<bool> ExistByNameAsync(string name);
}