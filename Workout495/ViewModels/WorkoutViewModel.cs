using System;
using System.Collections.Generic;
using System.Linq;
using Workout495.Models;

namespace Workout495.ViewModels
{
    public class WorkoutViewModel
    {
        public WorkoutViewModel() { }

        public WorkoutViewModel(Workout workout, bool includeExercises = true)
        {
            Id = workout.Id;
            Name = workout.Name;
            Exercises = (includeExercises && workout.Exercises != null )? workout.Exercises.Select(e => new ExerciseViewModel(e)).ToList() : new List<ExerciseViewModel>();
            UserId = workout.User?.Id;
            ScheduledDate = workout.ScheduledDate;
            Active = workout.Active;

        }


        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }

        public DateTime? ScheduledDate { get; set; }

        public bool Active { get; set; }

        public List<ExerciseViewModel> Exercises { get; set; } = new List<ExerciseViewModel>();

        public void Update(Workout workout)
        {
            workout.Name = Name;
            workout.ScheduledDate = ScheduledDate;
            workout.Active = Active;
            
            if(workout.Exercises == null)
            {
                workout.Exercises = new List<Exercise>();
            }
            
            //Remove exercises not in vm
            RemoveExercises(workout);
            //Add exercises not in entity
            AddExercises(workout);

        }

        private void RemoveExercises(Workout workout)
        {
            List<Exercise> toBeRemoved = new List<Exercise>();
            
            foreach(Exercise wExercise in workout.Exercises)
            {
                bool remove = true;

                foreach(ExerciseViewModel vmExercise in Exercises)
                {
                    if(wExercise.Id == vmExercise.Id)
                    {
                        remove = false;
                        break;
                    }
                }

                if (remove)
                {
                    wExercise.Workout = null;
                    wExercise.WorkoutId = null;
                    toBeRemoved.Add(wExercise);
                }
            }

            foreach(Exercise e in toBeRemoved)
            {
                workout.Exercises.Remove(e);
            }
        }

        private void AddExercises(Workout workout)
        {
            foreach(ExerciseViewModel vmExercise in Exercises)
            {
                bool add = true;

                foreach(Exercise wExercise in workout.Exercises)
                {
                    if(vmExercise.Id == wExercise.Id)
                    {
                        add = false;
                        break;
                    }
                }

                if (add)
                {
                    Exercise texercise = new Exercise();
                    texercise.Id = vmExercise.Id;
                    texercise.Name = vmExercise.Name;
                    texercise.NumberOfCompletions = vmExercise.NumberOfCompletions;
                    texercise.Reps = vmExercise.Reps;
                    texercise.Sets = vmExercise.Sets;
                    texercise.Weight = vmExercise.Weight;

                    workout.Exercises.Add(texercise);
                }
            }
        }
    }
}
