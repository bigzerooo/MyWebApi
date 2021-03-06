﻿using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        ILogsService logsService;

        public LogsController(ILogsService logsService) =>
            this.logsService = logsService;

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                return Ok(await logsService.GetAllLogsAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogById(int id)
        {
            try
            {
                return Ok(await logsService.GetLogByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
