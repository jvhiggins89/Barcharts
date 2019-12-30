using Workout495.Models;

namespace Workout495.ViewModels
{
    public class ApplicationUserViewModel
    {
        public ApplicationUserViewModel(ApplicationUser applicionUser)
        {
            Id = applicionUser.Id;
            UserName = applicionUser.UserName;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
    }
}
