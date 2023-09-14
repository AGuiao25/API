using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ResponseController :BaseApiController
    {
        private DataContext _context;
        public ResponseController(DataContext context)
        {
            _context = context;
            
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        } 
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var user = _context.Users.Find(-1);
            if(user == null) return NotFound();

            return user;
        }

 

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
              
                var user = _context.Users.Find(-1);
                var userToReturn = user.ToString();

                return userToReturn;



        } 
        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        } 
    }
}