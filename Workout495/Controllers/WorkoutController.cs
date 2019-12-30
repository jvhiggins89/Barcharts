using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout495.Data;
using Workout495.Models;
using Workout495.ViewModels;
using Workout495.Services;

namespace Workout495.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : ControllerBase
    {

        //       private readonly Workout495Context _context;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IApplicationUserService applicationUserService, IWorkoutService workoutService) {
            //           _context = context;
            _applicationUserService = applicationUserService;
            _workoutService = workoutService;
        }

        // GET: Workout
        [HttpGet]

        public async Task<IEnumerable<WorkoutViewModel>> GetWorkouts()
        {
            var CurrentUserId = _applicationUserService.GetCurrentUserAsync(User).Result.Id;
            var Workouts = await _workoutService.GetWorkoutsByUserAsync(CurrentUserId);
            return Workouts.Select(e => new WorkoutViewModel(e, true));

        }


        [HttpGet("{id}")]

        public async Task<WorkoutViewModel> GetWorkoutById(int id)
        {
            var Workout = await _workoutService.GetWorkoutByIdAsync(id);
            return new WorkoutViewModel(Workout);

        }

        [Route("available")]
        [HttpGet]
        public async Task<IEnumerable<ExerciseViewModel>> GetAvailableExercises()
        {
            var CurrentUserId = _applicationUserService.GetCurrentUserAsync(User).Result.Id;
            var Exercises = await _workoutService.GetAvailableExercisesAsync(CurrentUserId);
            return Exercises.Select(e => new ExerciseViewModel(e));
        }

        [HttpPost]
        public async Task<ActionResult<Workout>> SaveWorkout([FromBody]WorkoutViewModel workoutViewModel)
        {
            Workout entity;
            if(workoutViewModel.Id == 0)
            {
                entity = await _workoutService.CreateNewAsync();
                entity.User = await _applicationUserService.GetCurrentUserAsync(User);
            }
            else
            {
                entity = await _workoutService.GetWorkoutByIdAsync(workoutViewModel.Id);
                if (entity == null) return BadRequest();
            }

            workoutViewModel.Update(entity);
            await _workoutService.SaveChangesAsync();

            return Ok(new WorkoutViewModel(entity));
        }

        [HttpPut]
        //INCOMPLETE
        public async Task<ActionResult<Workout>> ChangeWorkout([FromBody]WorkoutViewModel workoutViewModel)
        {
            Workout entity;
            entity = await _workoutService.GetWorkoutByIdAsync(workoutViewModel.Id);
            workoutViewModel.Update(entity);
            await _workoutService.SaveChangesAsync();

            return Ok(new WorkoutViewModel(entity));
        }


        /*
        
        // GET: Workout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Workout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workout/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Workout/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Workout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Workout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Workout/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    */
    }
}