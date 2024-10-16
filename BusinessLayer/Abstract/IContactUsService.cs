﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactUsService : IGenericService<ContactUs>
    {
        public List<ContactUs> GetListContactUsByFalse();
        public List<ContactUs> GetListContactUsByTrue();
        void ContactUsStatusChangeToFalse(int id);
    }
}
