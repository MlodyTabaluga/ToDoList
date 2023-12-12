using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.Models
{
    public class ListTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }

        public ListTask(int id, string name, DateTime createDate, string description)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
            Description = description;
        }
    }
}
