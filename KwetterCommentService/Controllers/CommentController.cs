using Data;
using Logic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KwetterCommentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly CommentLogic logic;

        public CommentController(CommentDbContext ctx)
        {
            logic = new CommentLogic(ctx);
        }

        [HttpGet("commentsbypost")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult GetCommentsForPost(int id)
        {
            var result = logic.GetCommentsForPost(id);
            return Ok(result);
        }

        // GET: CommentController/Comment/5
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Comment(int id)
        {
            var result = logic.GetCommentById(id);
            return Ok(result);
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Create([FromBody]Comment comment)
        {
            try
            {
                logic.CreateComment(comment);
                return Ok();
            }
            catch
            {
                return View();
            }
        }

        // POST: CommentController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Delete(int id)
        {
            try
            {
                logic.DeleteComment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete("deleteallbyuser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAllByUser(int id)
        {
            logic.DeleteAllByUser(id);
            return Ok();
        }

    }
}
