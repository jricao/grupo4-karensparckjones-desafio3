using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;

namespace WoMakersCode.ToDoList.Core.Repositories
{
    public interface IRepository
    {
        Task Inserir(TaskList taskList);
        Task<TaskList> GetTaskList(int id);
        Task InserirTask(TaskDetail taskDetail);
    }
}
