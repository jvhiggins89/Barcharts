using Workout495.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Workout495.Data
{
    public class Workout495Context : ApiAuthorizationDbContext<ApplicationUser>
    {
        public Workout495Context(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<Goals> Goals { get; set; }
        public DbSet<ProgressPoints> ProgressPoints { get; set; }

        public DbSet<Exercise> Exercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            var random = new Random();

            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                Name = "Air Squat of Death",
                NumberOfCompletions = random.Next(1, 101),
                Reps = random.Next(1, 13),
                Sets = random.Next(1, 7),
                Weight = random.Next(1, 100),
                WorkoutId = 1

            },
           new Exercise
           {
               Id = 2,
               Name = "Incline Dumbell Press With Swim Fins on",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 3,
               Name = "Super Set for Super Abs",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 4,
               Name = "Workout 4",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 5,
               Name = "Workout 5",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 6,
               Name = "Workout 6",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 7,
               Name = "Workout 7",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 8,
               Name = "Workout 8",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 9,
               Name = "Workout 9",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 10,
               Name = "Workout 10",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 11,
               Name = "Workout 11",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 12,
               Name = "Workout 12",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           },
           new Exercise
           {
               Id = 13,
               Name = "Workout 13",
               NumberOfCompletions = random.Next(1, 101),
               Reps = random.Next(1, 13),
               Sets = random.Next(1, 7),
               Weight = random.Next(1, 100),
               WorkoutId = 2
           });


            modelBuilder.Entity<Workout>().HasData(new Workout
            {
                Id = 1,
                Name = "Workout 1",
                Active = true,
                ScheduledDate = DateTime.Now.AddDays(1)

            },
            new Workout
            {
                Id = 2,
                Name = "Workout 2",
                ScheduledDate = DateTime.Now.AddDays(2)
            },
             new Workout
             {
                 Id = 3,
                 Name = "Workout 3",
                 ScheduledDate = DateTime.Now.AddDays(3)
             }
            );

            modelBuilder.Entity<Goals>().HasData(new Goals
            {
                Id = 1,
                Title = "Goal 1",
                Description = "Goal 1 Description.",
                Weight = Convert.ToDouble(random.Next(100, 250)),
                BMI = Convert.ToDouble(random.Next(8, 30)),
                GoalDate = DateTime.Parse("01/01/2019"),
                Changed = DateTime.Now,
                Created = DateTime.Now
            },
            new Goals
            {
                Id = 2,
                Title = "Goal 2",
                Description = "Goal 2 Description.",
                Weight = Convert.ToDouble(random.Next(100, 250)),
                BMI = Convert.ToDouble(random.Next(8, 30)),
                GoalDate = DateTime.Parse("01/02/2019"),
                Changed = DateTime.Now,
                Created = DateTime.Now
            });

            modelBuilder.Entity<ProgressPoints>().HasData(new ProgressPoints
            {
                Id = 1,
                Title = "ProgressPoint 1",
                Description = "ProgressPoint 1 Description.",
                Weight = Convert.ToDouble(random.Next(100, 250)),
                BMI = Convert.ToDouble(random.Next(8, 30)),
                ProgressPointDate = DateTime.Parse("01/01/2019"),
                Changed = DateTime.Now,
                Created = DateTime.Now

            },
            new ProgressPoints
            {
                Id = 2,
                Title = "ProgressPoint 2",
                Description = "ProgressPoint 2 Description.",
                Weight = Convert.ToDouble(random.Next(100, 250)),
                BMI = Convert.ToDouble(random.Next(8, 30)),
                ProgressPointDate = DateTime.Parse("01/02/2019"),
                Changed = DateTime.Now,
                Created = DateTime.Now

            });


        }
    }

}
