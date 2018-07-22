using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Exceptional;
using StackExchange.Profiling;

namespace Project.DistributedService.WebHostCore.Controllers
{
    public class TestController : Controller
    {
        public async Task<ActionResult> Throw()
        {
            await ExceptionalUtils.Test.GetRedisException().LogAsync(ControllerContext.HttpContext).ConfigureAwait(false);
            await new Exception("").LogAsync(ControllerContext.HttpContext).ConfigureAwait(false);

            var ex = new Exception("This is an exception thrown from the Samples project! - Check out the log to see this exception.");
            // here's how your catch/throw might can add more info, for example SQL is special cased and shown in the UI:
            ex.Data["SQL"] = "Select * From FUBAR -- This is a SQL command!";
            ex.Data["Redis-Server"] = "REDIS01";
            ex.Data["Not-Included"] = "This key is skipped, because it's not in the web.config pattern";
            ex.AddLogData("Via Extension", "Some logged data via the .AddLoggedData() method!");
            throw ex;
        }
        public ActionResult ThrowRedis() => throw ExceptionalUtils.Test.GetRedisException();


               public ActionResult EnableProfilingUI()
        {
            Program.DisableProfilingResults = false;
            return Redirect("/");
        }

        /// <summary>
        /// disable the profiling UI.
        /// </summary>
        /// <returns>disable profiling the UI</returns>
        public ActionResult DisableProfilingUI()
        {
            Program.DisableProfilingResults = true;
            return Redirect("/");
        }
        public RedirectToActionResult MultipleRedirect() => RedirectToAction(nameof(MultipleRedirectChild));
        public RedirectToActionResult MultipleRedirectChild() => RedirectToAction(nameof(MultipleRedirectChildChild));
        public IActionResult MultipleRedirectChildChild() => Content("You should see 3 MiniProfilers from that.");
        public IActionResult ViewProfiling() => View("ForLoop");
    }
}