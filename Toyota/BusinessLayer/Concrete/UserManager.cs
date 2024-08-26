using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUser _user;

        public UserManager(IUser user)
        {
            _user = user;
        }

        public void Add(User t)
        {
            _user.Insert(t);
        }

        public void Update(User t)
        {
            _user.Update(t);
        }

        public void Delete(User t)
        {
            _user?.Delete(t);
        }

        public List<User> GetList()
        {
            return _user.GetAll();
        }

        public User GetById(int id)
        {
            return _user.GetById(id);
        }
    }
}

