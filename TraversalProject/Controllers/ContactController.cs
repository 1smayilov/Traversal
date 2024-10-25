using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto model)
        {
            if(ModelState.IsValid)
            {
                _contactUsService.Add(new ContactUs()
                {
                    Mail = model.Mail,
                    MessageBody = model.MessageBody,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    MessageStatus = true,
                    Subject = model.Subject,
                    Name = model.Name
                });

                return RedirectToAction("Index","Default"); 
            }
            return View(model);
        }
    }
}
