using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlobeMantics.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shared;

namespace Globemantics.Services
{
    public class ProposalMemoryService : IProposalService
    {
        private readonly List<ProposalModel> proposals = new List<ProposalModel>();

        public ProposalMemoryService()
        {
            proposals.Add(new ProposalModel
            {
                Id = 1,
                ConferenceId = 1,
                Speaker = "Tanuj Nayanam",
                Title = "Understanding Dot Net"
            });
            proposals.Add(new ProposalModel
            {
                Id = 2,
                ConferenceId = 2,
                Speaker = "Tanuj Nayanam",
                Title = "Starting C#"
            });
            proposals.Add(new ProposalModel
            {
                Id = 3,
                ConferenceId = 2,
                Speaker = "Ankur Pandey",
                Title = "Starting JAVA"
            });
        }

        public Task Add(ProposalModel model)
        {
            model.Id = proposals.Max(p => p.Id) + 1;
            proposals.Add(model);
            return Task.CompletedTask;
        }

        public Task<ProposalModel> Approve(int ProposalId)
        {
            return Task.Run(() =>
            {
                var proposal = proposals.First(p => p.Id == ProposalId);
                proposal.Approved = true;
                return proposal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(() => proposals.Where(p=>p.ConferenceId == conferenceId));
        }
    }
}
