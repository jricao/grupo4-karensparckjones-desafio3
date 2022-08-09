using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Core.Entities;
using WoMakersCode.ToDoList.Core.Filters;

namespace WoMakersCode.ToDoList.Core.Repositories
{
    public interface ITaskListRepository: IRepository<TaskList>
    {
        Task<IEnumerable<TaskList>> GetAll();
        Task<TaskList> GetById(GetFilter filter);
        Task Insert(TaskList taskList);
    }
}
