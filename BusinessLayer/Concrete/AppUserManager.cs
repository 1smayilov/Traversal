﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Add(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void Delete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public AppUser GetById(int id)
        {
           return _appUserDal.GetById(id);
        }

        public List<AppUser> GetList()
        {
            return _appUserDal.GetList();
        }

        public void Update(AppUser entity)
        {
            _appUserDal.Update(entity); 
        }
    }
}
