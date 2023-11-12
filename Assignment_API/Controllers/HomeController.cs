using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;


namespace Assignment_API.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
          [HttpGet]
        // public IActionResult Index()
        // {
        //     return View();
        // }
         [HttpGet]
        public IActionResult OauthRedirect()
        {
            string credentialPath =  @"X:\test\BD-Assignment\Assignment_API\files\client_secret.json";

            var credentials = JObject.Parse(System.IO.File.ReadAllText(credentialPath));
            var client_id = credentials["client_id"];
            string redirectUrl = "https://accounts.google.com/o/oauth2/v2/auth?" +
                            "scope=https://www.googleapis.com/auth/calendar+https://www.googleapis.com/auth/calendar.events&" + 
                            "access_type=online&" +
                            "include_granted_scopes=true&" +
                            "response_type=code&" +
                            "state=there&" +
                            "redirect_uri=http://localhost:5279/" + //oauth2.example.com/code&
                            "client_id=" + client_id;

            
            return Redirect(redirectUrl);
        }

    }
}