// File : Goals.cs
// Description: Model for goals.
// Created Date: 11/22/2019
/// Author: Andrew Michael

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Workout495.Models
{
    /// <summary>
    /// Goals which can be set in the Goals and Progress funcitonality.
    /// </summary>
    public class Goals
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public DateTime GoalDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Changed { get; set; }

        //User foreign key refernce for linking Users from goals
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ProgressPoints> ProgressPoints { get; set; }
    }
}
