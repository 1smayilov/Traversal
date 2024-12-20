﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalProject.CQRS.Commands.GuideCommands;
using TraversalProject.CQRS.Queries.GuideQueries;
using TraversalProject.CQRS.Queries.GuideQueries.GetGuideByIdQuery;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        } 

        public async Task<IActionResult> Index()
        { 
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> GetGuides(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteGuide(int id)
        {
            await _mediator.Send(new DeleteGuideCommand(id));
            return RedirectToAction("Index");
        }
    }
}
