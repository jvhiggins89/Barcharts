// File : ProgressPoints.cs
// Description: Model for ProgressPoints.
// Created Date: 11/22/2019
/// Author: Andrew Michael

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Workout495.Models;

namespace Workout495.ViewModels
{
    /// <summary>
    /// ProgressPoints which can be set in the ProgressPoints and Goals funcitonality.
    /// </summary>
    public class ProgressPointsViewModel
    {
        public ProgressPointsViewModel() { }
        public ProgressPointsViewModel(ProgressPoints g)
        {
            Id = g.Id;
            Title = g.Title;
            Description = g.Description;
            Weight = g.Weight;
            BMI = g.BMI;
            this.ProgressPointDate = g.ProgressPointDate;
            Created = g.Created;
            Changed = g.Changed;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public double BMI { get; set; }

        public string UserId { get; set; }
        public DateTime ProgressPointDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Changed { get; set; }

        //User foreign key refernce for linking Users from ProgressPoints
        //public virtual ICollection<ApplicationUser> Users { get; set; }
        //public virtual ICollection<Goals> Goals { get; set; }

        public void Update(ProgressPoints progressPoints)
        {
            progressPoints.Title = Title;
            progressPoints.Weight = Weight;
            progressPoints.Description = Description;
            progressPoints.BMI = BMI;
            progressPoints.ProgressPointDate = ProgressPointDate;
            progressPoints.Changed = DateTime.Now;
        }
    }
}
