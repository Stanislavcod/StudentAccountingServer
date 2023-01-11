using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options): base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id =1, IsAdmin = true, Login = "Stas", Password = "123456" },
                    new User { Id =2, IsAdmin = true, Login = "Ilya", Password = "12345"},
                    new User { Id =3, IsAdmin = true, Login = "Pavel", Password = "1234"},
                    new User { Id=4, IsAdmin = false, Login = "Roman", Password = "123"}
                });
            modelBuilder.Entity<Individuals>().HasData(
                new Individuals[]
                {
                    new Individuals{ FIO = "Илья Давыдов Александрович", Id = 1, Gender = "Мужчина", Mail = "ilya5607@gmail.com", Phone = "+3542682351", SocialNetwork ="https://vk.com/ilya57061", DateOfBirth = DateTime.Parse("01/09/2002")},
                    new Individuals{ FIO = "Дрык Станислав Геннадьевич", Id = 2, Gender = "Мужчина", Mail = "dryk.stas@gmail.com", Phone = "+35474557", SocialNetwork ="https://vk.com/id158119349", DateOfBirth = DateTime.Parse("01/10/2002")}
                });
            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                    new Student{ CourseNumber = 3, Group = "20ИТ-1", Id = 1, IndividualsId = 1, University = "Polessu", StudentCard = 5254458545631459},
                    new Student{ CourseNumber = 3, Group = "20ИТ-1", Id = 2, IndividualsId = 2, University = "Polessu", StudentCard = 4523542686597542}
                });
            modelBuilder.Entity<Participants>().HasData(
                new Participants[]
                {
                    new Participants{ Id =1, DateEntry = DateTime.Parse("01/09/2002"), GitHub = "https://github.com/Ilya57061", IndividualsId=1, Status = "Cтудент",
                     UserId = 2},
                    new Participants{ Id =2, DateEntry = DateTime.Parse("01/09/2002"), GitHub = "https://github.com/Stanislavcod", IndividualsId=2, Status = "Cтудент",
                     UserId = 1}
                });
        }
        public DbSet<ApplicationsInTheProject> ApplicationsInTheProjects { get; set; }
        public DbSet<Employment> Employments { get; set; }
        public DbSet<FinalProject> FinalProjects { get; set; }
        public DbSet<Regulation> Regulations { get; set; }
        public DbSet<StagesOfProject> StagesOfProjects { get; set; }
        public DbSet<TrainingCourses> TrainingCourses { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Individuals> Individuals { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Rang> Rangs { get; set; }
        public DbSet<Student> Students {get; set;}
    }
}
