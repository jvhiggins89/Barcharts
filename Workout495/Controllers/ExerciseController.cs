using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Workout495.Models;
using Workout495.Services;
using Workout495.ViewModels;

namespace Workout495.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        private readonly IApplicationUserService _applicationUserService;

        public ExerciseController(IExerciseService exerciseService, IApplicationUserService applicationUserService)
        {
            _exerciseService = exerciseService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<ExerciseViewModel>> GetExercises()
        {//possible refactor for clean up of this
            var CurrentUserId = _applicationUserService.GetCurrentUserAsync(User).Result.Id;
            var Exercises = await _exerciseService.GetExercisesByUserAsync(CurrentUserId);
            return Exercises.Select(e => new ExerciseViewModel(e));
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> SaveExercise([FromBody]ExerciseViewModel exerciseViewModel)
        {
            Exercise entity;
            if (exerciseViewModel.Id == 0)
            {
                entity = await _exerciseService.CreateNewAsync();
                entity.User = await _applicationUserService.GetCurrentUserAsync(User);
            }
            else
            {
                entity = await _exerciseService.GetExerciseByIdAsync(exerciseViewModel.Id);
                if (entity == null) return BadRequest();
            }

            exerciseViewModel.Update(entity);
            await _exerciseService.SaveChangesAsync();

            return Ok(new ExerciseViewModel(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteExerciseAsync(int id)
        {
            var exercise = await _exerciseService.GetExerciseByIdAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

           var result = await _exerciseService.RemoveExercise(exercise);
           
            return Ok(true);
        }
    }
}
