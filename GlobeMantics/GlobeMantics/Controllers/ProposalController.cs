﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globemantics.Services;
using GlobeMantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace GlobeMantics.Controllers
{
    public class ProposalController : Controller
    {
        private IConferenceService conferenceService;
        private IProposalService proposalService;

        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            this.conferenceService = conferenceService;
            this.proposalService = proposalService;
        }

        public async Task<IActionResult> Index(int conferenceId)
        {
            var conference = await conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposal for Conference {conference.Name} at location {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await (proposalService.GetAll(conferenceId)));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";
            return View(new ProposalModel {ConferenceId = conferenceId});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposal)
        {
            if (ModelState.IsValid)
                await proposalService.Add(proposal);
            return RedirectToAction("Index", new {conferenceId = proposal.ConferenceId});
        }

        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await proposalService.Approve(proposalId);
            return RedirectToAction("Index", new {conferenceId = proposal.ConferenceId});
        }
    }
}