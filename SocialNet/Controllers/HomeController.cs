using Microsoft.AspNetCore.Mvc;
using SocialNet.Core.Application.Helpers;
using SocialNet.Core.Application.Interfaces;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.Services;
using SocialNet.Core.Application.ViewModels.Posts;
using SocialNet.Core.Application.ViewModels.Users;
using SocialNet.MiddledWares;
using SocialNet.Models;
using System.Diagnostics;

namespace SocialNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly UploadFiles<IEntity> _uploadFiles;
        private readonly ValidateUser _validateUser;
        public HomeController(IPostServices postServices, ValidateUser validateUser, UploadFiles<IEntity> uploadFiles)
        {
            _postServices = postServices;
            _validateUser = validateUser;
            _uploadFiles = uploadFiles;
        }

        public async Task <IActionResult> Index()
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Post = await _postServices.GetAllViewModelWithInclude();
            return View();  
        }

        
        [HttpPost]
        public async Task<IActionResult> AddPost(SavePostViewModel model)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Post = await _postServices.GetAllViewModels();
            if (!ModelState.IsValid)
            {

                return View("Index", model);
            }
            if(model.File != null)
            {
                model.ImgPost = _uploadFiles.UploadFile(model.File, model);
            }
            DateTime date = DateTime.Now;
            model.Date = new DateOnly(date.Year, date.Month, date.Day);
            model.Hour = new TimeOnly(date.Hour, date.Minute, date.Second);
            await _postServices.Add(model);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
           await _postServices.Delete(Id);

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
    }
    
}
