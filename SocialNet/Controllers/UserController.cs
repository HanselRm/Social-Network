using Microsoft.AspNetCore.Mvc;
using SocialNet.Core.Application.Helpers;
using SocialNet.Core.Application.Interfaces;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Users;

namespace SocialNet.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly UploadFiles<IEntity> _uploadFiles;

        public UserController(IUserServices userServices, UploadFiles<IEntity> uploadFiles)
        {
            _userServices = userServices;
            _uploadFiles = uploadFiles;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View("Register", new SaveUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View("Register", model);
            }

            model.Imagen = _uploadFiles.UploadFile(model.File, model);
            await _userServices.Add(model);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}
