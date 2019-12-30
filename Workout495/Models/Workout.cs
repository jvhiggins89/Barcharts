using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Workout495.Models
{
    public class Workout
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
        public virtual ApplicationUser User { get; set; }

        //Constructor sets Active true
        public Workout()
        {
            Active = true;
        }


    }
}
