namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public int Id { get; set; }

        public int? ToDoId { get; set; }

        public int UserId { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
