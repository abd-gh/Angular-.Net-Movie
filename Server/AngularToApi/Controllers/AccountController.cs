using AngularToApi.Models;
using AngularToApi.Models.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AngularToApi.Controllers
{
    [Route("[controller]")]
    [ApiController]

  
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDb _db;
        private readonly UserManager<ApplicationUser> _manager;

        public AccountController(ApplicationDb db, UserManager<ApplicationUser> manage)// to manage register
        {
            _db= db;
            _manager = manage;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                if (EmailExistes(model.Email))
                {
                    return BadRequest("Email already exist");
                }
                if (UserExistes(model.UserName))
                {
                    return BadRequest("UserName already exist");
                }

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PasswordHash = model.Password
                };

                var result = await _manager.CreateAsync(user,  model.Password);
                if (result.Succeeded)
                {
                    // await _manager.UpdateAsync(user);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            return StatusCode(StatusCodes.Status404NotFound);
        }

     /*   [HttpGet]
        [Route("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (username == null || password == null)
                return NotFound();
            else if(UserExistes(username))
            {
                var checkpassword= _db.Users.Where(x=>x.UserName == username && ).FirstOrDefault();
            }
        }*/
        private bool UserExistes(string userName)
        {
            return _db.Users.Any(x => x.UserName == userName);
        }

        private bool EmailExistes(string email)
        {
            return _db.Users.Any(x => x.Email == email);
        }
    }

}
