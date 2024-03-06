using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Friends;
using SocialNet.MiddledWares;

namespace SocialNet.Controllers
{
    public class FriendsController : Controller
    {
        IFriendsServices _friendsServices;
        IUserServices _userServices;
        private readonly ValidateUser _validateUser;
        public FriendsController(IFriendsServices friendsServices, ValidateUser validateUser, IUserServices userServices)
        {
            _friendsServices = friendsServices;
            _validateUser = validateUser;
            _userServices = userServices;
        }
        public async Task <IActionResult> Index(int id)
        {
            
            ViewBag.listPost = await _friendsServices.GetAllViewModelWithInclude(id);
            return View();
        }

        public async Task<IActionResult> AddFriends(SaveFriendsViewModel model)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            var user = await _userServices.GetAllViewModels();
            var user2 = user.Where(a => a.UserName ==  model.Username).FirstOrDefault();

            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "Friends", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            if (user2 == null)
            {
                ModelState.AddModelError("UserValidation", "Usuario no encontrado");
            }
            else
            {
                model.IdFriend2 = user2.Id;
                await _friendsServices.Add(model);
                return RedirectToRoute(new { controller = "Friends", action = "Index" });
            }
            
            
            ViewBag.listPost = await _friendsServices.GetAllViewModelWithInclude(model.IdFriend1);

            return View("Index");
        }
    }
}
