using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectCloudyna.Models;
using ProjectCloudyna.Services;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectCloudyna.Controllers
{
    [Route("api/health")]
   
    public class HealthController : Controller
    {
       

        public HealthController()
        {
          
        }

        // GET: api/<controller>
        [HttpGet]
        public String Get()
        {
            return "OK";
        }
    }
}