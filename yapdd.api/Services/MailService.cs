using kasthack.yandex.pdd;
using kasthack.yandex.pdd.Entities;
using System;
using System.Threading.Tasks;
using yapdd.api.Models;
using yapdd.api.Services.Contracts;

namespace yapdd.api.Services
{
    public class MailService : IMailService
    {
        public async Task<ListEmailResponse> List(PddBase pddBase, int? page = null, int? onPage = null)
        {
            try
            {
                return await new PddApi(
                        pddBase.PddToken,
                        pddBase.OAuthToken
                    )
                    .Domain(pddBase.Domain).Mail.List(page, onPage);
            }
            catch (Exception e)
            {
                //todo log error
                throw;
            }
        }

        public async Task<AddEmailResponse> Add(Mail mail)
        {
            try
            {
                return await new PddApi(
                        mail.PddToken,
                        mail.OAuthToken
                    )
                    .Domain(mail.Domain).Mail.Add(mail.Login, mail.Password);
            }
            catch (Exception e)
            {
                //todo log error
                throw;
            }
        }

        public async Task<EditEmailResponse> Edit(PddBase pddBase, EmailAccountBase emailAccountBase)
        {
            try
            {
                return await new PddApi(
                        pddBase.PddToken,
                        pddBase.OAuthToken
                    )
                    .Domain(pddBase.Domain).Mail.Edit(emailAccountBase);
            }
            catch (Exception e)
            {
                //todo log error
                throw;
            }
        }

        public async Task<EmailCountersResponse> Counters(PddBase pddBase, long uid)
        {
            try
            {
                return await new PddApi(
                        pddBase.PddToken,
                        pddBase.OAuthToken
                    )
                    .Domain(pddBase.Domain).Mail.Counters(uid);
            }
            catch (Exception e)
            {
                //todo log error
                throw;
            }
        }

        public async Task<DeleteEmailResponse> Delete(PddBase pddBase, long uid)
        {
            try
            {
                return await new PddApi(
                        pddBase.PddToken,
                        pddBase.OAuthToken
                    )
                    .Domain(pddBase.Domain).Mail.Delete(uid);
            }
            catch (Exception e)
            {
                //todo log error
                throw;
            }
        }
    }
}
