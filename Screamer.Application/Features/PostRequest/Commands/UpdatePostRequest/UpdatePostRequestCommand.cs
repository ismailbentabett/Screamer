using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest
{
    public class UpdatePostRequestCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Hashtags { get; set; }
        public List<string> TagsArr { get; set; }
        public List<string> MentionsArr { get; set; }

        public string MoodType { get; set; }

        public int postId { get; set; }
    }
}
