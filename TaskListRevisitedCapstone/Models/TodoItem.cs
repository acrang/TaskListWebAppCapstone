using System;
using System.Collections.Generic;

namespace TaskListRevisitedCapstone.Models
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Complete { get; set; }
        public string ToDoId { get; set; }

        public virtual AspNetUsers ToDo { get; set; }
    }
}
