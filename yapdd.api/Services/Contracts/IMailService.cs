using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;
using yapdd.api.Models;

namespace yapdd.api.Services.Contracts
{
    public interface IMailService
    {
        Task<ListEmailResponse> List(PddBase pddBase, int? page = null, int? onPage = null);
        Task<AddEmailResponse> Add(Mail mail);
        Task<EditEmailResponse> Edit(PddBase pddBase, EmailAccountBase emailAccountBase);
        Task<EmailCountersResponse> Counters(PddBase pddBase, long uid);
        Task<DeleteEmailResponse> Delete(PddBase pddBase, long uid);
    }
}