<<<<<<< HEAD
﻿using LemonDotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
<<<<<<< HEAD
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection.Metadata;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> parent of 8ac0809 (.)
=======
>>>>>>> parent of 340352c (.)

namespace LemonDotNetCore.MvcApp.Controllers
{
    public class BlogHttpClientController : Controller
    {
        private readonly HttpClient _httpClient;

        public BlogHttpClientController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
