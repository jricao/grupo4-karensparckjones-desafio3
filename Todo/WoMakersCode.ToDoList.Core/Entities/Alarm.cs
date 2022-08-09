using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.ToDoList.Core.Entities
{
    public class Alarm
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public int IdTaskDetail { get; set; }
        public TaskDetail TaskDetail { get; set; }
    }
}
