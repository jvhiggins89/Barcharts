using Workout495.Models;

namespace Workout495.ViewModels
{
    public class ExerciseViewModel
    {
        public ExerciseViewModel() { }

        public ExerciseViewModel(Exercise exercise)
        {
            Id = exercise.Id;
            Name = exercise.Name;
            Sets = exercise.Sets;
            Reps = exercise.Reps;
            NumberOfCompletions = exercise.NumberOfCompletions;
            Workout = exercise.Workout != null ? new WorkoutViewModel(exercise.Workout, false) : null;

            if(User != null)
                UserId = exercise.User.Id;
            
            if(User != null)
                User = exercise.User != null ? new ApplicationUserViewModel(exercise.User) : null;
            
            Weight = exercise.Weight;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int NumberOfCompletions { get; set; }
        public float Weight { get; set; }
        public string UserId { get; set; }
        public WorkoutViewModel Workout { get; set; }
        public ApplicationUserViewModel User { get; set; }


        public void Update(Exercise exercise)
        {
            exercise.Name = Name;
            exercise.Sets = Sets;
            exercise.Reps = Reps;
            exercise.NumberOfCompletions = NumberOfCompletions;
        }
    }
}
