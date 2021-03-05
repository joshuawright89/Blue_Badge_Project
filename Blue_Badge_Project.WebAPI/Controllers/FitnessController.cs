using Blue_Badge_Project.Models;
using Blue_Badge_Project.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Blue_Badge_Project.WebAPI.Controllers
{
    
    public class FitnessController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(FitnessCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFitnessService();
            if (!service.CreateFitness(model))
                return InternalServerError();
            return Ok();

        }

        private FitnessService CreateFitnessService()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var fitnessService = new FitnessService(userId);
            return fitnessService;

        }
        [HttpGet]
        public IHttpActionResult GetAll()
       {
            FitnessService fitnessService = CreateFitnessService();
            var fitnessPlans = fitnessService.GetFitness();
                return Ok(fitnessPlans);
       }
        [HttpGet]
            
       public IHttpActionResult GetId(int id)
       {
            FitnessService fitnessService = CreateFitnessService();
            var plan = fitnessService.GetFitnessById(id);
                return Ok(plan);
       }
        [HttpPut]
       public IHttpActionResult Update(FitnessEdit model)
       {
          if (!ModelState.IsValid)
             return BadRequest(ModelState);

         var Service = CreateFitnessService();
            if (!Service.UpdateFitness(model))
                return InternalServerError();
                return Ok();
       }
        [HttpDelete]
         
       public IHttpActionResult Delete(int fitId)
       {
            var service = CreateFitnessService();

            if (!service.DeleteFitness(fitId))
                return InternalServerError();
             return Ok();
       }
    }
}
