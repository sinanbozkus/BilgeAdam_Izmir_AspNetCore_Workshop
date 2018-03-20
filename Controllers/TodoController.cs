using BilgeAdamAspNetCoreTest.Business;
using BilgeAdamAspNetCoreTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace BilgeAdamAspNetCoreTest.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoManager _todoManager;

        public TodoController(TodoManager todoManager)
        {
            _todoManager = todoManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Save(TodoFormViewModel viewModel)
        {
            if (!string.IsNullOrWhiteSpace(viewModel.Title))
            {
                _todoManager.SaveTodo(new Todo
                {
                    Title = viewModel.Title
                });
            }

            return RedirectToActionPermanent(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _todoManager.Delete(id);
            return RedirectToActionPermanent(nameof(Index));
        }
    }
}