using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail hissəsi boş keçilməməlidir");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad hissəsi boş keçilməməlidir");
            RuleFor(x => x.MessageBody).NotEmpty().WithMessage("Mesaj hissəsi boş keçilməməlidir");
        }
    }
}
