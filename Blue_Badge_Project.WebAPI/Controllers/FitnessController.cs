using Blue_Badge_Project.Models;
using Blue_Badge_Project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Blue_Badge_Project.WebAPI.Controllers
{
    public class FitnessController : ApiController
    {
        public IHttpActionResult Post(FitnessCreate fitnessPlan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFitnessService();
            if (!service.CreateFitness(fitnessPlan))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get()
        {
            FitnessService fitnessService = CreateFitnessService();
            var fitnessPlans = fitnessService.GetFitness();
            return Ok(fitnessPlans);
        }
        public IHttpActionResult Get(int fitnessId)
        {
            FitnessService fitnessService = CreateFitnessService();
            var fitness = fitnessService.GetFitnessById(fitnessId);
            return Ok(fitness);
        }
        public IHttpActionResult Put(FitnessEdit fitness)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Service = CreateFitnessService();
            if (!Service.UpdateFitness(fitness))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int fitnessId)
        {
            var service = CreateFitnessService();
            if (!service.DeleteFitness(fitnessId))
                return InternalServerError();
            return Ok();
        }
        private FitnessService CreateFitnessService()
        {
          var appId = Guid.Parse(UserIdentity.GetFitnessById());
          var fitnessService = new FitnessService(userId);
           return fitnessService;
        }
    }
}
