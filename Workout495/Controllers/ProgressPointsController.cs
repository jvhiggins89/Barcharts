// File : ProgressPointsController.cs
// Description: Model for ProgressPoints.
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
    /// ProgressPoints can be related to ProgressPoints and mark the workout progress of the user.
    /// Progress points don't necessarily have to reference ProgressPoints. ProgressPoints can have one or more
    /// progress points but progress points can have only one goal.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressPointsController : ControllerBase
    {
        private readonly IProgressPointsService _ProgressPointservice;
        private readonly IApplicationUserService _applicationUserService;

        public ProgressPointsController(IProgressPointsService ProgressPointservice, IApplicationUserService applicationUserService)
        {
            _ProgressPointservice = ProgressPointservice;
            _applicationUserService = applicationUserService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProgressPointsViewModel>> GetProgressPoints()
        {//possible refactor for clean up of this
            var CurrentUserId = _applicationUserService.GetCurrentUserAsync(User).Result.Id;
            var ProgressPoints = await _ProgressPointservice.GetProgressPointsByUserAsync(CurrentUserId);
            return ProgressPoints.Select(e => new ProgressPointsViewModel(e));
        }

        [HttpPost]
        public async Task<ActionResult<ProgressPoints>> SaveProgressPoint([FromBody]ProgressPointsViewModel ppViewModel)
        {
            ProgressPoints entity;
            if (ppViewModel.Id == 0)
            {
                entity = await _ProgressPointservice.CreateNewAsync();
                entity.User = await _applicationUserService.GetCurrentUserAsync(User);
            }
            else
            {
                entity = await _ProgressPointservice.GetProgressPointsByIdAsync(ppViewModel.Id);
                if (entity == null) return BadRequest();
            }

            ppViewModel.Update(entity);
            await _ProgressPointservice.SaveChangesAsync();

            return Ok(new ProgressPointsViewModel(entity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProgressPointsAsync(int id)
        {
            var goals = await _ProgressPointservice.GetProgressPointsByIdAsync(id);
            if (goals == null)
            {
                return NotFound();
            }

            var result = await _ProgressPointservice.RemoveProgressPoints(goals);

            return Ok(true);
        }
    }
}
