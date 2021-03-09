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
        public IHttpActionResult GetAppUserDetail(string userId)
        {
            AppUserService appUserService = CreateAppUserService();
            var appUserDetail = appUserService.GetUserId(userId);
            return Ok(appUserDetail);
        }
        public IHttpActionResult UserByLastName(string lastName)
        {
            AppUserService appUserService = CreateAppUserService();
            var userLastName = appUserService.GetAppUsersByLastName(lastName);
            return Ok(userLastName);
        }
        private AppUserService CreateAppUserService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var appUserDetail = new AppUserService(userId.ToString());
            return appUserDetail;
        }
    }
}
