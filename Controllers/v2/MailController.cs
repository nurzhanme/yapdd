using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using yapdd.Models;
using yapdd.Services.Contracts;

namespace yapdd.Controllers.v2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService iMailService)
        {
            _mailService = iMailService;
        }

        // GET: api/Mail/List
        [HttpGet("List", Name = "List")]
        public async Task<IActionResult> List(string domain, string pddToken, string oauthToken, int? page = null, int? onPage = null)
        {
            var result = await _mailService.List(new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, page, onPage);
            return Ok(result);
        }

        // GET: api/Mail/Counters/
        //[HttpGet(Name = "Counters")]
        //public async Task<IActionResult> Counters(string domain, string pddToken, string oauthToken, long id)
        //{
        //    var result = await _mailService.Counters(
        //        new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, id);
        //    return Ok(result);
        //}

        // POST: api/Mail/Add
        //[HttpPost(Name = "Add")]
        //public async Task<IActionResult> Add([FromBody] Mail mail)
        //{
        //    var result = await _mailService.Add(mail);
        //    return Ok(result);
        //}

        //POST: api/Mail/Edit/
        //[HttpPost(Name = "Edit")]
        //public async Task<IActionResult> Edit([FromBody] EditMailDto editMailDto)
        //{
        //    var result = await _mailService.Edit(editMailDto.pddBase, editMailDto.emailAccountBase);
        //    return Ok(result);
        //}

        // DELETE: api/Mail/Delete
        //[HttpDelete(Name = "Delete")]
        //public async Task<IActionResult> Delete(string domain, string pddToken, string oauthToken, long id)
        //{
        //    var result = await _mailService.Delete(
        //        new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, id);
        //    return Ok(result);
        //}
    }
}
