using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text;
using System.Threading.Tasks;
using Photogaleries.Models;

namespace Photogaleries.Data
{
    public class PhotogaleriesDbContext : IdentityDbContext<User>
    {
        public static PhotogaleriesDbContext Create()
        {
            return new PhotogaleriesDbContext();
        }
    }
}