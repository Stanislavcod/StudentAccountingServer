﻿using Microsoft.EntityFrameworkCore;
using StudentAccountin.Model.DatabaseModels;
using StudentAccounting.Common.Constants;
using StudentAccounting.Common.Seeds;
using StudentAccounting.Model.DatabaseModels;
using StudentAccounting.Model.DataBaseModels;

namespace StudentAccounting.Model
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
              .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id = 1, Name = RoleType.User, NormalName = RoleDescription.Get(RoleType.User)},
                    new Role { Id = 2, Name = RoleType.Admin, NormalName = RoleDescription.Get(RoleType.Admin) },
                    new Role { Id = 3, Name = RoleType.GlobalPm, NormalName = RoleDescription.Get(RoleType.GlobalPm) },
                    new Role { Id = 4, Name = RoleType.LocalPm, NormalName = RoleDescription.Get(RoleType.LocalPm) },
                    new Role {Id = 5, Name = RoleType.Director, NormalName = RoleDescription.Get(RoleType.Director)},
                    new Role {Id = 6, Name = RoleType.DirectorOrganizational, NormalName = RoleDescription.Get(RoleType.DirectorOrganizational)}
                });
            modelBuilder
            .Entity<Rank>()
            .HasMany(c => c.Bonuses)
            .WithMany(s => s.Ranks)
            .UsingEntity<RankBonus>(
               j => j
                .HasOne(pt => pt.Bonus)
                .WithMany(t => t.RankBonus)
                .HasForeignKey(pt => pt.BonusId),
            j => j
                .HasOne(pt => pt.Rank)
                .WithMany(p => p.RankBonus)
                .HasForeignKey(pt => pt.RankId),
            j =>
            {
                j.HasKey(t => new { t.RankId, t.BonusId });
                j.ToTable("RankBonus");
            });
            modelBuilder.Entity<Rank>().HasData(
                new Rank[]
                {
                    new Rank { Id = 1, Description = "aaa", MaxMmr = 999, MinMmr = 1, OrganizationId = 1, RankName = "Первый" },
                    new Rank { Id = 2, Description = "bbb", MaxMmr = 999, MinMmr = 1, OrganizationId = 2, RankName = "Второй"}
                });
            modelBuilder.Entity<Organization>().HasData(
                new Organization[]
                {
                    new Organization { Id = 1, Address = "aaa", BSR = 4.5, Contacts = "aaa",
                        FoundationDate = DateTime.Parse("1990-01-01"), Fullname = "Первый", WebSite = "aaa"},
                    new Organization { Id = 2, Address = "aaa", BSR = 4.5, Contacts = "aaa",
                        FoundationDate = DateTime.Parse("1990-01-01"), Fullname = "Второй", WebSite = "aaa"}
                });
            modelBuilder.Entity<Department>().HasData(
                    new Department[]
                    {
                        new Department { Id = 1, FullName = "Department 1", Description = "Description 1",
                            DirectorId = 1, DateStart = DateTime.Now, Status = "Active", OrganizationId = 1 },
                        new Department { Id = 2, FullName = "Department 2", Description = "Description 2",
                            DirectorId = 2, DateStart = DateTime.Now, Status = "Active", OrganizationId = 2 }
                    });

            modelBuilder.Entity<Position>().HasData(
                new Position[]
                {
                        new Position { Id = 1, FullName = "Position 1", Description = "Description 1", DepartmentId = 1 },
                        new Position { Id = 2, FullName = "Position 2", Description = "Description 2", DepartmentId = 2 }
                });
            modelBuilder.Entity<Participants>().HasData(
               new Participants[]
               {
                        new Participants { Id = 1, IndividualsId = 1, DateEntry = DateTime.Now,
                            Mmr = 1000, Status = "Active", GitHub = "github.com/user1" },
                        new Participants { Id = 2, IndividualsId = 2, DateEntry = DateTime.Now,
                            Mmr = 1200, Status = "Active", GitHub = "github.com/user2" }
               });
            modelBuilder.Entity<Employment>().HasData(
                new Employment[]
                {
                        new Employment { Id = 1, DateStart = DateTime.Now, DateEnd = DateTime.Now.AddDays(30),
                            isActive = "Yes", Status = "Active", StatusDescription = "Description 1", ParticipantsId = 1, PositionId = 1 },
                        new Employment { Id = 2, DateStart = DateTime.Now, DateEnd = DateTime.Now.AddDays(30),
                            isActive = "Yes", Status = "Active", StatusDescription = "Description 2", ParticipantsId = 2, PositionId = 2 }
                });

            modelBuilder.Entity<Individuals>().HasData(
                new Individuals[]
                {
                    new Individuals { Id = 1, DateOfBirth = DateTime.Now, FIO = "первый", Gender = "aaa", Mail = "aaa",
                     Phone = "aaa", SocialNetwork = "aaa"},
                    new Individuals { Id = 2, DateOfBirth = DateTime.Now, FIO = "второй", Gender = "aaa", Mail = "aaa",
                     Phone = "aaa", SocialNetwork = "aaa"}
                });
            //modelBuilder.Entity<User>().HasData(
            //    new User[]
            //    {
            //        new User { Id =1, RoleId = 1, Login = "Stas", PasswordHash = System.Text.Encoding.UTF8.GetBytes("123456"),
            //            PasswordSalt =System.Text.Encoding.UTF8.GetBytes("2427") },
            //        new User { Id =2, RoleId = 3, Login = "Ilya", PasswordHash = System.Text.Encoding.UTF8.GetBytes("12345"),
            //            PasswordSalt =System.Text.Encoding.UTF8.GetBytes("2538")},
            //        new User { Id =3,RoleId = 3, Login = "Pavel", PasswordHash = System.Text.Encoding.UTF8.GetBytes("1234"),
            //            PasswordSalt =System.Text.Encoding.UTF8.GetBytes("151515")},
            //        new User { Id=4,RoleId =4, Login = "Roman", PasswordHash = System.Text.Encoding.UTF8.GetBytes("123"),
            //            PasswordSalt =System.Text.Encoding.UTF8.GetBytes("5515")}
            //    });
            //        modelBuilder.Entity<Rank>().HasData(
            //    new Rank
            //    {
            //        Id = 1,
            //        RankName = "Rank 1",
            //        Description = "Description for Rank 1",
            //        MaxMmr = 1000,
            //        MinMmr = 0,
            //        OrganizationId = 1
            //    },
            //    new Rank
            //    {
            //        Id = 2,
            //        RankName = "Rank 2",
            //        Description = "Description for Rank 2",
            //        MaxMmr = 2000,
            //        MinMmr = 1001,
            //        OrganizationId = 1
            //    }
            //);

            //        modelBuilder.Entity<Bonus>().HasData(
            //            new Bonus
            //            {
            //                Id = 1,
            //                BonusName = "Bonus 1",
            //                BonusDescription = "Description for Bonus 1"
            //            },
            //            new Bonus
            //            {
            //                Id = 2,
            //                BonusName = "Bonus 2",
            //                BonusDescription = "Description for Bonus 2"
            //            }
            //        );

            //        modelBuilder.Entity<RankBonus>().HasData(
            //            new RankBonus
            //            {
            //                Id= 1,
            //                RankId = 2,
            //                BonusId = 1
            //            },
            //            new RankBonus
            //            {
            //                Id = 2,
            //                RankId = 2,
            //                BonusId = 2
            //            }
            //        );
            //modelBuilder.Entity<Individuals>().HasData(
            //    new Individuals[]
            //    {
            //        new Individuals{ FIO = "Илья Давыдов Александрович", Id = 1, Gender = "Мужчина", Mail = "ilya5607@gmail.com", Phone = "+3542682351", SocialNetwork ="https://vk.com/ilya57061", DateOfBirth = DateTime.Parse("01/09/2002")},
            //        new Individuals{ FIO = "Дрык Станислав Геннадьевич", Id = 2, Gender = "Мужчина", Mail = "dryk.stas@gmail.com", Phone = "+35474557", SocialNetwork ="https://vk.com/id158119349", DateOfBirth = DateTime.Parse("01/10/2002")}
            //    });
            //modelBuilder.Entity<Student>().HasData(
            //    new Student[]
            //    {
            //        new Student{ CourseNumber = 3, Group = "20ИТ-1", Id = 1, IndividualsId = 1, University = "Polessu", StudentCard = 5254458545631459},
            //        new Student{ CourseNumber = 3, Group = "20ИТ-1", Id = 2, IndividualsId = 2, University = "Polessu", StudentCard = 4523542686597542}
            //    });
            //modelBuilder.Entity<Participants>().HasData(
            //    new Participants[]
            //    {
            //        new Participants{ Id =1, DateEntry = DateTime.Parse("01/09/2002"), GitHub = "https://github.com/Ilya57061", IndividualsId=1, Status = "Cтудент",
            //         UserId = 2, Mmr = 10000},
            //        new Participants{ Id =2, DateEntry = DateTime.Parse("01/09/2002"), GitHub = "https://github.com/Stanislavcod", IndividualsId=2, Status = "Cтудент",
            //         UserId = 1, Mmr = 10000}
            //    });
            //modelBuilder.Entity<ApplicationsInTheProject>().HasData(
            //    new ApplicationsInTheProject[]
            //    {
            //        new ApplicationsInTheProject { Id = 1, DateEntry = DateTime.Parse("10/01/2023"), WorkStatus = "В работе", VacancyId =1, ParticipantsId = 1},
            //        new ApplicationsInTheProject { Id = 2, DateEntry = DateTime.Parse("01/01/2023"), WorkStatus = "Тестирование", VacancyId = 2, ParticipantsId =2}
            //    });
            //modelBuilder.Entity<Bonus>().HasData(
            //    new Bonus[]
            //    {
            //        new Bonus { Id = 1, BonusDescription = "2 базовых", BonusName = "Деньги", RankId = 1},
            //        new Bonus { Id = 2, BonusDescription = "1 выходной", BonusName = "Выходные", RankId = 2}
            //    });
            //modelBuilder.Entity<Customer>().HasData(
            //    new Customer[]
            //    {
            //        new Customer {Id = 1, Address = "Пушкина 4", Contacts = "+375298695418", Description = "БрестМясоМолПром", FullName = "Бресткий и т.д", WebSite = "www"},
            //        new Customer {Id = 2, Address = "Кулькова 26", Contacts = "+375297489526", Description = "Комбикорм", FullName = "Пинские комбикорма", WebSite = "www"}
            //    });
            //modelBuilder.Entity<Department>().HasData(
            //    new Department[]
            //    {
            //        new Department {Id = 1, FullName = "Ит отдел", Description = "Айти отдел", DateStart = DateTime.Parse("01/01/2023"), Status = "Функционирует", OrganizationId = 1},
            //        new Department {Id = 2, FullName = "Pm отдел", Description = "Проджект менеджер отдел", DateStart = DateTime.Parse("05/01/2023"), Status = "Функционирует почти", OrganizationId = 2}
            //    });
            //modelBuilder.Entity<Employment>().HasData(
            //    new Employment[]
            //    {
            //        new Employment { Id = 1, Status = "Устроен", DateStart = DateTime.Parse("01/01/2023"), StatusDescription = "Проджект менеджер", ParticipantsId= 2, PositionId = 1 },
            //        new Employment { Id = 2, Status = "Неа", DateStart = DateTime.Parse("03/01/2023"), StatusDescription = "Фронт" , ParticipantsId = 2, PositionId = 2}
            //    });
            //modelBuilder.Entity<FinalProject>().HasData(
            //    new FinalProject[]
            //    {
            //        new FinalProject { Id = 1, DateStart = DateTime.Parse("10/01/2023"), Description = "Хорош", GitHub = "www.github", Links = "www.vk", Name = "МинскТракторЗавод", EmploymentId = 1},
            //        new FinalProject { Id = 2, DateStart = DateTime.Parse("01/01/2023"), Description = "МегаХорош", GitHub = "www.github", Links = "www.vk", Name = "КобинХлеб", EmploymentId = 2}
            //    });
            //modelBuilder.Entity<Organization>().HasData(
            //    new Organization[]
            //    {
            //        new Organization {Id=1, Address = "Брест, Советская 13", Contacts = "+375296598412", Fullname = "NikeBrest", WebSite = "www.nike", FoundationDate = DateTime.Parse("01/01/2023")},
            //        new Organization {Id=2, Address = "Кобри, Ленина 59", Contacts = "+375294789615", Fullname = "Молоко кобринское", WebSite = "www.milkkBR", FoundationDate = DateTime.Parse("03/01/2023")}
            //    });
            //modelBuilder.Entity<Vacancy>().HasData(
            //    new Vacancy[]
            //    {
            //        new Vacancy {Id =1, Budjet = 12665, DateStart = DateTime.Parse("12/12/2022"), DateEnd = DateTime.Parse("30/12/2022"), Descriptions = "Хорошая работа", Name = "Pm", Responsibilities = "communication", StagesOfProjectId = 1, isOpened = false},
            //        new Vacancy {Id =2, Budjet = 5, DateStart = DateTime.Parse("10/12/2022"), DateEnd = DateTime.Parse("12/12/2022"), Descriptions = "работа", Name = "front-end", Responsibilities = "c#", StagesOfProjectId = 2, isOpened = true}
            //    });
            //modelBuilder.Entity<TrainingCourses>().HasData(
            //    new TrainingCourses[]
            //    {
            //        new TrainingCourses { Id = 1, Name = "ИИ", Description = "Курсы Курск", Link = "www"},
            //        new TrainingCourses { Id = 2, Name = "Mobile", Description = "Курсы Курск", Link = "www"}
            //    });
            //modelBuilder.Entity<StagesOfProject>().HasData(
            //    new StagesOfProject[]
            //    {
            //        new StagesOfProject {Id= 1, Name = "Тестирование", Description = "TestUnitApp", DateStart = DateTime.Parse("17/11/2022"), ProjectId = 1, Status = "В процессе"},
            //        new StagesOfProject {Id= 2, Name = "Дизайн", Description = "Разработка дизайна", DateStart = DateTime.Parse("12/11/2022"), DateEnd = DateTime.Parse("15/12/2022"), ProjectId =2, Status = "Завершено"}
            //    });
            //modelBuilder.Entity<Regulation>().HasData(
            //    new Regulation[]
            //    {
            //        new Regulation {Id=1, Name = "Не оскорблять", Description = "Сразу бан", Text = "ОСКОРБЛЕНИЕ - БАН!", OrganizationId = 1},
            //        new Regulation {Id=2, Name = "Не кричать", Description = "Сразу бан", Text = "КРИК- БАН!", OrganizationId = 2}
            //    });
            //modelBuilder.Entity<Rank>().HasData(
            //    new Rank[]
            //    {
            //        new Rank { Id = 1, Description = "Новичек", RankName = "Джун", OrganizationId = 1},
            //        new Rank { Id = 2, Description = "Опытен", RankName = "Мидл", OrganizationId = 2}
            //    });
            //modelBuilder.Entity<Project>().HasData(
            //    new Project[]
            //    {
            //        new Project {Id = 1, Fullname = "nice", Description = "nice project", DateStart = DateTime.Parse("05/10/2022"), Status = "В разработке", TechnicalSpecification = "Site", CustomerId = 1, idLocalPM = 1},
            //        new Project {Id = 2, Fullname = "bad", Description = "bad project", DateStart = DateTime.Parse("01/12/2022"), DateEnd = DateTime.Parse("05/12/2022"), Status = "Конец", TechnicalSpecification = "Приложение", CustomerId =2, idLocalPM = 2}
            //    });
            //modelBuilder.Entity<Position>().HasData(
            //    new Position[]
            //    {
            //        new Position {Id =1, FullName = "Pm", Description = "Главный самый", DepartmentId =1},
            //        new Position {Id =2, FullName = "back-end", Description = "Заместитель директора", DepartmentId =2}
            //    });
            //modelBuilder.Entity<EducationalPortals>().HasData(
            //    new EducationalPortals[]
            //    {
            //        new EducationalPortals {Id = 1, DepartmentId = 1, Description = "Искусственный интелект", Name = "ИИ", Link = "www"},
            //        new EducationalPortals {Id = 2, DepartmentId = 2, Description = "Мобильная разработка", Name = "ModelDevelop", Link = "www"}
            //    });
            //modelBuilder.Entity<RegistrationForCourses>().HasData(
            //    new RegistrationForCourses[]
            //    {
            //        new RegistrationForCourses {Id = 1, DateEntry = DateTime.Parse("05/01/2023"), ParticipantsId = 1, TrainingCoursesId = 1},
            //        new RegistrationForCourses {Id = 2, DateEntry = DateTime.Parse("10/01/2023"), ParticipantsId = 2, TrainingCoursesId = 2}
            //    });
            //modelBuilder.Entity<ScheduleOfСlasses>().HasData(
            //    new ScheduleOfСlasses[]
            //    {
            //        new ScheduleOfСlasses {Id = 1, DateStart = DateTime.Parse("2023/01/25 10:00:00"), DateEnd = DateTime.Parse("2023/01/25 12:00:00"),
            //            Description = "English", WorkSpaceLink = "www", TrainingCoursesId = 1},
            //        new ScheduleOfСlasses {Id = 2, DateStart = DateTime.Parse("2023/01/25 13:00:00"), DateEnd = DateTime.Parse("2023/01/25 14:15:00"),
            //            Description = "MobDev", WorkSpaceLink = "www", TrainingCoursesId = 2}
            //    });

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
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EducationalPortals> EducationalPortals { get; set; }
        public DbSet<RegistrationForCourses> RegistrationForCourses { get; set; }
        public DbSet<ScheduleOfСlasses> ScheduleOfСlasses { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RankBonus> RankBonus { get; set; }
    }
}
