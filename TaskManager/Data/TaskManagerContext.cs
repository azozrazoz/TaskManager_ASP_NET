using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager;

namespace TaskManager.Data
{
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext (DbContextOptions<TaskManagerContext> options)
            : base(options)
        {
        }

        public DbSet<TaskManager.CategoryTask> CategoryTask { get; set; } = default!;
        public DbSet<TaskManager.UserTask> UserTask { get; set; } = default!;
        public DbSet<TaskManager.TaskList> TaskList { get; set; } = default!;
    }
}
