using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Photogaleries.Services.Models
{
    public class CommentModel
    {
        public static Expression<Func<Comment, CommentModel>> FromComment
        {
            get
            {
                return c => new CommentModel()
                {
                    Id=c.Id,
                    Text=c.Text,
                    Date=c.Date,
                    PhotoId=c.PhotoId,
                    UserId=c.UserId
                };
            }
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public int? PhotoId { get; set; }
        
    }
}