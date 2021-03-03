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

        public IHttpActionResult Post(FitnessCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateFitnessService();
            if (!service.CreateFitness(model))
                return InternalServerError();
            return Ok();

        }  
       public IHttpActionResult GetAll()
       {
            FitnessService fitnessService = CreateFitnessService();
            var fitnessPlans = fitnessService.GetFitness();
                return Ok(fitnessPlans);
       }
            
       public IHttpActionResult GetId(int id)
       {
            FitnessService fitnessService = CreateFitnessService();
            var plan = fitnessService.GetFitnessById(id);
                return Ok(plan);
       }
            
       public IHttpActionResult Update(FitnessEdit model)
       {
          if (!ModelState.IsValid)
             return BadRequest(ModelState);

         var Service = CreateFitnessService();
            if (!Service.UpdateFitness(model))
                return InternalServerError();
                return Ok();
       }
         
       
       public IHttpActionResult Delete(int fitId)
       {
            var service = CreateFitnessService();

            if (!service.DeleteFitness(fitId))
                return InternalServerError();
             return Ok();
       }

       private FitnessService CreateFitnessService()
       {
          var fitId = int.Parse(User.Identity.GetFitnessId());
          var fitnessService = new FitnessService(fitId);
              return fitnessService;

       }
        

    }
}
