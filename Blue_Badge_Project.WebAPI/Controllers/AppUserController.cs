using Blue_Badge_Project.Models;
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
    public class AppUserController : ApiController //"Inside the controller, we're going to add a method that creates [an AppUserService]."  ...  "This will allow us to use our [AppUserService] in our methods."
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
            var appUsers = appUserService.GetAppUsersBySystemPlan();
            return Ok(appUsers);
        }

        public IHttpActionResult Post(AppUserCreate appUser) //4.03
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

                var service = CreateAppUserService();

                if (!service.CreateAppUser(appUser))
                    return InternalServerError();

                return Ok();
            }
        }


    }
}
