/*
 * Acidity V3 Backend - Root Controller
 * Copyright (c) 2022 EmeraldSys, all rights reserved.
*/

using Microsoft.AspNetCore.Mvc;

namespace AcidityV3Backend.Controllers
{
    [Route("")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { Status = "OK" });
        }

        [HttpGet("discord")]
        public IActionResult DiscordGet()
        {
            return Redirect("https://discord.gg/C8CbA25Fba");
        }
    }
}
