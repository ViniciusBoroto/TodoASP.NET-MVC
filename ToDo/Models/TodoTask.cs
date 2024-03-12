﻿namespace ToDo.Models
{
    public class TodoTask
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public bool Finished { get; set; }
    }
}
