﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.DTO
{
    public class BllTask : IEntity 
    {
        public int Id { get; set; }

        public int? ToDoId { get; set; }

        public int UserId { get; set; }

        public bool IsCompleted { get; set; }
        
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
    }
}
