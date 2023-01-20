using aws_test.Interfaces;
using aws_test.Models;
using Microsoft.EntityFrameworkCore;

namespace aws_test.Services
{
    public class TodoService : ITodoService
    {
        private TodoContext todoContext;
        public TodoService(TodoContext tdContext)
        {
            todoContext = tdContext;
        }
        public ResponseModel DeleteTodo(Guid todoId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                TodoList _temp = GetTodoDetailsById(todoId);
                if (_temp != null)
                {
                    todoContext.Remove<TodoList>(_temp);
                    todoContext.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Todo Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Todo Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public TodoList GetTodoDetailsById(Guid todoId)
        {
            TodoList todo;
            try
            {
                todo = todoContext.Find<TodoList>(todoId);
            }
            catch (Exception)
            {
                throw;
            }
            return todo;

            throw new NotImplementedException();
        }

        public List<TodoList> GetTodoList()
        {
            List<TodoList> todoList;

            try
            {
                todoList = todoContext.Set<TodoList>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return todoList;
        }

        public ResponseModel SaveTodoItem(TodoList todoModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                //   TodoModel _temp = GetTodoDetailsById(todoModel.Id);
                //if (_temp != null)
                //{
                //    _temp.IsCompleted = todoModel.IsCompleted;
                //    _temp.Description = todoModel.Description;
                //    _temp.ModifiedDate = DateTime.UtcNow;
                //    todoContext.Update<TodoModel>(_temp);
                //    model.Messsage = "Todo Update Successfully";
                //}
                //else
                //{
                todoModel.CreatedDate = DateTime.UtcNow;
                todoModel.ModifiedDate = DateTime.UtcNow;
                todoContext.Add<TodoList>(todoModel);
                model.Messsage = "Todo Inserted Successfully";
                //  }
                todoContext.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }
    }
}
