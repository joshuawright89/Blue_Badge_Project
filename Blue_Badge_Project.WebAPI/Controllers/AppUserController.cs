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
        [HttpGet]
        public IHttpActionResult GetAppUserDetail(string userId)
        {
            AppUserService appUserService = CreateAppUserDetail();
            var appUserDetail = appUserService.GetUserId(userId);
            return Ok(appUserDetail);
        }
        private AppUserService CreateAppUserDetail()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var appUserDetail = new AppUserService(userId.ToString());
            return appUserDetail;
        }
    }
}
