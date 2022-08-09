using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Application.Models
{
    public class GetByIdResponse
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public List<TaskResponse> Tasks { get; set; }
    }
}
