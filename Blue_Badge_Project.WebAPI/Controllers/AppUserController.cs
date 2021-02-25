using Blue_Badge_Project.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Blue_Badge_Project.WebAPI.Controllers
{
    [Authorize]
    public class AppUserController : ApiController
    {
        private AppUserService CreateAppUserService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var appUserService = new AppUserService(ownerId);
            return appUserService;
        }

        public IHttpActionResult Get() //"Now let's add a Get All method" 4.03
        {
            AppUserService appUserService = CreateAppUserService();
            var appUsers = appUsers.GetAppUsers();
            return Ok(appUsers);
        }

    }
}
