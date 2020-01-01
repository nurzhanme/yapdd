using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;
using yapdd.Models;

namespace yapdd.Services.Contracts
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