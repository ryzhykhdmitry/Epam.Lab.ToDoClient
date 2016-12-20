namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Action
    {
        public int Id { get; set; }

        public int TaskId { get; set; }

        public int ActionId { get; set; }

        public virtual ActionName ActionName { get; set; }

        public virtual Task Task { get; set; }
    }
}
