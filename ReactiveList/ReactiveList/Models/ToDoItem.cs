using System;

namespace ReactiveList.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool? Done { get; set; }
    }
}