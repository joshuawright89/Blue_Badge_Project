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
    public class DietController : ApiController
    {
        private DietService DisplayDietService()
        {
            var userId = User.Identity.GetUserId();
            var dietService = new DietService(userId);
            return dietService;
        }

        [HttpPost]
        public IHttpActionResult Post(DietCreate diet)
        {
          if (!ModelState.IsValid)
              return BadRequest(ModelState);
          var service = DisplayDietService();
          if (!service.CreateDiet(diet))
              return InternalServerError();
          return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
          DietService dietService = DisplayDietService();
          var diets = dietService.GetDiets();
          return Ok(diets);
        }

        [HttpGet]
        public IHttpActionResult Get(int dietId)
        {
          DietService dietService = DisplayDietService();
          var diet = dietService.GetDietById(dietId);
          return Ok(diet);
        }

        [HttpPut]
        public IHttpActionResult Update(DietEdit diet)
        {
          if (!ModelState.IsValid)
              return BadRequest(ModelState);
          var service = DisplayDietService();
          if (!service.UpdateDiet(diet))
              return InternalServerError();
          return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int dietId)
        {
          var service = DisplayDietService();
          if (!service.DeleteDiet(dietId))
             return InternalServerError();
          return Ok();
        }
    }
}
