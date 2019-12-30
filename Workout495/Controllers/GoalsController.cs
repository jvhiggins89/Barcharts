// File : GoalsController.cs
// Description: controller for goals.
// Created Date: 11/22/2019
/// Author: Andrew Michael
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workout495.Data;
using Workout495.Models;
using Workout495.Services;
using Workout495.ViewModels;

namespace Workout495.Controllers
{
    /// <summary>
    /// Goals crud operations controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalsService _goalsService;
        private readonly IApplicationUserService _applicationUserService;

        public GoalsController(IGoalsService GoalService, IApplicationUserService applicationUserService)
        {
            _goalsService = GoalService;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<GoalsViewModel>> GetGoals()
        {//possible refactor for clean up of this
            //var CurrentUserId = _applicationUserService.GetCurrentUserAsync(User).Result.Id;
            var currentUser = _applicationUserService.GetCurrentUserAsync(User);
            var CurrentUserId = currentUser.Result.Id;
            var Goals = await _goalsService.GetGoalsByUserAsync(CurrentUserId);
            return Goals.Select(e => new GoalsViewModel(e));
        }

        [HttpPost]
        public async Task<ActionResult<Goals>> SaveGoals([FromBody]GoalsViewModel goalsViewModel)
        {
            Goals entity;
            if (goalsViewModel.Id == 0)
            {
                entity = await _goalsService.CreateNewAsync();
                entity.User = await _applicationUserService.GetCurrentUserAsync(User);
            }
            else
            {
                entity = await _goalsService.GetGoalsByIdAsync(goalsViewModel.Id);
                if (entity == null) return BadRequest();
            }

            goalsViewModel.Update(entity);
            await _goalsService.SaveChangesAsync();

            return Ok(new GoalsViewModel(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteGoalsAsync(int id)
        {
            var goals = await _goalsService.GetGoalsByIdAsync(id);
            if (goals == null)
            {
                return NotFound();
            }

            await _goalsService.RemoveGoals(goals);

            return Ok(true);
        }
    }
}
