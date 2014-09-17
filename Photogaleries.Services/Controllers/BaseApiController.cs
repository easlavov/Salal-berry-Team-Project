using Photogaleries.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Photogaleries.Services.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        protected IPhotogaleriesData Data { get; set; }

        protected BaseApiController(IPhotogaleriesData data)
        {
            this.Data = data;
        }
    }
}