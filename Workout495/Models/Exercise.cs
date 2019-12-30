namespace Workout495.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int NumberOfCompletions { get; set; }
        public int? WorkoutId { get; set; }
        public float Weight { get; set; }
        public virtual Workout Workout { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
