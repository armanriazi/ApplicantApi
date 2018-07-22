using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Exceptional;

namespace Project.DistributedService.WebHostCore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public Task<ViewResult> About() => Task.FromResult(View());
        [HttpGet]
        public Task<ViewResult> Contact() => Task.FromResult(View());
        [HttpGet]
        public Task<ViewResult> Index() => Task.FromResult(View());
        public async Task Exceptions() => await ExceptionalMiddleware.HandleRequestAsync(HttpContext).ConfigureAwait(false);

    }
}