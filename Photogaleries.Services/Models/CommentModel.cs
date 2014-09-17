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
                    
                };
            }
        }
    }
}