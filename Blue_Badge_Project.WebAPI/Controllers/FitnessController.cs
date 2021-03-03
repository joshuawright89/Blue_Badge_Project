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
       public IHttpActionResult GetAll()
       {
            FitnessService fitnessService = CreateFitnessService();
            var fitnessPlans = fitnessService.GetFitness();
                return Ok(fitnessPlans);
       }
            
       public IHttpActionResult GetId(int fitnessId)
       {
            FitnessService fitnessService = CreateFitnessService();
            var fitness = fitnessService.GetFitnessById(fitnessId);
                return Ok(fitness);
       }
            
       public IHttpActionResult UpdateFit(FitnessEdit fitness)
       {
          if (!ModelState.IsValid)
             return BadRequest(ModelState);

         var Service = CreateFitnessService();
            if (!Service.UpdateFitness(fitness))
                return InternalServerError();
                return Ok();
       }
            
       public IHttpActionResult fitnessDelete(int fitnessId)
       {
          int service = CreateFitnessService();
            if (!service.DeleteFitness(fitnessId))
                return InternalServerError();
             return Ok();
       }

       private FitnessService CreateFitnessService()
       {
          int appId = int.Parse(UserIdentity.GetFitnessById());
          int fitnessService = new FitnessService(userId);
              return fitnessService;

       }
        

    }
}
