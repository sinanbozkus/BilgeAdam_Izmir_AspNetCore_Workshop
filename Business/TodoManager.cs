using BilgeAdamAspNetCoreTest.Context;
using BilgeAdamAspNetCoreTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace BilgeAdamAspNetCoreTest.Business
{
    public class TodoManager
    {
        private readonly TodoContext _todoContext;

        public TodoManager(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public List<Todo> GetTodos()
        {
            var list = _todoContext.Todos.OrderByDescending(x => x.Id).ToList();
            return list;
        }

        public void SaveTodo(Todo todo)
        {
            _todoContext.Add(todo);
            _todoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = _todoContext.Todos.Single(x => x.Id == id);
            _todoContext.Remove(todo);
            _todoContext.SaveChanges();
        }
    }
}
