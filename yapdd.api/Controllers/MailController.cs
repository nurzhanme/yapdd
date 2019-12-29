using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yapdd.api.Models;
using yapdd.api.Models.DTOs;
using yapdd.api.Services.Contracts;

namespace yapdd.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService iMailService)
        {
            _mailService = iMailService;
        }

        // GET: api/Mail/List
        [HttpGet(Name = "List")]
        public async Task<ListEmailResponse> List(string domain, string pddToken, string oauthToken, int? page = null, int? onPage = null)
        {
            return await _mailService.List(new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, page, onPage);
        }

        // GET: api/Mail/Counters/
        [HttpGet(Name = "Counters")]
        public async Task<EmailCountersResponse> Counters(string domain, string pddToken, string oauthToken, long id)
        {
            return await _mailService.Counters(
                new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, id);
        }

        // POST: api/Mail/Add
        [HttpPost(Name = "Add")]
        public async Task<AddEmailResponse> Add([FromBody] Mail mail)
        {
            return await _mailService.Add(mail);
        }

        // POST: api/Mail/Edit/
        [HttpPost(Name = "Edit")]
        public async Task<EditEmailResponse> Edit([FromBody] EditMailDto editMailDto)
        {
            return await _mailService.Edit(editMailDto.pddBase, editMailDto.emailAccountBase);
        }

        // DELETE: api/Mail/Delete
        [HttpDelete(Name = "Delete")]
        public async Task<DeleteEmailResponse> Delete(string domain, string pddToken, string oauthToken, long id)
        {
            return await _mailService.Delete(
                new PddBase { Domain = domain, PddToken = pddToken, OAuthToken = oauthToken }, id);
        }
    }
}
