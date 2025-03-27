using GoRestUserManager.Models;
using GoRestUserManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoRestUserManager.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _userService.CreateUserAsync(model);

            if (response)
                return Ok();

            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await _userService.UpdateUserAsync(model);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return result ? Ok() : BadRequest();
        }
    }
}
