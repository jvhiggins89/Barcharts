// File : Goals.cs
// Description: ViewModel for goals.
// Created Date: 11/22/2019
/// Author: Andrew Michael

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Workout495.Models;

namespace Workout495.ViewModels
{
    /// <summary>
    /// Goals which can be set in the Goals and Progress funcitonality.
    /// </summary>
    public class GoalsViewModel
    {
        public GoalsViewModel() { }
        public GoalsViewModel(Goals g)
        {
            Id = g.Id;
            Title = g.Title;
            Description = g.Description;
            Weight = g.Weight;
            BMI = g.BMI;
            GoalDate = g.GoalDate;
            Created = g.Created;
            Changed = g.Changed;
        }
        
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        [Range(1, 1000)]
        public double Weight { get; set; }
        [Range(1, 99)]
        public double BMI { get; set; }
        [Required]
        public DateTime GoalDate { get; set; }
        public DateTime? Created { get;  }
        public DateTime? Changed { get;  }

        public string UserId { get; set; }
        public ApplicationUserViewModel User { get; set; }


        //User foreign key refernce for linking Users from goals
        //public virtual ICollection<ApplicationUser> Users { get; set; }

        public void Update(Goals goals)
        {
            
            goals.Title = Title;
            goals.Weight = Weight;
            goals.BMI = BMI;
            goals.Description = Description;
            goals.GoalDate = GoalDate;
            goals.Changed = DateTime.Now;
            goals.Created = DateTime.Now;
        }
    }
}
