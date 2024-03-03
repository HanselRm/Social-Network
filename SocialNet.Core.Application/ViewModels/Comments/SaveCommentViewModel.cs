using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Core.Application.ViewModels.Comments
{
    public class SaveCommentViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int PublicationsId { get; set; }

        public string UserId { get; set; }
    }
}
