using Microsoft.AspNetCore.Mvc;
using SocialNet.Core.Application.Interfaces.Services;
using SocialNet.Core.Application.ViewModels.Comments;
using SocialNet.Core.Domain.Entities;
using SocialNet.MiddledWares;

namespace SocialNet.Controllers
{
    public class CommentController : Controller
    {
        ICommentsServices _commentsServices;
        private readonly ValidateUser _validateUser;
        public CommentController(ICommentsServices commentsServices, ValidateUser validateUser)
        {
            _commentsServices = commentsServices;
            _validateUser = validateUser;
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(string C, int PId, int UId)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveCommentViewModel coment = new SaveCommentViewModel
            {
                Comment = C,
                IdPost = PId,
                IdUser = UId
            };

            await _commentsServices.Add(coment);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentChild(string C, int PId, int UId, int CC)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SaveCommentViewModel coment = new SaveCommentViewModel
            {
                Comment = C,
                IdPost = PId,
                IdUser = UId,
                ParentCommentId = CC
            };

            await _commentsServices.Add(coment);

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }
    }
}
