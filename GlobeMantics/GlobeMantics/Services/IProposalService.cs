using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace GlobeMantics.Services
{
    public interface IProposalService
    {
        Task Add(ProposalModel model);
        Task<ProposalModel> Approve(int ProposalId);
        Task<IEnumerable<ProposalModel>> GetAll(int conferenceId);
    }
}
