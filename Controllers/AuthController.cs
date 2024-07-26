using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("/Registration")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService) 
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<Registration> SaveData(Registration model)
        {
           return  await _authService.SaveUserInfo(null,model);
        }

    }
}
