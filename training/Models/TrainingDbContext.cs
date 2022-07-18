using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace training.Models
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext() : base("TrainingConnectionString")
        {

        }

        public DbSet<Room> rooms { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}