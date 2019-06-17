using System.Collections.Generic;
using System.Data.Entity;
using CheckPoint.Model.Entities;

namespace CheckPoint.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=CheckPointDB")
        {
            Database.SetInitializer(new ApplicationContextInitializer());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ShiftCheck> ShiftChecks { get; set; }
    }

    public class ApplicationContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            List<Post> posts = new List<Post>
            {
                new Post() {Name = "Директор"},
                new Post() {Name = "Программист"},
                new Post() {Name = "Доктор"},
                new Post() {Name = "Инженер"},
                new Post() {Name = "Экономист"},
            };
            context.Posts.AddRange(posts);
            context.SaveChanges();

            List<Employee> employees = new List<Employee>()
            {
                new Employee() { BarCode = "10001", FirstName = "Olekso", LastName = "Potapov", PostId = 2},
                new Employee() { BarCode = "10002", FirstName = "Serhiy", LastName = "Cvetkov", PostId = 1},
                new Employee() { BarCode = "10003", FirstName = "Dmytro", LastName = "Ukolov", PostId = 3},
                new Employee() { BarCode = "10004", FirstName = "Petro", LastName = "Smeshko", PostId = 5},
                new Employee() { BarCode = "10005", FirstName = "Nataliya", LastName = "Stecenko", PostId = 4},
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }

}