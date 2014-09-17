using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Photogaleries.Services.Models
{
    public class PhotoModel
    {
        public static Expression<Func<Photo, PhotoModel>> FromPhoto
        {
            get
            {
                return p => new PhotoModel()
                {

                };
            }
        }
    }
}