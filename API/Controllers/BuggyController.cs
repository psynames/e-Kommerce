using API.Errors;
using INFRASTRUCTURE.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _dbcontext;

        public BuggyController(StoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _dbcontext.Products.Find(45);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        }



        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _dbcontext.Products.Find(45);
            var thingToReturn = thing.ToString();
            return Ok();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBAdRequest()
        {
    
            return BadRequest(new ApiResponse(400));


        }
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            var thing = _dbcontext.Products.Find(45);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();

        }
    }
}
