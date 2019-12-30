// File : ProgressPoints.cs
// Description: Model for ProgressPoints.
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
    /// ProgressPoints which can be set in the ProgressPoints and Goals funcitonality.
    /// </summary>
    public class ProgressPoints
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }
        public DateTime ProgressPointDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Changed { get; set; }

        //User foreign key refernce for linking Users from ProgressPoints
        public virtual ApplicationUser User { get; set; }
        //public virtual ICollection<Goals> Goals { get; set; }
    }
}
