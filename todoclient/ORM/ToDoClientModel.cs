namespace ORM
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoClientModel : DbContext
    {
        public ToDoClientModel()
            : base("name=TasksModel")
        {
        }

        public virtual DbSet<ActionName> ActionNames { get; set; }
        public virtual DbSet<Action> Actions { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionName>()
                .HasMany(e => e.Actions)
                .WithRequired(e => e.ActionName)
                .HasForeignKey(e => e.ActionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .HasMany(e => e.Actions)
                .WithRequired(e => e.Task)
                .WillCascadeOnDelete(false);
        }
    }
}
