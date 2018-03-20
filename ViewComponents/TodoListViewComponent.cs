using BilgeAdamAspNetCoreTest.Business;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BilgeAdamAspNetCoreTest.ViewComponents
{
    [ViewComponent]
    public class TodoListViewComponent : ViewComponent
    {
        private readonly TodoManager _todoManager;

        public TodoListViewComponent(TodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;

            var list = _todoManager.GetTodos();
            return View(list);
        }
    }
}
