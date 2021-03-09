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
    public class AppUserController : ApiController
    {
        private AppUserService CreateAppUserService()
        {
            var id = User.Identity.GetUserId();
            var appUserDetail = new AppUserService(id.ToString());
            return appUserDetail;
        }

        [HttpPost]
        public IHttpActionResult PostAppUserCreate(AppUserCreate appUserCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUserService = CreateAppUserService();

            if (!appUserService.CreateAppUser(appUserCreate))
                return InternalServerError();
            return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAllAppUsers()
        {
            AppUserService appUserService = CreateAppUserService();
            var users = appUserService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetAppUserId(string id)
        {
            AppUserService appUserService = CreateAppUserService();
            var appUserDetail = appUserService.GetUserId(id);
            return Ok(appUserDetail);
        }

        [HttpPut]
        public IHttpActionResult UpdatePlan(AppUserEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAppUserService();
            if (!service.UpdatePlan(model))
                return InternalServerError();
            return Ok();
        }
            
        
    }
}
