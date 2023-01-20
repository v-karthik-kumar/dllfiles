using aws_test.Models;

namespace aws_test.Interfaces
{
    public interface ITodoService
    {
        List<TodoList> GetTodoList();

        TodoList GetTodoDetailsById(Guid todoId);

        ResponseModel SaveTodoItem(TodoList todoModel);

        ResponseModel DeleteTodo(Guid todoId);
    }
}
