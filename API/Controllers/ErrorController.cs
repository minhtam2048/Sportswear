using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseAPIController
    {
        private readonly StoreContext _context;
        public ErrorController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("NotFound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(42);

            if (thing == null)
            {
                return NotFound(new APIResponse(404));
            }

            return Ok();
        }

        [HttpGet("ServerError")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(42);

            var thingToReturn = thing.ToString();

            return Ok();
        }

        [HttpGet("BadRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(id);
        }
    }
}